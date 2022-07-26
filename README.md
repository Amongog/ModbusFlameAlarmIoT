---
title: 'README'
type: slide
---

Protocolo Modbus TCP/IP para IoT con servidor ESP32 y cliente GUI<!-- omit in toc -->
===
Este proyecto fue desarrollado para el curso `IE-0217 Estructuras Abstractas y Algoritmos para Ingeniería` de la Escuela de Ingeniería de la Universidad de Costa Rica.
<!--  -->

---

<!--  -->
| Desarrolladores      | Carné  |
| -------------------- |:------:|
| Samuel Berrocal Soto | B40993 |
| Kendall Cruz Sosa    | B42176 |
<!--  -->

---

<!--  -->
El proyecto consiste en una interfaz gráfica que actúa como el `cliente` en un protocolo `Modbus` para enviar y recibir información de un `servidor` el cual está equipado con un sensor de flama y una alarma compuesta por un LED y un buzzer (actuadores).

![GUI](https://i.imgur.com/h12c4Sk.gif)

*GUI de Cliente Modbus en funcionamiento.*
<!--  -->

---

<!--  -->
## Tabla de Contenidos

[TOC]
<!--  -->

---

<!--  -->
## 1. Objetivos
1. Implementar el protocolo `Modbus TCP/IP` para conectar un cliente (PC) con un servidor (`ESP32`) haciendo uso de la librería ArduinoModbus (`C++`). 
2. Diseñar interfaz (GUI) para el cliente que muestre valores de sensores en el servidor en tiempo real, y permita enviar señales de control al servidor para accionar salidas. 
<!--  -->

---

<!--  -->
## 2. Alcance
Este proyecto busca ilustrar el potencial del protocolo Modbus para aplicaciones IoT. 
Se utilizará un módulo `ESP32` para utilizar como servidor, el cual correrá un código en `C++` utilizando la librería [modbus-esp8266](https://github.com/emelianov/modbus-esp8266).  Este módulo permite una conexión inalámbrica de bajo consumo energético con el cliente a un bajo costo.  Este módulo también facilitará el uso de la variante del protocolo `Modbus TCP/IP`.  
<!--  -->

---

<!--  -->
Como segunda parte de este proyecto se plantea desarrollar una interfaz para que el usuario pueda controlar y monitorear en tiempo real los servidores. La GUI se desarrollará en el leguaje`C#` con la IDE [Visual Studio](https://visualstudio.microsoft.com/es/).
<!--  -->

---

<!--  -->
## 3. Protocolo Modbus

`Modbus` es un protocolo de comunicación desarrollado por Modicon (hoy `Schnider Electric`) y publicado en 1979 para ser utilizado con PLCs. El protocolo establece la comunicación entre un `cliente` y hasta `247 servidores`.  

Su uso está enfocado principalmente en la industria, sin embargo, lo podemos utilizar para IoT, como se demuestra en este proyecto.
<!--  -->

---

<!--  -->
![Modbus_Use](https://i.imgur.com/BGmLaYK.png)

*Diagrama ejemplo de uso de Modbus en la Industria.*
<!--  -->

---

<!--  -->
### Funcionamiento

El protocolo transmite transmite paquetes de información entre solicitudes del `cliente` y respuestas del `servidor`.  

Escencialmente, el protocolo se reduce a un código de funcón y un paquete de datos en una trama.  
<!--  -->

---

<!--  -->
![Client-Server_Transaction](https://i.imgur.com/qztUjHh.png)

*Transacción Modbus sin errores.*

![](https://i.imgur.com/UDCGOGM.png)

*Transacción Modbus con errores.*
<!--  -->

---

<!--  -->
Dependiendo de la implementación del protocolo, la trama puede tener encabezados y colas.

![ModbusRTU_DataUnit](https://i.imgur.com/FjmAK43.png)

*Tramas del protocolo Modbus RTU (Serial).*

![ModbusTCPIP_DataUnit](https://i.imgur.com/NSNdOhU.png)

*Tramas del protocolo Modbus TCP/IP.*
<!--  -->

---

<!--  -->
### Almacenamiento de datos
Los datos en un servidor se almacenan en cuantro tablas:
1. Valores discretos o `coils` (read-only, read-write).
2. Valores numéricos (read-only, read-write).
<!--  -->

---

<!--  -->
| Coil/Registers Numbers | Data Adresses |    Type    |           Table Name           |
|:----------------------:|:-------------:|:----------:|:------------------------------:|
|         1-9999         | 0000 to 270E  | Read-Write |     Discrete Output Coils      |
|      10001-19999       | 0000 to 270E  | Read-Only  |    Discrete Input Contacts     |
|      30001-39999       | 0000 to 270E  | Read-Only  |     Analog Input Registers     |
|      40001-49999       |  000 to 270E  | Read-Write | Analog Output Holding Rgisters |
<!--  -->

---

<!--  -->
### Códigos de Función
Son los código de las distintas funciones que el `cliente` o `servidor` pueden  solicitar o responder.
<!--  -->

---

<!--  -->
| Function Code |     Action     |           Table Name            |
|:-------------:|:--------------:|:-------------------------------:|
|  01 (01 hex)  |      Read      |      Discrete Output Coils      |
|  05 (05 hex)  |  Write Single  |      Discrete Output Coil       |
|  15(0F hex)   | Write Multiple |      Discrete Output Coils      |
|  02(02 hex)   |      Read      |     Discrete Input Contacts     |
|  04 (04 hex)  |      Read      |     Analog Input Registers      |
|  03 (03 hex)  |      Read      | Analog Output Holding Registers |
|  06 (06 hex)  |  Write Single  |  Analog Outpu Holding Register  |
|  16 (10 hex)  | Write Multiple | Analog Output Holding Registers |
<!--  -->

---

<!--  -->
### Formato de comandos y respuestas del servidor
|            Data Addresses             | Read  | Write Single | Write Multiple |
| :-----------------------------------: | :---: | :----------: | :------------: |
|      Discrete Output Coils 0XXXX      | FC01  |     FC05     |      FC15      |
|     Discrete Input Contacts 1XXXX     | FC04  |     *NA*     |      *NA*      |
|     Analog input Registers 3XXXX      | FC04  |     *NA*     |      *NA*      |
| Analog Output Holding Registers 4XXXX | FC03  |     FC06     |      FC16      |
<!--  -->

---

<!--  -->
## 4. Uso del protocolo con el ESP32 como *servidor*
### El ESP32
Para este proyecto se creo un servidor que está ubicado en la tarjeta de desarrollo `ESP32` usada en el circuito final del proyecto. El servidor se logró utilizando la IDE de Arduino en la cual de desarrolló un código en lenguaje `C++` que inicializa el servido utilizando la libreria [modbus-esp8266](https://github.com/emelianov/modbus-esp8266) la cual nos provee de los métodos necesarios para el desarrollo del servidor dentro de la tarjeta de desarrollo `ESP32`.  
<!--  -->

---

<!--  -->
El módulo `ESP32` es una dispositivo que puede funcionar mediante las tecnologías Wi-Fi/Bluetooth todo en uno, integrada y certificada que nos proporcionará tanto una radio inalámbrica, como un procesador integrado con interfaces para conectarse con varios periféricos dependiendo de la aplicación deseada en cualquier momento. El procesador tiene dos núcleos de procesamiento y tabaja con dos frecuencias operativas que pueden controlarse de manera independientemente entre 80 MHz y 240 MHz. 
<!--  -->

---

<!--  -->
![](https://i.imgur.com/MWc0ffZ.png)

*Pinout del ESP32*
<!--  -->

---

<!--  -->
### El código

#### Librerias, Inicialización de variables y llamado al objeto ModbusIP

```cpp
#ifdef ESP8266
#include <ESP8266WiFi.h>
#else //ESP32
#include <WiFi.h>
#endif
#include "ModbusIP_ESP8266.h"

//Registros de los Offset de Modbus
const int SENSOR_IREG = 200; //Aquí tenemos la ubicación de la información del sensor de llama
const int LED_COIL = 100; //Aquí tenemos la ubicación de la información para el output
//Pines a utilizar
const int ledPin = 23; //GPIO23
const int sensor = 0;

//Llamamos al objeto ModbusIP
ModbusIP mb;


long ts;
```
<!--  -->

---

<!--  -->
#### Establecimiento de la conexión
Este código va a permitir que la tarjeta de desarrollo `ESP32` se conecte a la red de área local, mediante el ingreso de los credenciales de la misma. Además, se imprimirá en la terminal de Arduino el estado actual y la dirección IP asignada a la tarjeta de desarrollo `ESP32` para que sea de fácil acceso al usuario.
<!--  -->

---

<!--  -->
```cpp
void setup() {
  //velocidad máxima de baudios
  Serial.begin(115200);
  //Información de la red a la que se desea conectar
  WiFi.begin("SSID", "Contraseña WiFi");
  //Método para que imprima la info en caso de conectarse
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("");
  Serial.println("WiFi connected");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP()); //imprime la IP local del servidor

```
<!--  -->

---

<!--  -->
#### Inicialización del servidor y establecimiento de la ubicación de los Offsets
Aquí se encenderá se van a establecer los offset o ubicaciones de los registros que se van a estar modificando durante la ejecución de este proyecto, para este caso se estableció el offset 100 para la ubicación del `Coil`, que será nuestra salida LED/Buzzer (establecida así en el código) y el 200 para la ubicación de la información del sensor que del cual queremos saber su estado.
<!--  -->

---

<!--  -->
```cpp
mb.server();    //Encendemos el servidor Modbus IP
  // Agregamos el registro SENSOR_IREG
  // Se debe usar addIreg() para entradas análogas
  mb.addIreg(SENSOR_IREG);

  //este método imprime el tiempo desde que se inició el programa
  ts = millis();

  //establecemos el pin que queremos como salida
  pinMode(ledPin, OUTPUT);
  mb.addCoil(LED_COIL);
}
```
<!--  -->

---

<!--  -->
#### Código de ejecución Read/Write sobre los offsets
Ahora, si hablamos del código de ejecución en lazo, primero se hará que el `ESP32` revise cada 1 segundo el estado de la salida del sensor de llama del circuito y que imprima esa información en el offset indicado para que cualquier cliente pueda consultar esa información a tiempo real. Este estado se convierte a un valor binario, mediante código, para que pueda ser comprendido de mejor manera por parte del usuario del cliente.  
<!--  -->

---

<!--  -->
También, el código contempla un LED y un Buzzer ubicados en el PIN 23 de la tarjeta de desarrollo `ESP32` en el circuito, que están a la espera de que el usuario de que el offset 100 cambie su estado de 0 a 1 y escribir sobre el offset el nuevo estado y con esto emitir una señal y para activar el LED y el Buzzer que funcionarán como una alarma audiovisual.
<!--  -->

---

<!--  -->
```cpp
void loop() {

  //La lectura se dará cada 1 segundo

  mb.task();
    if (millis() > ts + 1000) {
      ts = millis();
      if (analogRead(A0) > 0) {
        mb.Ireg(SENSOR_IREG, 1);
      }
      else {
        mb.Ireg(SENSOR_IREG, analogRead(A0));
      }
    }
  //Empezamos el método para escribir en el output de manera binaria
  digitalWrite(ledPin, mb.Coil(LED_COIL));
  delay(10);

}
```
<!--  -->

---

<!--  -->
## 5. Uso del protocolo con un GUI *cliente*

Siguiendo el alcance del proyecto, se desarrolló iterfaz gráfica en lenguaje `C#` utilizando el IDE de [Visual Studio](https://visualstudio.microsoft.com/es/), ya que este facilita el desarrollo de *GUI* con los *Windows Forms* y tiene disponible muchas librerías de trabajo.  

Para utilizar nuestra *GUI* como `Cliente Modbus`  se hace uso de la librería  [EasyModbus](http://easymodbustcp.net/en/), la cual provee métodos para manipular datos con el formato del protocolo. Esta librería se puede añadir al proyecto dentro de Visual Studio usando el buscador integrado de [NuGet Packages](https://www.nuget.org/packages).
<!--  -->

---

<!--  -->
![GUI_Dev](https://i.imgur.com/TDWDE1c.png)

*Entorno de desarrollo de interfaz con Windows Form.*
<!--  -->

---

<!--  -->
### El código
#### Librerías, Clase y Constructor
```csharp
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
        // Otros métodos de la aplicación
    }
}
```
<!--  -->

---

<!--  -->
#### Métodos de control
Los métodos de control son aquellos que se llaman por la aplicación al darle click a cada uno de los objetos que componen la interfaz. En esta aplicación todos los botones de iteracción corresponden a un método de control.  
<!--  -->

---

<!--  -->
> Botón de conexión con servidor.

```csharp
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
```
<!--  -->

---

<!--  -->
> Botón de desconexión con el servidor.

```csharp
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
```
<!--  -->

---

<!--  -->
> Método para encender la alarma de forma manual.

```csharp
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
```
<!--  -->

---

<!--  -->
> Botón para apagar la alarma de forma manual.

```csharp
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
```
<!--  -->

---

<!--  -->
> Método para "conectar" el sensor de flama.

```csharp
// Método para tomar "conectar" el sensor de flama
        private void detectorOnBtn_Click(object sender, EventArgs e)
        {
            // Si tenemos conexión a servidor
            if (modbusClient.Connected)
            {
                // Comienza el timer y toma de datos
                timer1.Start();
                // Visibilidad de botones
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
```
<!--  -->

---

<!--  -->
> Método para desconectar el sensor de flama.

```csharp
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
```
<!--  -->

---

<!--  -->
#### Método de censado
Para leer el *input register* del servidor Modbus se utiliza el método de librería `ReadInputRegisters(address,amount)`, pero este método no se puede llamar de forma muy seguida, ya que fácilmente puede saturar el medio de comunicación.  

Para lidiar con esto se tiene dos opciones:
1. Hacer una solicitud manual una única vez (por ejemplo, a travez de un botón).
2. Hacer solicitudes automáticas en un intervalo de tiempo.  
<!--  -->

---

<!--  -->
Para implementar el segundo punto, se hace uso de la clase `Timer` que `C#` y [Visual Studio](https://visualstudio.microsoft.com/es/) tienen disponible.

```csharp
//  Método para ejecutar una función con cada tick de tiempo (1.5 s)
        private void timer1_Tick(object sender, EventArgs e)
        {
            ReadFlameData();
        }
```

```csharp    
// Método para lectura de holding register @200
        private void ReadFlameData()
        {
            // Si el sensor está armado
            if (SensorStatus)
            {
                int[] lectura;
                // Método Modbus para lectura de registro de entrada
                lectura = modbusClient.ReadInputRegisters(200, 1);
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
```
<!--  -->

---

<!--  -->
#### Métodos auxiliares de control
Estos son métodos que se encargan de controlar funciones secundarias dentro de la aplicación.  

>Control de sonido de alerta en la aplicación.
```csharp
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
            else if (!PlaySound)
            {
                audio.Stop();
                // Indicador de proceso
                SoundPlaying = false;
            }
        }
```
<!--  -->

---

<!--  -->
>Control de la visibilidad de botones de la aplicación.

```csharp
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
```
<!--  -->

---

<!--  -->
>Control de feedback visual en la aplicación.

```csharp
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
```
<!--  -->

---

<!--  -->
>Control de feedback visual en la aplicación.
```csharp
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
```
<!--  -->

---

<!--  -->
## 6. Video Demonstración
<iframe width="2543" height="1120" src="https://www.youtube.com/embed/r1ZYMd3zPPk" title="Prueba Proyecto Modbus TCP/IP con ESP32" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
<!--  -->

---

<!--  -->
## 7. Referencias y más información

* [1]"What is Modbus and How does it work? | Schneider Electric USA,"   Se, https://www.se.com/us/en/faqs/FA168406/#:~:text=Modbus%20is%20a%20serial%20communication,lines%20between%20electronic%20devices.
* [2]"MODBUS Application Protocol 1 1 b,"   Modbus, https://modbus.org/docs/Modbus_Application_Protocol_V1_1b.pdf.
* [3]"MODBUS Messaging Implementation Guide 1 0 b,"   Modbus, https://www.modbus.org/docs/Modbus_Messaging_Implementation_Guide_V1_0b.pdf.