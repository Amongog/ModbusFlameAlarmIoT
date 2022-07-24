/*
  Modbus-Arduino Example - Master Modbus IP Client (ESP8266/ESP32)
  Read Holding Register from Server device
  (c)2018 Alexander Emelianov (a.m.emelianov@gmail.com)
  https://github.com/emelianov/modbus-esp8266
*/

#ifdef ESP8266
 #include <ESP8266WiFi.h>
#else
 #include <WiFi.h>
#endif
#include "ModbusIP_ESP8266.h"

const int REG = 100;               // Modbus dirección o Offset del holding register
IPAddress remote(192, 168, 0, 10);  // Esta es la dirección de un dispositivo esclavo, use ModBus Slave (Asigne aquí la dirección IP de su PC donde está instalado este software)
const int LOOP_COUNT = 10;

ModbusIP mb;  //ModbusIP object

void setup() {
  Serial.begin(115200);
 
  WiFi.begin("linksys"); //Este es el nombre del SSID, se puede añadir el password en el segundo argumento
  
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
 
  Serial.println("");
  Serial.println("WiFi connected");  
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());

  mb.client(); //Inicio en modo cliente de ESP32
}

uint16_t res = 0;
uint8_t show = LOOP_COUNT;

void loop() {
  if (mb.isConnected(remote)) {   // Check if connection to Modbus Slave is established
    mb.readHreg(remote, REG, &res);  //Leer un holding register en la dirección asignada en la IP remota.
  } else {
    mb.connect(remote);           //REconectar si hay problema
  }
  mb.task();                      // Ejecutar funciones de cliente modbus
  delay(100);                     // Pulling interval
  if (!show--) {                   // Se muestran los resultados de esta manera cada segundo, también se puede usar milis
    Serial.println(res);
    show = LOOP_COUNT;
  }
}
