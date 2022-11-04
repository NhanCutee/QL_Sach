namespace QL_Sach.GUI
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
            this.radioButton_LibListT = new System.Windows.Forms.RadioButton();
            this.radioButton_DSLK = new System.Windows.Forms.RadioButton();
            this.radioButton_DSDac = new System.Windows.Forms.RadioButton();
            this.radioButton_BangBam = new System.Windows.Forms.RadioButton();
            this.radioButton_LibDic = new System.Windows.Forms.RadioButton();
            this.radioButton_LibHash = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button_BatDau
            // 
            this.button_BatDau.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_BatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_BatDau.Location = new System.Drawing.Point(65, 107);
            this.button_BatDau.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_BatDau.Name = "button_BatDau";
            this.button_BatDau.Size = new System.Drawing.Size(75, 28);
            this.button_BatDau.TabIndex = 0;
            this.button_BatDau.Text = "Bắt đầu";
            this.button_BatDau.UseVisualStyleBackColor = false;
            this.button_BatDau.Click += new System.EventHandler(this.button_BatDau_Click);
            // 
            // button_Thoat
            // 
            this.button_Thoat.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Thoat.Location = new System.Drawing.Point(160, 107);
            this.button_Thoat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Thoat.Name = "button_Thoat";
            this.button_Thoat.Size = new System.Drawing.Size(75, 28);
            this.button_Thoat.TabIndex = 1;
            this.button_Thoat.Text = "Thoát";
            this.button_Thoat.UseVisualStyleBackColor = false;
            this.button_Thoat.Click += new System.EventHandler(this.button_Thoat_Click);
            // 
            // radioButton_LibListT
            // 
            this.radioButton_LibListT.AutoSize = true;
            this.radioButton_LibListT.Checked = true;
            this.radioButton_LibListT.Location = new System.Drawing.Point(51, 27);
            this.radioButton_LibListT.Name = "radioButton_LibListT";
            this.radioButton_LibListT.Size = new System.Drawing.Size(80, 17);
            this.radioButton_LibListT.TabIndex = 2;
            this.radioButton_LibListT.TabStop = true;
            this.radioButton_LibListT.Text = "Lib: List<T>";
            this.radioButton_LibListT.UseVisualStyleBackColor = true;
            // 
            // radioButton_DSLK
            // 
            this.radioButton_DSLK.AutoSize = true;
            this.radioButton_DSLK.Location = new System.Drawing.Point(192, 50);
            this.radioButton_DSLK.Name = "radioButton_DSLK";
            this.radioButton_DSLK.Size = new System.Drawing.Size(81, 17);
            this.radioButton_DSLK.TabIndex = 3;
            this.radioButton_DSLK.TabStop = true;
            this.radioButton_DSLK.Text = "DS Liên kết";
            this.radioButton_DSLK.UseVisualStyleBackColor = true;
            // 
            // radioButton_DSDac
            // 
            this.radioButton_DSDac.AutoSize = true;
            this.radioButton_DSDac.Location = new System.Drawing.Point(192, 73);
            this.radioButton_DSDac.Name = "radioButton_DSDac";
            this.radioButton_DSDac.Size = new System.Drawing.Size(63, 17);
            this.radioButton_DSDac.TabIndex = 4;
            this.radioButton_DSDac.TabStop = true;
            this.radioButton_DSDac.Text = "DS Đặc";
            this.radioButton_DSDac.UseVisualStyleBackColor = true;
            // 
            // radioButton_BangBam
            // 
            this.radioButton_BangBam.AutoSize = true;
            this.radioButton_BangBam.Location = new System.Drawing.Point(192, 27);
            this.radioButton_BangBam.Name = "radioButton_BangBam";
            this.radioButton_BangBam.Size = new System.Drawing.Size(73, 17);
            this.radioButton_BangBam.TabIndex = 5;
            this.radioButton_BangBam.TabStop = true;
            this.radioButton_BangBam.Text = "Bảng băm";
            this.radioButton_BangBam.UseVisualStyleBackColor = true;
            // 
            // radioButton_LibDic
            // 
            this.radioButton_LibDic.AutoSize = true;
            this.radioButton_LibDic.Location = new System.Drawing.Point(51, 50);
            this.radioButton_LibDic.Name = "radioButton_LibDic";
            this.radioButton_LibDic.Size = new System.Drawing.Size(92, 17);
            this.radioButton_LibDic.TabIndex = 6;
            this.radioButton_LibDic.TabStop = true;
            this.radioButton_LibDic.Text = "Lib: Dictionary";
            this.radioButton_LibDic.UseVisualStyleBackColor = true;
            // 
            // radioButton_LibHash
            // 
            this.radioButton_LibHash.AutoSize = true;
            this.radioButton_LibHash.Location = new System.Drawing.Point(51, 73);
            this.radioButton_LibHash.Name = "radioButton_LibHash";
            this.radioButton_LibHash.Size = new System.Drawing.Size(97, 17);
            this.radioButton_LibHash.TabIndex = 7;
            this.radioButton_LibHash.TabStop = true;
            this.radioButton_LibHash.Text = "Lib: HashTable";
            this.radioButton_LibHash.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 151);
            this.Controls.Add(this.radioButton_LibHash);
            this.Controls.Add(this.radioButton_LibDic);
            this.Controls.Add(this.radioButton_BangBam);
            this.Controls.Add(this.radioButton_DSDac);
            this.Controls.Add(this.radioButton_DSLK);
            this.Controls.Add(this.radioButton_LibListT);
            this.Controls.Add(this.button_Thoat);
            this.Controls.Add(this.button_BatDau);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn cấu trúc dữ liệu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_BatDau;
        private System.Windows.Forms.Button button_Thoat;
        private System.Windows.Forms.RadioButton radioButton_LibListT;
        private System.Windows.Forms.RadioButton radioButton_DSLK;
        private System.Windows.Forms.RadioButton radioButton_DSDac;
        private System.Windows.Forms.RadioButton radioButton_BangBam;
        private System.Windows.Forms.RadioButton radioButton_LibDic;
        private System.Windows.Forms.RadioButton radioButton_LibHash;
    }
}

