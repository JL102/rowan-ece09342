namespace Thingspeak_Tutorial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serial_start = new System.Windows.Forms.Button();
            this.serial_end = new System.Windows.Forms.Button();
            this.tsChannelOutput1 = new System.Windows.Forms.Label();
            this.read_channel = new System.Windows.Forms.Button();
            this.current_data = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.current_data_text = new System.Windows.Forms.TextBox();
            this.ComInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tsChannelOutput2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.currentAverageTemp = new System.Windows.Forms.Label();
            this.currentAverageLight = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // serial_start
            // 
            this.serial_start.FlatAppearance.BorderSize = 0;
            this.serial_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.serial_start.Font = new System.Drawing.Font("Segoe UI Light", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serial_start.Location = new System.Drawing.Point(115, 65);
            this.serial_start.Name = "serial_start";
            this.serial_start.Size = new System.Drawing.Size(417, 83);
            this.serial_start.TabIndex = 0;
            this.serial_start.Text = "START SERIAL";
            this.serial_start.UseVisualStyleBackColor = true;
            this.serial_start.Click += new System.EventHandler(this.serial_start_Click);
            // 
            // serial_end
            // 
            this.serial_end.Enabled = false;
            this.serial_end.FlatAppearance.BorderSize = 0;
            this.serial_end.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.serial_end.Font = new System.Drawing.Font("Segoe UI Light", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serial_end.Location = new System.Drawing.Point(611, 65);
            this.serial_end.Name = "serial_end";
            this.serial_end.Size = new System.Drawing.Size(417, 83);
            this.serial_end.TabIndex = 1;
            this.serial_end.Text = "STOP SERIAL";
            this.serial_end.UseVisualStyleBackColor = true;
            this.serial_end.Click += new System.EventHandler(this.serial_end_Click);
            // 
            // tsChannelOutput1
            // 
            this.tsChannelOutput1.AutoSize = true;
            this.tsChannelOutput1.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.tsChannelOutput1.Location = new System.Drawing.Point(689, 240);
            this.tsChannelOutput1.Name = "tsChannelOutput1";
            this.tsChannelOutput1.Size = new System.Drawing.Size(62, 46);
            this.tsChannelOutput1.TabIndex = 2;
            this.tsChannelOutput1.Text = "---";
            this.tsChannelOutput1.Click += new System.EventHandler(this.currentData_Click);
            // 
            // read_channel
            // 
            this.read_channel.FlatAppearance.BorderSize = 0;
            this.read_channel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.read_channel.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.read_channel.Location = new System.Drawing.Point(115, 221);
            this.read_channel.Name = "read_channel";
            this.read_channel.Size = new System.Drawing.Size(417, 84);
            this.read_channel.TabIndex = 3;
            this.read_channel.Text = "READ IN TS CHANNEL";
            this.read_channel.UseVisualStyleBackColor = true;
            this.read_channel.Click += new System.EventHandler(this.read_channel_Click);
            // 
            // current_data
            // 
            this.current_data.AutoSize = true;
            this.current_data.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.current_data.Location = new System.Drawing.Point(198, 357);
            this.current_data.Name = "current_data";
            this.current_data.Size = new System.Drawing.Size(241, 46);
            this.current_data.TabIndex = 4;
            this.current_data.Text = "CURRENT DATA";
            this.current_data.Click += new System.EventHandler(this.label2_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // current_data_text
            // 
            this.current_data_text.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.current_data_text.Location = new System.Drawing.Point(682, 357);
            this.current_data_text.Name = "current_data_text";
            this.current_data_text.Size = new System.Drawing.Size(272, 34);
            this.current_data_text.TabIndex = 5;
            this.current_data_text.TextChanged += new System.EventHandler(this.currentDataText_TextChanged);
            // 
            // ComInput
            // 
            this.ComInput.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.ComInput.Location = new System.Drawing.Point(365, 28);
            this.ComInput.Name = "ComInput";
            this.ComInput.Size = new System.Drawing.Size(100, 34);
            this.ComInput.TabIndex = 6;
            this.ComInput.Text = "COM3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label2.Location = new System.Drawing.Point(159, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "Enter COM number:";
            // 
            // tsChannelOutput2
            // 
            this.tsChannelOutput2.AutoSize = true;
            this.tsChannelOutput2.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.tsChannelOutput2.Location = new System.Drawing.Point(871, 240);
            this.tsChannelOutput2.Name = "tsChannelOutput2";
            this.tsChannelOutput2.Size = new System.Drawing.Size(62, 46);
            this.tsChannelOutput2.TabIndex = 8;
            this.tsChannelOutput2.Text = "---";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label1.Location = new System.Drawing.Point(692, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Light";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label3.Location = new System.Drawing.Point(837, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 28);
            this.label3.TabIndex = 10;
            this.label3.Text = "Temperature";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.label4.Location = new System.Drawing.Point(174, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 46);
            this.label4.TabIndex = 11;
            this.label4.Text = "CURRENT AVERAGE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label5.Location = new System.Drawing.Point(837, 441);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 28);
            this.label5.TabIndex = 15;
            this.label5.Text = "Temperature";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label6.Location = new System.Drawing.Point(692, 441);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 28);
            this.label6.TabIndex = 14;
            this.label6.Text = "Light";
            // 
            // currentAverageTemp
            // 
            this.currentAverageTemp.AutoSize = true;
            this.currentAverageTemp.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.currentAverageTemp.Location = new System.Drawing.Point(871, 484);
            this.currentAverageTemp.Name = "currentAverageTemp";
            this.currentAverageTemp.Size = new System.Drawing.Size(62, 46);
            this.currentAverageTemp.TabIndex = 13;
            this.currentAverageTemp.Text = "---";
            // 
            // currentAverageLight
            // 
            this.currentAverageLight.AutoSize = true;
            this.currentAverageLight.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.currentAverageLight.Location = new System.Drawing.Point(689, 484);
            this.currentAverageLight.Name = "currentAverageLight";
            this.currentAverageLight.Size = new System.Drawing.Size(62, 46);
            this.currentAverageLight.TabIndex = 12;
            this.currentAverageLight.Text = "---";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1085, 673);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.currentAverageTemp);
            this.Controls.Add(this.currentAverageLight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsChannelOutput2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ComInput);
            this.Controls.Add(this.current_data_text);
            this.Controls.Add(this.current_data);
            this.Controls.Add(this.read_channel);
            this.Controls.Add(this.tsChannelOutput1);
            this.Controls.Add(this.serial_end);
            this.Controls.Add(this.serial_start);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button serial_start;
        private System.Windows.Forms.Button serial_end;
        private System.Windows.Forms.Label tsChannelOutput1;
        private System.Windows.Forms.Button read_channel;
        private System.Windows.Forms.Label current_data;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox current_data_text;
        private System.Windows.Forms.TextBox ComInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tsChannelOutput2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label currentAverageTemp;
        private System.Windows.Forms.Label currentAverageLight;
    }
}

