using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoGUI
{
    public partial class Form1 : Form
    {
        private string blue;        // Variable para intensidad de luz azul
        public Form1()
        {
            InitializeComponent();
            // Inicializa y abre el puerto serial cuando se ejecuta
            serialPort1.Open();
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            // Envia comando al arduino para encender el pin 13 con una  "A"
            serialPort1.Write("A");
        }

        private void offButton_Click(object sender, EventArgs e)
        {
            // Envia comando al arduio para apagar el pin 13 con una "a"
            serialPort1.Write("a");
        }

        private void ServoAngle_Click(object sender, EventArgs e)
        {
            // Enviar valor de ángulo al servo
            string m1 = "S" + textBox1.Text;
            serialPort1.Write(m1);
        }

        private void BlueVal_Scroll(object sender, EventArgs e)
        {
            //  Guarda el valor final del deslizador
            blue = "B" + BlueVal.Value;
        }

        private void SendBlueVal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(blue))
            {
                blue = "B0";
            }
            serialPort1.Write(blue);        // Else
        }
    }
}
 