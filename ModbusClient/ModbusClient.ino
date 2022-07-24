#ifdef ESP8266
 #include <ESP8266WiFi.h>
#else
 #include <WiFi.h>
#endif
#include "ModbusIP_ESP8266.h"

const int REG = 100;               // Se establece la dirección del Holding Register
IPAddress remote(192, 168, 1, 8);  // Dirección IP del servidor
const int LOOP_COUNT = 10

ModbusIP mb;  // Declara objeto de tipo ModbusIP

void setup() {
  Serial.begin(115200); // Puerto serial con velocidad de 115200 baudios
 
  WiFi.begin("Familia Berrocal", "4v4v723385a5"); // Información red WiFi
  
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
 
  Serial.println("");
  Serial.println("Conexión WiFi exitosa");  
  Serial.println("Dirección IP: ");
  Serial.println(WiFi.localIP());

  mb.client(); //Inicializa el ESP32 como cliente
}

uint16_t res = 0;
uint8_t show = LOOP_COUNT;

void loop() {
  if (mb.isConnected(remote)) {       // Revisa si tiene conexión Modbus con servidor
    mb.readHreg(remote, REG, &res);  //Lee un Holding Register en la dirección asignada en la IP remota
  } else {
    mb.connect(remote);           //Intenta reconectar si no tiene conexión
  }
  mb.task();                      // Ejecuta funciones del cliente Modbus
  delay(100);                     // Intervalo
  if (!show--) {                   // Se muestran los resultados de esta manera cada segundo, también se puede usar milis
    Serial.println(res);
    show = LOOP_COUNT;
  }
}
