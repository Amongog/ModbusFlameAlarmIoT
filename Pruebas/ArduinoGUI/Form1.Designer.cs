namespace ArduinoGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.onButton = new System.Windows.Forms.Button();
            this.offButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ServoAngle = new System.Windows.Forms.Button();
            this.BlueVal = new System.Windows.Forms.TrackBar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SendBlueVal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BlueVal)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            // 
            // onButton
            // 
            this.onButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.onButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onButton.Location = new System.Drawing.Point(354, 29);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(86, 23);
            this.onButton.TabIndex = 0;
            this.onButton.Text = "Turn LED ON";
            this.onButton.UseVisualStyleBackColor = false;
            this.onButton.Click += new System.EventHandler(this.onButton_Click);
            // 
            // offButton
            // 
            this.offButton.BackColor = System.Drawing.Color.Red;
            this.offButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offButton.Location = new System.Drawing.Point(354, 58);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(86, 23);
            this.offButton.TabIndex = 1;
            this.offButton.Text = "Turn LED OFF";
            this.offButton.UseVisualStyleBackColor = false;
            this.offButton.Click += new System.EventHandler(this.offButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(354, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 22);
            this.textBox1.TabIndex = 2;
            // 
            // ServoAngle
            // 
            this.ServoAngle.Location = new System.Drawing.Point(354, 137);
            this.ServoAngle.Name = "ServoAngle";
            this.ServoAngle.Size = new System.Drawing.Size(86, 23);
            this.ServoAngle.TabIndex = 3;
            this.ServoAngle.Text = "Send Angle";
            this.ServoAngle.UseVisualStyleBackColor = true;
            this.ServoAngle.Click += new System.EventHandler(this.ServoAngle_Click);
            // 
            // BlueVal
            // 
            this.BlueVal.Location = new System.Drawing.Point(12, 36);
            this.BlueVal.Maximum = 255;
            this.BlueVal.Name = "BlueVal";
            this.BlueVal.Size = new System.Drawing.Size(255, 45);
            this.BlueVal.TabIndex = 4;
            this.BlueVal.TickFrequency = 10;
            this.BlueVal.Scroll += new System.EventHandler(this.BlueVal_Scroll);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // SendBlueVal
            // 
            this.SendBlueVal.BackColor = System.Drawing.Color.Blue;
            this.SendBlueVal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendBlueVal.ForeColor = System.Drawing.Color.White;
            this.SendBlueVal.Location = new System.Drawing.Point(273, 29);
            this.SendBlueVal.Name = "SendBlueVal";
            this.SendBlueVal.Size = new System.Drawing.Size(75, 52);
            this.SendBlueVal.TabIndex = 6;
            this.SendBlueVal.Text = "Send Blue Value";
            this.SendBlueVal.UseVisualStyleBackColor = false;
            this.SendBlueVal.Click += new System.EventHandler(this.SendBlueVal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 300);
            this.Controls.Add(this.SendBlueVal);
            this.Controls.Add(this.BlueVal);
            this.Controls.Add(this.ServoAngle);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.offButton);
            this.Controls.Add(this.onButton);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.BlueVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.Button offButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ServoAngle;
        private System.Windows.Forms.TrackBar BlueVal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button SendBlueVal;
    }
}

