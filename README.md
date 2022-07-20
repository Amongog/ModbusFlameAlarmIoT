# Modbus IoT con ESP32
| Integrante | Carné |
| ------ | ------ |
| Samuel Berrocal Soto | B40993 |
| Kendall Cruz Sosa | B4... |

## Objetivos
1. Implementar el protocolo Modbus TCP/IP para conectar un cliente (PC) con un servidor (ESP32) haciendo uso de la librería ArduinoModbus (C++). 
2. Diseñar interfaz (GUI) para el cliente que muestre valores de sensores en el servidor en tiempo real, y permita enviar señales de control al servidor para accionar salidas. 

## Alcance
Este proyecto busca ilustrar el potencial del protocolo Modbus para aplicaciones IoT. 
Se utilizará un módulo ESP32 para utilizar como servidor, el cual correrá un código en C++ utilizando la librería ArduinoModbus.  Este módulo permite una conexión inalámbrica de bajo consumo energético con el cliente a un bajo costo.  Este módulo también facilitará el uso de la variante del protocolo Modbus TCP/IP.

Como segunda parte de este proyecto se plantea desarrollar una interfaz para que el usuario pueda controlar y monitorear en tiempo real los servidores. Se utilizará **C#** con _Visual Studio_ para realizar la GUI.