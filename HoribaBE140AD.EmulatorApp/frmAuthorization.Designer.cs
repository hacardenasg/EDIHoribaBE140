namespace HoribaBE140AD.EmulatorApp
{
    partial class frmAuthorization
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
            this.button1 = new System.Windows.Forms.Button();
            this.AuthCodeTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RequestCodeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(12, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(272, 38);
            this.button1.TabIndex = 9;
            this.button1.Text = "Autorizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AuthCodeTextbox
            // 
            this.AuthCodeTextbox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AuthCodeTextbox.Location = new System.Drawing.Point(12, 143);
            this.AuthCodeTextbox.Name = "AuthCodeTextbox";
            this.AuthCodeTextbox.Size = new System.Drawing.Size(272, 39);
            this.AuthCodeTextbox.TabIndex = 8;
            this.AuthCodeTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ingrese el código de activación";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RequestCodeLabel
            // 
            this.RequestCodeLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RequestCodeLabel.Location = new System.Drawing.Point(12, 33);
            this.RequestCodeLabel.Name = "RequestCodeLabel";
            this.RequestCodeLabel.Size = new System.Drawing.Size(272, 46);
            this.RequestCodeLabel.TabIndex = 6;
            this.RequestCodeLabel.Text = "00000000";
            this.RequestCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Identificacion";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 237);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AuthCodeTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RequestCodeLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAuthorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorizar Herramientas";
            this.Load += new System.EventHandler(this.frmAuthorization_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox AuthCodeTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label RequestCodeLabel;
        private System.Windows.Forms.Label label1;
    }
}