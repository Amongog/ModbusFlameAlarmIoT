#ifdef ESP8266
 #include <ESP8266WiFi.h>
#else //ESP32
 #include <WiFi.h>
#endif
#include "ModbusIP_ESP8266.h"

//Modbus Registers Offsets
const int LED_COIL = 100;
//Used Pins
const int ledPin = 0; //GPIO0

//ModbusIP object
ModbusIP mb;
  
void setup() {
  Serial.begin(115200);
 
  WiFi.begin("SOSA 2.4G", "24453225");
  
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
 
  Serial.println("");
  Serial.println("WiFi connected");  
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());

  mb.server();

  pinMode(ledPin, OUTPUT);
  mb.addCoil(LED_COIL);
}
 
void loop() {
   //Call once inside loop() - all magic here
   mb.task();

   //Attach ledPin to LED_COIL register
   digitalWrite(ledPin, mb.Coil(LED_COIL));
   delay(10);
}
