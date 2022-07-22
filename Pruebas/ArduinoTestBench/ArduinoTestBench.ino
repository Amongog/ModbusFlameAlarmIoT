//Librerias
#include<Servo.h>

// Variables
String data;            // Guarda el string
char d1;                // Guarda el 1er caracter del string
String x;               // Valor string del angulo del servo
int servoval;           // Angulo servo int
Servo s1;               // Servo
int ledval;             // Intensidad LED

void setup() {
  //  Abre el puerto serial cuando el programa se ejecuta
  Serial.begin(9600);
  pinMode(13, OUTPUT);
  pinMode(3, OUTPUT);
  s1.attach(9);         // Salida 9 para el servo
}

void loop() {
  // Si el puerto serial está disponible
  if (Serial.available())
  {
    data = Serial.readString();
    d1 = data.charAt(0);
    switch (d1) {
      case 'A':
        digitalWrite(13, HIGH);
        break;

      case 'a':
        digitalWrite(13, LOW);
        break;

      case 'S':
        x = data.substring(1);    // Empieza a leer string a partir de el segundo caracter
        servoval = x.toInt();
        s1.write(servoval);
        delay(100);
        break;

      case 'B':
          x = data.substring(1);
          ledval = x.toInt();
          digitalWrite(3, ledval);
    }
  }
}
