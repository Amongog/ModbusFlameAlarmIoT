using System;
using System.Windows.Forms;
using System.Media;
using EasyModbus;

namespace ModbusGUI
{
    public partial class ModbusClientForm : Form
    {
        ModbusClient modbusClient = new ModbusClient();
        int SensorStatus = 0;
        int TestStatus = 0;
        public ModbusClientForm()
        {
            InitializeComponent();
        }

        // Método para conexión a servidor por Modbus
        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Visibilidad del botón
                connectBtn.Visible = false;
                disconnectBtn.Visible = true;
                // Conecta al ESP32
                modbusClient = new ModbusClient(textBoxIP.Text, 502);
                modbusClient.Connect();
                MessageBox.Show("Conexión Exitosa", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // En caso de error
            catch
            {
                // Visibilidad del botón
                connectBtn.Visible = true;
                disconnectBtn.Visible = false;
                MessageBox.Show("Conexión Fallida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Método para inicializar el timer
        private void InitializeTimer()
        {
            timer1.Interval = 4900;
            timer1.Enabled = true;
            // Comienza la lectura del sensor en el holding/input register 101
            timer1.Tick += new EventHandler(ReadFlameData);
        }

        // Método para lectura de holdin/input register @101
        private void ReadFlameData(object sender, System.EventArgs e)
        {
            // Si el sensor está armado
            if (SensorStatus == 1)
            {
                int[] lectura;
                lectura = modbusClient.ReadHoldingRegisters(101,1);
                // Si detectó una flama
                if (lectura[0] == 1024)
                {
                    // Esconde botones de prueba de alarma
                    // para evitar interferir con la señal
                    label2.Visible = false;
                    alarmOnBtn.Visible = false;
                    label3.Visible = false;
                    alarmOffBtn.Visible = false;

                    // Feedback visual de alarma en la app
                    flameGIF.Visible = true;
                    alarmGIF.Visible = true;
                    fireDetected.Visible = true;
                    // Feedback audible en la app
                    Alarm();
                }
                else if (lectura[0] == 0 && TestStatus == 1)
                {
                    // Muestra botones de prueba de alarma
                    label2.Visible = true;
                    alarmOnBtn.Visible = true;
                    label3.Visible = true;
                    alarmOffBtn.Visible = true;
                }
                else
                {
                    // Muestra botones de prueba de alarma
                    label2.Visible = true;
                    alarmOnBtn.Visible = true;
                    label3.Visible = true;
                    alarmOffBtn.Visible = true;
                    // Feedback visual de alarma en la app off
                    flameGIF.Visible = false;
                    alarmGIF.Visible = false;
                    fireDetected.Visible = false;
                    // Feedback audible en la app off
                    Alarm(2);
                }
            }
            else
            {
                // Muestra botones de prueba de alarma
                label2.Visible = true;
                alarmOnBtn.Visible = true;
                label3.Visible = true;
                alarmOffBtn.Visible = true;
                // Feedback visual de alarma en la app off
                flameGIF.Visible = false;
                alarmGIF.Visible = false;
                fireDetected.Visible = false;
                // Feedback audible en la app off
                Alarm(2);
            }
        }

        // Método para desconexión del servidor
        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            // Visibilidad del botón
            connectBtn.Visible = true;
            disconnectBtn.Visible = false;
            //Si tenemos un servidor conectado
            if (modbusClient.Connected){
                try
                {
                    // Desconexión del ESP32
                    modbusClient.Disconnect();
                    timer1.Stop();
                    MessageBox.Show("Desconexión Exitosa", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // En caso de error
                catch
                {
                    // Visibilidad del botón
                    connectBtn.Visible = false;
                    disconnectBtn.Visible = true;
                    MessageBox.Show("Algo salió mal, no se realizó la desconexión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay servidor conectado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para el manejo de sonido de alarma
        private void Alarm(int i = 1)
        {
            SoundPlayer audio = new SoundPlayer(ModbusGUI.Properties.Resources.temporal3);
            if (i == 1)
            {
                audio.Play();
            }
            else if(i == 2)
            {
                audio.Stop();
            }
        }

        // Método para la prueba de la alarma
        private void alarmOnBtn_Click(object sender, EventArgs e)
        {
            if (modbusClient.Connected)
            {
                try
                {
                    // Enciende la alarma en el ESP32
                    modbusClient.WriteSingleCoil(100, true);
                    // Feedback visual de alarma en la app
                    alarmGIF.Visible = true;
                    // Feedback audible en la app
                    Alarm();
                    // Cambio de status
                    TestStatus = 1;
                }
                catch
                {
                    // Detiene feedback visible de alarma
                    alarmGIF.Visible = false;
                    // Detiene alarma
                    Alarm(2);
                    TestStatus = 0;
                    MessageBox.Show("Algo salió mal, revise la dirección de coil", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay servidor conectado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para terminar la prueba de la alarma
        private void alarmOffBtn_Click(object sender, EventArgs e)
        {
            if (modbusClient.Connected)
            {
                try
                {
                    // Apaga la alarma en el ESP32
                    modbusClient.WriteSingleCoil(100, false);
                    // Detiene feedback visual de alarma en la app
                    alarmGIF.Visible = false;
                    // Detiene feedback audible en la app
                    Alarm(2);
                    // Cambio de status
                    TestStatus = 0;
                }
                catch
                {
                    // Feedback visible se mantiene
                    alarmGIF.Visible = true;
                    // Feedback audible en la app se mantiene
                    Alarm();
                    TestStatus = 1;
                    MessageBox.Show("Algo salió mal, revise la dirección de coil", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay servidor conectado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para tomar datos del sensor de flama
        private void detectorOnBtn_Click(object sender, EventArgs e)
        {
            if (modbusClient.Connected)
            {
                // Visibilidad del botón y texto
                activarDetector.Visible = false;
                detectorOnBtn.Visible = false;
                desactivarDetector.Visible = true;
                detectorOffBtn.Visible = true;
                // Comienza el timer y a tomar datos
                InitializeTimer();
                // Marca el sensor como encendido
                SensorStatus = 1;
            }
            else
            {
                MessageBox.Show("No hay servidor conectado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para dejar de tomar datos del sensor de flama
        private void detectorOffBtn_Click(object sender, EventArgs e)
        {
            if (modbusClient.Connected)
            {
                // Marca el sensor como apagado
                SensorStatus = 0;
                // Visibilidad del botón y texto
                activarDetector.Visible = true;
                detectorOnBtn.Visible = true;
                desactivarDetector.Visible = false;
                detectorOffBtn.Visible = false;
            }
            else
            {
                // Visibilidad del botón y texto
                activarDetector.Visible = true;
                detectorOnBtn.Visible = true;
                desactivarDetector.Visible = false;
                detectorOffBtn.Visible = false;
                MessageBox.Show("No hay servidor conectado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
