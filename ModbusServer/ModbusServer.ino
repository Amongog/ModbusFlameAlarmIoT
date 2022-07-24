#ifdef ESP8266
 #include <ESP8266WiFi.h>
#else //ESP32
 #include <WiFi.h>
#endif
#include "ModbusIP_ESP8266.h"

//Modbus Registers Offsets
const int SENSOR_IREG = 101; //Aquí tenemos la ubicación de la información del sensor de llama
const int LED_COIL = 100; //Aquí tenemos la ubicación de la información para el output
//Used Pins
const int ledPin = 23; //GPIO23

//Llamamos al objeto ModbusIP
ModbusIP mb;


long ts;


void setup() {
    //velocidad máxima de baudios
    Serial.begin(115200);
    //Información de la red a la que se desea conectar
    WiFi.begin("ARRIS-4A42", "BNX6C1301775");
    //Método para que imprima la info en caso de conectarse
    while (WiFi.status() != WL_CONNECTED) {
        delay(500);
        Serial.print(".");
    }

    Serial.println("");
    Serial.println("WiFi connected");  
    Serial.println("IP address: ");
    Serial.println(WiFi.localIP()); //imprime la IP local del servidor
    
    

    mb.server();    //Encendemos el servidor Modbus IP
    // Agregamos el registro SENSOR_IREG
    // Se debe usaraddIreg() para entradas análogas
    mb.addIreg(SENSOR_IREG);

    //este método imprime el tiempo desde que se inició el programa
    ts = millis();

    //establecemos el pin que queremos como salida
    pinMode(ledPin, OUTPUT);
    mb.addCoil(LED_COIL);
}

void loop() {
   //Empezamos el codigo para escribir en el output de manera binaria
   mb.task();
   digitalWrite(ledPin, mb.Coil(LED_COIL));
   delay(10);
   //La lectura se dará cada 2 segundos
   if (millis() > ts + 2000) {
       ts = millis();
       //Setting raw value (0-1024)
       mb.Ireg(SENSOR_IREG, analogRead(A0));
   }
   delay(10);

}
