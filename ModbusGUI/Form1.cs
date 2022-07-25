using System;
using System.Windows.Forms;
using System.Media;         // Reproduce sonidos
using EasyModbus;           // Librería para métodos Modbus en C#

namespace ModbusGUI
{
    // Hereda de clase Form
    public partial class ModbusClientForm : Form
    {
        // Inicializa el objeto Modbus
        ModbusClient modbusClient = new ModbusClient();
        // Indicadores de procesos
        private bool SensorStatus = false;
        private bool AlarmStatus = false;
        private bool SoundPlaying = false;

        // Método Constructor
        public ModbusClientForm()
        {
            InitializeComponent();
        }

        // Método para conectar a un servidor Modbus TCP/IP
        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Visibilidad de botones
                ButtonVisibility(false, "connect");
                // Métodos Modbus para conexión con servidor
                modbusClient = new ModbusClient(textBoxIP.Text, 502);
                modbusClient.Connect();
                // Ventana emergente
                MessageBox.Show("Conexión Exitosa", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // En caso de error
            catch
            {
                // Visibilidad de botones
                ButtonVisibility(true, "connect");
                // Ventana emergente
                MessageBox.Show("Conexión Fallida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*//Método para inicializar el timer
        private void InitializeTimer()
        {
            // Censa cada 1.5 segundos
            timer1.Interval = 1500;
            // Comenzar
            timer1.Enabled = true;
            // Cada 1.5 seg, llamar ReadFlameData
            timer1.Tick += new EventHandler(ReadFlameData);
        }*/

        // Método para lectura de holding register @200
        private void ReadFlameData()
        {
            // Si el sensor está armado
            if (SensorStatus)
            {
                int[] lectura;
                // Método Modbus para lectura de registro de entrada
                lectura = modbusClient.ReadInputRegisters(200,1);
                // Si detectó una flama
                if (lectura[0] != 0)
                {
                    // Metodo Modbus para escribir a un coil
                    modbusClient.WriteSingleCoil(100, true);
                    // Feedback en la app
                    FireVisual(true);
                    AlarmVisual(true);
                    AlarmSound(true);
                    /*Esconde botones de alarma
                    para evitar interferir con la señal*/
                    ButtonVisibility(true, "alarm");
                }
                // Si no detectó flama y estamos con la alarma puesta
                else if (lectura[0] == 0 && AlarmStatus)
                {
                    // Feedback en la app
                    FireVisual(false);
                    // Regresa los botones de alarma ya que no hay fuego
                    ButtonVisibility(true, "alarm");
                }
                // Si no detectó flama y no estamos con la alarma encendida
                else
                {
                    // Metodo Modbus para escribir a un coil
                    modbusClient.WriteSingleCoil(100, false);
                    // Feedback en la app
                    FireVisual(false);
                    AlarmVisual(false);
                    AlarmSound(false);
                    // Regresa los botones de alarma ya que no hay fuego
                    ButtonVisibility(true, "alarm");
                }
            }
            // Si el sensor no está armado
            else
            {
                // Metodo Modbus para escribir a un coil
                modbusClient.WriteSingleCoil(100, false);
                // Feedback en la app
                FireVisual(false);
                AlarmVisual(false);
                AlarmSound(false);
                // Muestra botones de alarma
                ButtonVisibility(true, "alarm");
            }
        }

        // Método para desconexión del servidor
        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            //Si hay un servidor conectado
            if (modbusClient.Connected){
                try
                {
                    // Desconecta feedback
                    FireVisual(false);
                    AlarmVisual(false);
                    AlarmSound(false);
                    // Desconecta alarma
                    modbusClient.WriteSingleCoil(100, false);
                    // Muestra botones
                    ButtonVisibility(true, "connect");
                    ButtonVisibility(true, "alarm");
                    ButtonVisibility(true, "detector");
                    // Para de censar datos
                    timer1.Stop();
                    // Desconexión del ESP32
                    modbusClient.Disconnect();
                    // Ventana emergente
                    MessageBox.Show("Desconexión Exitosa", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // En caso de error
                catch
                {
                    // Visibilidad de botones
                    ButtonVisibility(false, "connect");
                    // Ventana emergente
                    MessageBox.Show("Algo salió mal, intente de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Visibilidad de botones
                ButtonVisibility(true, "connect");
                MessageBox.Show("No hay servidor conectado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para el manejo de sonido de alarma
        private void AlarmSound(bool PlaySound = true)
        {
            SoundPlayer audio = new SoundPlayer(ModbusGUI.Properties.Resources.temporal3);
            // Si se solicita sonido y no está sonando
            if (PlaySound && !SoundPlaying)
            {
                audio.PlayLooping();
                // Indicador de proceso
                SoundPlaying = true;
            }
            // Si se solicita sonido y ya estaba sonando
            else if (PlaySound && SoundPlaying)
            {
                // Continue sonando...
                // Indicador de proceso
                SoundPlaying = true;
            }
            // Si se solicita detener el sonido
            else if(!PlaySound)
            {
                audio.Stop();
                // Indicador de proceso
                SoundPlaying = false;
            }
        }

        // Método para encender la alarma
        private void alarmOnBtn_Click(object sender, EventArgs e)
        {
            // Si existe conexión a servidor
            if (modbusClient.Connected)
            {
                try
                {
                    // Metodo Modbus para escribir a un coil
                    modbusClient.WriteSingleCoil(100, true);
                    // Feedback en la app
                    AlarmVisual(true);
                    AlarmSound(true);
                    // Indicador de proceso
                    AlarmStatus = true;
                }
                catch
                {
                    // Feedback en la app
                    AlarmVisual(false);
                    AlarmSound(false);
                    // Indicador de proceso
                    AlarmStatus = false;
                    // Ventana emergente
                    MessageBox.Show("Algo salió mal, revise la dirección de coil", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Ventana emergente
                MessageBox.Show("No hay servidor conectado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para apagar la alarma
        private void alarmOffBtn_Click(object sender, EventArgs e)
        {
            // Si existe conexión a servidor
            if (modbusClient.Connected)
            {
                try
                {
                    // Apaga la alarma en el ESP32
                    modbusClient.WriteSingleCoil(100, false);
                    // Feedback en la app
                    AlarmVisual(false);
                    AlarmSound(false);
                    // Cambio de status
                    AlarmStatus = false;
                }
                // Si la alarma falla
                catch
                {
                    // Feedback en la app
                    AlarmVisual(true);
                    AlarmSound(true);
                    // Indicador de proceso
                    AlarmStatus = true;
                    // Ventana emergente
                    MessageBox.Show("Dirección/Conexión de coil incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Si no existe conexión a servidor
            else
            {
                // Ventana emergente
                MessageBox.Show("No existe conexión a servidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para tomar "conectar" el sensor de flama
        private void detectorOnBtn_Click(object sender, EventArgs e)
        {
            // Si tenemos conexión a servidor
            if (modbusClient.Connected)
            {
                /*// Comienza el timer y toma de datos
                InitializeTimer();*/
                // Visibilidad de botones
                timer1.Start();
                ButtonVisibility(false, "detector");
                // Indicador de proceso
                SensorStatus = true;

            }
            // Si no tenemos conexión a servidor
            else
            {
                // Si el servidor se desconectó, esto detiene las alarmas en la app
                timer1.Stop();
                // Ventana emergente
                MessageBox.Show("No existe conexión a servidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para desconectar el sensor de flama
        private void detectorOffBtn_Click(object sender, EventArgs e)
        {
            // Si tenemos conexión y NO estábamos con la alarma
            if (modbusClient.Connected && !AlarmStatus)
            {
                // Metodo Modbus para escribir a un coil
                modbusClient.WriteSingleCoil(100, false);
                // Para de censar datos
                timer1.Stop();
                // Feedback en la app
                FireVisual(false);
                AlarmVisual(false);
                AlarmSound(false);
                // Visibilidad de botones
                ButtonVisibility(true, "detector");
                ButtonVisibility(true, "alarm");
                // Indicador de proceso
                SensorStatus = false;
            }
            // Si tenemos conexión y SÍ estabamos la alarma
            else if(modbusClient.Connected && AlarmStatus)
            {
                // Para de sensar datos
                timer1.Stop();
                // Feedback en la app
                FireVisual(false);
                // Visibilidad de botones
                ButtonVisibility(true, "detector");
                ButtonVisibility(true, "alarm");
                // Indicador de proceso
                SensorStatus = false;
            }
            // Si no tenemos conexión con el servidor
            else
            {
                // Metodo Modbus para escribir a un coil
                modbusClient.WriteSingleCoil(100, false);
                // Para de censar datos
                timer1.Stop();
                // Feedback en la app
                FireVisual(false);
                AlarmVisual(false);
                AlarmSound(false);
                // Visibilidad de botones
                ButtonVisibility(true, "detector");
                ButtonVisibility(true, "alarm");
                // Indicador de proceso
                SensorStatus = false;
                // Ventana emergente
                MessageBox.Show("Se perdió la conexión con el servidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para visibilidad de botones
        private void ButtonVisibility(bool status, string type = "")
        {
            switch(status)
            {
                // Solicitud de encendido/conexión
                case true:
                    switch (type)
                    {
                        case "connect":
                            connectBtn.Visible = true;
                            disconnectBtn.Visible = false;
                            break;
                        case "alarm":
                            label2.Visible = true;
                            alarmOnBtn.Visible = true;
                            label3.Visible = true;
                            alarmOffBtn.Visible = true;
                            break;
                        case "detector":
                            activarDetector.Visible = true;
                            detectorOnBtn.Visible = true;
                            desactivarDetector.Visible = false;
                            detectorOffBtn.Visible = false;
                            break;
                    }
                    break;
                // Solicitud de apagado/desconexión
                case false:
                    switch (type)
                    {
                        case "connect":
                            connectBtn.Visible = false;
                            disconnectBtn.Visible = true;
                            break;
                        case "alarm":
                            label2.Visible = false;
                            alarmOnBtn.Visible = false;
                            label3.Visible = false;
                            alarmOffBtn.Visible = false;
                            break;
                        case "detector":
                            activarDetector.Visible = false;
                            detectorOnBtn.Visible = false;
                            desactivarDetector.Visible = true;
                            detectorOffBtn.Visible = true;
                            break;
                    }
                    break;
            }
        }

        // Método para manejo de feedback visual de alarma
        private void AlarmVisual(bool status = true)
        {
            if (status)
            {
                alarmGIF.Visible = true;
            }
            else
            {
                alarmGIF.Visible= false;
            }
        }

        // Metodo para manejo de feedback visual de incendio
        private void FireVisual(bool status = true)
        {
            if (status)
            {
                flameGIF.Visible = true;
                fireDetected.Visible = true;
            }
            else
            {
                flameGIF.Visible= false;
                fireDetected.Visible= false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ReadFlameData();
        }
    }
}