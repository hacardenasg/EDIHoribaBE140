namespace HoribaBE140AD.EmulatorApp
{
    partial class frmPermisos
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
            button1 = new System.Windows.Forms.Button();
            AuthCodeTextbox = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            RequestCodeLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(12, 217);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(312, 57);
            button1.TabIndex = 9;
            button1.Text = "Autorizar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // AuthCodeTextbox
            // 
            AuthCodeTextbox.Font = new System.Drawing.Font("Segoe UI", 18F);
            AuthCodeTextbox.Location = new System.Drawing.Point(12, 164);
            AuthCodeTextbox.Name = "AuthCodeTextbox";
            AuthCodeTextbox.Size = new System.Drawing.Size(312, 47);
            AuthCodeTextbox.TabIndex = 8;
            AuthCodeTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            label3.Location = new System.Drawing.Point(12, 116);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(312, 25);
            label3.TabIndex = 7;
            label3.Text = "Ingrese el código de autorización";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RequestCodeLabel
            // 
            RequestCodeLabel.Font = new System.Drawing.Font("Segoe UI", 19.8000011F);
            RequestCodeLabel.Location = new System.Drawing.Point(12, 53);
            RequestCodeLabel.Name = "RequestCodeLabel";
            RequestCodeLabel.Size = new System.Drawing.Size(312, 50);
            RequestCodeLabel.TabIndex = 6;
            RequestCodeLabel.Text = "0000000000";
            RequestCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(312, 25);
            label1.TabIndex = 5;
            label1.Text = "Identificación";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPermisos
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(333, 283);
            Controls.Add(button1);
            Controls.Add(AuthCodeTextbox);
            Controls.Add(label3);
            Controls.Add(RequestCodeLabel);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmPermisos";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Load += frmPermisos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox AuthCodeTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label RequestCodeLabel;
        private System.Windows.Forms.Label label1;
    }
}