namespace HoribaBE140AD.EmulatorApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new System.Windows.Forms.Label();
            cmbPorts = new System.Windows.Forms.ComboBox();
            txbSerial = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            chbLowFlow = new System.Windows.Forms.CheckBox();
            label11 = new System.Windows.Forms.Label();
            trbHC = new System.Windows.Forms.TrackBar();
            lblHC = new System.Windows.Forms.Label();
            lblCO = new System.Windows.Forms.Label();
            trbCO = new System.Windows.Forms.TrackBar();
            label15 = new System.Windows.Forms.Label();
            lblCO2 = new System.Windows.Forms.Label();
            trbCO2 = new System.Windows.Forms.TrackBar();
            label17 = new System.Windows.Forms.Label();
            lblO2 = new System.Windows.Forms.Label();
            trbO2 = new System.Windows.Forms.TrackBar();
            label19 = new System.Windows.Forms.Label();
            ptbConnect = new System.Windows.Forms.PictureBox();
            btnUpdate = new System.Windows.Forms.Button();
            btnRecord = new System.Windows.Forms.Button();
            btnUpdateMeasurements = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            cmbOptions = new System.Windows.Forms.ComboBox();
            chbZeroProgress = new System.Windows.Forms.CheckBox();
            chbWarming = new System.Windows.Forms.CheckBox();
            chbLeakInProgress = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)trbHC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trbCO).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trbCO2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trbO2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptbConnect).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            label1.Location = new System.Drawing.Point(9, 38);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 19);
            label1.TabIndex = 0;
            label1.Text = "Puerto";
            // 
            // cmbPorts
            // 
            cmbPorts.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            cmbPorts.FormattingEnabled = true;
            cmbPorts.Location = new System.Drawing.Point(62, 34);
            cmbPorts.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            cmbPorts.Name = "cmbPorts";
            cmbPorts.Size = new System.Drawing.Size(63, 27);
            cmbPorts.TabIndex = 1;
            // 
            // txbSerial
            // 
            txbSerial.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            txbSerial.Location = new System.Drawing.Point(186, 35);
            txbSerial.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            txbSerial.Name = "txbSerial";
            txbSerial.Size = new System.Drawing.Size(87, 27);
            txbSerial.TabIndex = 5;
            txbSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            label3.Location = new System.Drawing.Point(131, 35);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 29);
            label3.TabIndex = 4;
            label3.Text = "Serial";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbLowFlow
            // 
            chbLowFlow.AutoSize = true;
            chbLowFlow.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chbLowFlow.Location = new System.Drawing.Point(18, 387);
            chbLowFlow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            chbLowFlow.Name = "chbLowFlow";
            chbLowFlow.Size = new System.Drawing.Size(79, 23);
            chbLowFlow.TabIndex = 6;
            chbLowFlow.Text = "Flujo bajo";
            chbLowFlow.UseVisualStyleBackColor = true;
            chbLowFlow.CheckedChanged += chbLowFlow_CheckedChanged;
            // 
            // label11
            // 
            label11.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            label11.Location = new System.Drawing.Point(4, 155);
            label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(88, 28);
            label11.TabIndex = 9;
            label11.Text = "HC (ppm)";
            label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trbHC
            // 
            trbHC.Location = new System.Drawing.Point(96, 162);
            trbHC.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            trbHC.Maximum = 3600;
            trbHC.Name = "trbHC";
            trbHC.Size = new System.Drawing.Size(241, 45);
            trbHC.TabIndex = 10;
            trbHC.Scroll += trbHC_Scroll;
            // 
            // lblHC
            // 
            lblHC.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblHC.Location = new System.Drawing.Point(14, 183);
            lblHC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblHC.Name = "lblHC";
            lblHC.Size = new System.Drawing.Size(323, 34);
            lblHC.TabIndex = 13;
            lblHC.Text = "00000";
            lblHC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCO
            // 
            lblCO.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblCO.Location = new System.Drawing.Point(14, 239);
            lblCO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblCO.Name = "lblCO";
            lblCO.Size = new System.Drawing.Size(323, 34);
            lblCO.TabIndex = 16;
            lblCO.Text = "0.0";
            lblCO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trbCO
            // 
            trbCO.BackColor = System.Drawing.SystemColors.Control;
            trbCO.Location = new System.Drawing.Point(96, 220);
            trbCO.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            trbCO.Maximum = 500;
            trbCO.Name = "trbCO";
            trbCO.Size = new System.Drawing.Size(241, 45);
            trbCO.TabIndex = 15;
            trbCO.Scroll += trbCO_Scroll;
            // 
            // label15
            // 
            label15.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            label15.Location = new System.Drawing.Point(4, 212);
            label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(88, 34);
            label15.TabIndex = 14;
            label15.Text = "CO (%)";
            label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCO2
            // 
            lblCO2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblCO2.Location = new System.Drawing.Point(14, 292);
            lblCO2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblCO2.Name = "lblCO2";
            lblCO2.Size = new System.Drawing.Size(323, 34);
            lblCO2.TabIndex = 19;
            lblCO2.Text = "0.00";
            lblCO2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trbCO2
            // 
            trbCO2.Location = new System.Drawing.Point(96, 273);
            trbCO2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            trbCO2.Maximum = 2000;
            trbCO2.Name = "trbCO2";
            trbCO2.Size = new System.Drawing.Size(241, 45);
            trbCO2.TabIndex = 18;
            trbCO2.Scroll += trbCO2_Scroll;
            // 
            // label17
            // 
            label17.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            label17.Location = new System.Drawing.Point(4, 265);
            label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(88, 34);
            label17.TabIndex = 17;
            label17.Text = "CO2 (%)";
            label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblO2
            // 
            lblO2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblO2.Location = new System.Drawing.Point(14, 345);
            lblO2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblO2.Name = "lblO2";
            lblO2.Size = new System.Drawing.Size(323, 34);
            lblO2.TabIndex = 22;
            lblO2.Text = "0.0";
            lblO2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trbO2
            // 
            trbO2.Location = new System.Drawing.Point(96, 325);
            trbO2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            trbO2.Maximum = 2100;
            trbO2.Name = "trbO2";
            trbO2.Size = new System.Drawing.Size(241, 45);
            trbO2.TabIndex = 21;
            trbO2.Scroll += trbO2_Scroll;
            // 
            // label19
            // 
            label19.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            label19.Location = new System.Drawing.Point(4, 317);
            label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(88, 34);
            label19.TabIndex = 20;
            label19.Text = "O2 (%)";
            label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ptbConnect
            // 
            ptbConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            ptbConnect.Image = (System.Drawing.Image)resources.GetObject("ptbConnect.Image");
            ptbConnect.Location = new System.Drawing.Point(288, 31);
            ptbConnect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            ptbConnect.Name = "ptbConnect";
            ptbConnect.Size = new System.Drawing.Size(49, 49);
            ptbConnect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ptbConnect.TabIndex = 23;
            ptbConnect.TabStop = false;
            ptbConnect.Click += ptbConnect_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = System.Drawing.Color.Black;
            btnUpdate.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            btnUpdate.ForeColor = System.Drawing.Color.WhiteSmoke;
            btnUpdate.Location = new System.Drawing.Point(220, 439);
            btnUpdate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(89, 36);
            btnUpdate.TabIndex = 24;
            btnUpdate.Text = "Actualizar";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnRecord
            // 
            btnRecord.BackColor = System.Drawing.Color.Black;
            btnRecord.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            btnRecord.ForeColor = System.Drawing.Color.WhiteSmoke;
            btnRecord.Location = new System.Drawing.Point(34, 439);
            btnRecord.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new System.Drawing.Size(89, 36);
            btnRecord.TabIndex = 25;
            btnRecord.Text = "Grabar";
            btnRecord.UseVisualStyleBackColor = false;
            // 
            // btnUpdateMeasurements
            // 
            btnUpdateMeasurements.BackColor = System.Drawing.Color.Black;
            btnUpdateMeasurements.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            btnUpdateMeasurements.ForeColor = System.Drawing.Color.WhiteSmoke;
            btnUpdateMeasurements.Location = new System.Drawing.Point(127, 439);
            btnUpdateMeasurements.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            btnUpdateMeasurements.Name = "btnUpdateMeasurements";
            btnUpdateMeasurements.Size = new System.Drawing.Size(89, 36);
            btnUpdateMeasurements.TabIndex = 26;
            btnUpdateMeasurements.Text = "Sincronizar";
            btnUpdateMeasurements.UseVisualStyleBackColor = false;
            btnUpdateMeasurements.Click += btnUpdateMeasurements_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            label2.Location = new System.Drawing.Point(12, 80);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 19);
            label2.TabIndex = 27;
            label2.Text = "Opciones";
            // 
            // cmbOptions
            // 
            cmbOptions.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            cmbOptions.FormattingEnabled = true;
            cmbOptions.Location = new System.Drawing.Point(12, 107);
            cmbOptions.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            cmbOptions.Name = "cmbOptions";
            cmbOptions.Size = new System.Drawing.Size(325, 27);
            cmbOptions.TabIndex = 28;
            // 
            // chbZeroProgress
            // 
            chbZeroProgress.AutoSize = true;
            chbZeroProgress.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chbZeroProgress.Location = new System.Drawing.Point(101, 387);
            chbZeroProgress.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            chbZeroProgress.Name = "chbZeroProgress";
            chbZeroProgress.Size = new System.Drawing.Size(117, 23);
            chbZeroProgress.TabIndex = 29;
            chbZeroProgress.Text = "Cero en progreso";
            chbZeroProgress.UseVisualStyleBackColor = true;
            chbZeroProgress.CheckedChanged += chbZeroProgress_CheckedChanged;
            // 
            // chbWarming
            // 
            chbWarming.AutoSize = true;
            chbWarming.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chbWarming.Location = new System.Drawing.Point(220, 387);
            chbWarming.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            chbWarming.Name = "chbWarming";
            chbWarming.Size = new System.Drawing.Size(106, 23);
            chbWarming.TabIndex = 30;
            chbWarming.Text = "Calentamiento";
            chbWarming.UseVisualStyleBackColor = true;
            chbWarming.CheckedChanged += chbWarming_CheckedChanged;
            // 
            // chbLeakInProgress
            // 
            chbLeakInProgress.AutoSize = true;
            chbLeakInProgress.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chbLeakInProgress.Location = new System.Drawing.Point(18, 410);
            chbLeakInProgress.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            chbLeakInProgress.Name = "chbLeakInProgress";
            chbLeakInProgress.Size = new System.Drawing.Size(125, 23);
            chbLeakInProgress.TabIndex = 31;
            chbLeakInProgress.Text = "Fugas en progreso";
            chbLeakInProgress.UseVisualStyleBackColor = true;
            chbLeakInProgress.CheckedChanged += chbLeakInProgress_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(5F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(350, 486);
            Controls.Add(chbLeakInProgress);
            Controls.Add(chbWarming);
            Controls.Add(chbZeroProgress);
            Controls.Add(cmbOptions);
            Controls.Add(label2);
            Controls.Add(btnUpdateMeasurements);
            Controls.Add(txbSerial);
            Controls.Add(btnRecord);
            Controls.Add(btnUpdate);
            Controls.Add(ptbConnect);
            Controls.Add(lblO2);
            Controls.Add(trbO2);
            Controls.Add(label19);
            Controls.Add(lblCO2);
            Controls.Add(trbCO2);
            Controls.Add(label17);
            Controls.Add(lblCO);
            Controls.Add(trbCO);
            Controls.Add(label15);
            Controls.Add(lblHC);
            Controls.Add(trbHC);
            Controls.Add(label11);
            Controls.Add(chbLowFlow);
            Controls.Add(cmbPorts);
            Controls.Add(label1);
            Controls.Add(label3);
            Font = new System.Drawing.Font("Bahnschrift Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            Name = "Form1";
            Text = "Horiba BE140";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trbHC).EndInit();
            ((System.ComponentModel.ISupportInitialize)trbCO).EndInit();
            ((System.ComponentModel.ISupportInitialize)trbCO2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trbO2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptbConnect).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.TextBox txbSerial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbLowFlow;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar trbHC;
        private System.Windows.Forms.Label lblHC;
        private System.Windows.Forms.Label lblCO;
        private System.Windows.Forms.TrackBar trbCO;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblCO2;
        private System.Windows.Forms.TrackBar trbCO2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblO2;
        private System.Windows.Forms.TrackBar trbO2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox ptbConnect;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnUpdateMeasurements;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOptions;
        private System.Windows.Forms.CheckBox chbZeroProgress;
        private System.Windows.Forms.CheckBox chbWarming;
        private System.Windows.Forms.CheckBox chbLeakInProgress;
    }
}

