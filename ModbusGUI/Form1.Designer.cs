namespace ModbusGUI
{
    partial class ModbusClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModbusClientForm));
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fireDetected = new System.Windows.Forms.Label();
            this.alarmOffBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.alarmOnBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.alarmGIF = new System.Windows.Forms.PictureBox();
            this.connectBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.disconnectBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.flameGIF = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.activarDetector = new System.Windows.Forms.Label();
            this.detectorOnBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.detectorOffBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.desactivarDetector = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.alarmOffBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmOnBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmGIF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.disconnectBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flameGIF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detectorOnBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detectorOffBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(12, 28);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(133, 22);
            this.textBoxIP.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dirección IP Servidor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Encender Alarma";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Apagar Alarma";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fireDetected
            // 
            this.fireDetected.AutoSize = true;
            this.fireDetected.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fireDetected.Location = new System.Drawing.Point(145, 191);
            this.fireDetected.Name = "fireDetected";
            this.fireDetected.Size = new System.Drawing.Size(150, 19);
            this.fireDetected.TabIndex = 10;
            this.fireDetected.Text = "¡FUEGO DETECTADO!";
            this.fireDetected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fireDetected.Visible = false;
            // 
            // alarmOffBtn
            // 
            this.alarmOffBtn.BackColor = System.Drawing.Color.Transparent;
            this.alarmOffBtn.Image = ((System.Drawing.Image)(resources.GetObject("alarmOffBtn.Image")));
            this.alarmOffBtn.ImageActive = null;
            this.alarmOffBtn.Location = new System.Drawing.Point(31, 153);
            this.alarmOffBtn.Name = "alarmOffBtn";
            this.alarmOffBtn.Size = new System.Drawing.Size(45, 43);
            this.alarmOffBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.alarmOffBtn.TabIndex = 7;
            this.alarmOffBtn.TabStop = false;
            this.alarmOffBtn.Zoom = 10;
            this.alarmOffBtn.Click += new System.EventHandler(this.alarmOffBtn_Click);
            // 
            // alarmOnBtn
            // 
            this.alarmOnBtn.BackColor = System.Drawing.Color.Transparent;
            this.alarmOnBtn.Image = ((System.Drawing.Image)(resources.GetObject("alarmOnBtn.Image")));
            this.alarmOnBtn.ImageActive = null;
            this.alarmOnBtn.Location = new System.Drawing.Point(31, 83);
            this.alarmOnBtn.Name = "alarmOnBtn";
            this.alarmOnBtn.Size = new System.Drawing.Size(45, 43);
            this.alarmOnBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.alarmOnBtn.TabIndex = 6;
            this.alarmOnBtn.TabStop = false;
            this.alarmOnBtn.Zoom = 10;
            this.alarmOnBtn.Click += new System.EventHandler(this.alarmOnBtn_Click);
            // 
            // alarmGIF
            // 
            this.alarmGIF.Image = global::ModbusGUI.Properties.Resources.alarma_slow;
            this.alarmGIF.Location = new System.Drawing.Point(125, 92);
            this.alarmGIF.Name = "alarmGIF";
            this.alarmGIF.Size = new System.Drawing.Size(83, 87);
            this.alarmGIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.alarmGIF.TabIndex = 4;
            this.alarmGIF.TabStop = false;
            this.alarmGIF.Visible = false;
            // 
            // connectBtn
            // 
            this.connectBtn.BackColor = System.Drawing.Color.Transparent;
            this.connectBtn.Image = ((System.Drawing.Image)(resources.GetObject("connectBtn.Image")));
            this.connectBtn.ImageActive = null;
            this.connectBtn.Location = new System.Drawing.Point(147, 15);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(45, 43);
            this.connectBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.connectBtn.TabIndex = 0;
            this.connectBtn.TabStop = false;
            this.connectBtn.Zoom = 10;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.BackColor = System.Drawing.Color.Transparent;
            this.disconnectBtn.Image = ((System.Drawing.Image)(resources.GetObject("disconnectBtn.Image")));
            this.disconnectBtn.ImageActive = null;
            this.disconnectBtn.Location = new System.Drawing.Point(147, 15);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(45, 43);
            this.disconnectBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.disconnectBtn.TabIndex = 1;
            this.disconnectBtn.TabStop = false;
            this.disconnectBtn.Zoom = 10;
            this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
            // 
            // flameGIF
            // 
            this.flameGIF.Image = global::ModbusGUI.Properties.Resources.flama;
            this.flameGIF.Location = new System.Drawing.Point(214, 9);
            this.flameGIF.Name = "flameGIF";
            this.flameGIF.Size = new System.Drawing.Size(137, 205);
            this.flameGIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.flameGIF.TabIndex = 5;
            this.flameGIF.TabStop = false;
            this.flameGIF.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.ReadFlameData);
            // 
            // activarDetector
            // 
            this.activarDetector.AutoSize = true;
            this.activarDetector.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activarDetector.Location = new System.Drawing.Point(237, 12);
            this.activarDetector.Name = "activarDetector";
            this.activarDetector.Size = new System.Drawing.Size(90, 13);
            this.activarDetector.TabIndex = 11;
            this.activarDetector.Text = "Activar Detector";
            this.activarDetector.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // detectorOnBtn
            // 
            this.detectorOnBtn.BackColor = System.Drawing.Color.Transparent;
            this.detectorOnBtn.Image = ((System.Drawing.Image)(resources.GetObject("detectorOnBtn.Image")));
            this.detectorOnBtn.ImageActive = null;
            this.detectorOnBtn.Location = new System.Drawing.Point(264, 28);
            this.detectorOnBtn.Name = "detectorOnBtn";
            this.detectorOnBtn.Size = new System.Drawing.Size(32, 30);
            this.detectorOnBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.detectorOnBtn.TabIndex = 12;
            this.detectorOnBtn.TabStop = false;
            this.detectorOnBtn.Zoom = 10;
            this.detectorOnBtn.Click += new System.EventHandler(this.detectorOnBtn_Click);
            // 
            // detectorOffBtn
            // 
            this.detectorOffBtn.BackColor = System.Drawing.Color.Transparent;
            this.detectorOffBtn.Image = ((System.Drawing.Image)(resources.GetObject("detectorOffBtn.Image")));
            this.detectorOffBtn.ImageActive = null;
            this.detectorOffBtn.Location = new System.Drawing.Point(264, 28);
            this.detectorOffBtn.Name = "detectorOffBtn";
            this.detectorOffBtn.Size = new System.Drawing.Size(32, 30);
            this.detectorOffBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.detectorOffBtn.TabIndex = 13;
            this.detectorOffBtn.TabStop = false;
            this.detectorOffBtn.Zoom = 10;
            this.detectorOffBtn.Click += new System.EventHandler(this.detectorOffBtn_Click);
            // 
            // desactivarDetector
            // 
            this.desactivarDetector.AutoSize = true;
            this.desactivarDetector.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desactivarDetector.Location = new System.Drawing.Point(228, 12);
            this.desactivarDetector.Name = "desactivarDetector";
            this.desactivarDetector.Size = new System.Drawing.Size(107, 13);
            this.desactivarDetector.TabIndex = 14;
            this.desactivarDetector.Text = "Desactivar Detector";
            this.desactivarDetector.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.desactivarDetector.Visible = false;
            // 
            // ModbusClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(358, 214);
            this.Controls.Add(this.activarDetector);
            this.Controls.Add(this.desactivarDetector);
            this.Controls.Add(this.detectorOnBtn);
            this.Controls.Add(this.detectorOffBtn);
            this.Controls.Add(this.fireDetected);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.alarmOffBtn);
            this.Controls.Add(this.alarmOnBtn);
            this.Controls.Add(this.alarmGIF);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.disconnectBtn);
            this.Controls.Add(this.flameGIF);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModbusClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modbus Client";
            ((System.ComponentModel.ISupportInitialize)(this.alarmOffBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmOnBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmGIF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.disconnectBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flameGIF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detectorOnBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detectorOffBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuImageButton connectBtn;
        private Bunifu.Framework.UI.BunifuImageButton disconnectBtn;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox alarmGIF;
        private System.Windows.Forms.PictureBox flameGIF;
        private Bunifu.Framework.UI.BunifuImageButton alarmOnBtn;
        private Bunifu.Framework.UI.BunifuImageButton alarmOffBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label fireDetected;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label activarDetector;
        private Bunifu.Framework.UI.BunifuImageButton detectorOnBtn;
        private Bunifu.Framework.UI.BunifuImageButton detectorOffBtn;
        private System.Windows.Forms.Label desactivarDetector;
    }
}

