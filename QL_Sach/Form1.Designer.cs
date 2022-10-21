namespace QL_Sach
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
            this.button_BatDau = new System.Windows.Forms.Button();
            this.button_Thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_BatDau
            // 
            this.button_BatDau.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_BatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_BatDau.Location = new System.Drawing.Point(353, 310);
            this.button_BatDau.Name = "button_BatDau";
            this.button_BatDau.Size = new System.Drawing.Size(100, 51);
            this.button_BatDau.TabIndex = 0;
            this.button_BatDau.Text = "Bắt đầu";
            this.button_BatDau.UseVisualStyleBackColor = false;
            // 
            // button_Thoat
            // 
            this.button_Thoat.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Thoat.Location = new System.Drawing.Point(353, 378);
            this.button_Thoat.Name = "button_Thoat";
            this.button_Thoat.Size = new System.Drawing.Size(100, 49);
            this.button_Thoat.TabIndex = 1;
            this.button_Thoat.Text = "Thoát";
            this.button_Thoat.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Thoat);
            this.Controls.Add(this.button_BatDau);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_BatDau;
        private System.Windows.Forms.Button button_Thoat;
    }
}

