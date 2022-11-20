namespace QL_Sach.GUI
{
    partial class Form_BatDau
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_Sach = new System.Windows.Forms.RadioButton();
            this.radioButton_NhanVien = new System.Windows.Forms.RadioButton();
            this.radioButton_NhaSach = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_BatDau
            // 
            this.button_BatDau.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_BatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_BatDau.Location = new System.Drawing.Point(83, 136);
            this.button_BatDau.Margin = new System.Windows.Forms.Padding(2);
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
            this.button_Thoat.Location = new System.Drawing.Point(178, 136);
            this.button_Thoat.Margin = new System.Windows.Forms.Padding(2);
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
            this.radioButton_LibListT.Location = new System.Drawing.Point(17, 19);
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
            this.radioButton_DSLK.Location = new System.Drawing.Point(17, 42);
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
            this.radioButton_DSDac.Location = new System.Drawing.Point(17, 65);
            this.radioButton_DSDac.Name = "radioButton_DSDac";
            this.radioButton_DSDac.Size = new System.Drawing.Size(63, 17);
            this.radioButton_DSDac.TabIndex = 4;
            this.radioButton_DSDac.TabStop = true;
            this.radioButton_DSDac.Text = "DS Đặc";
            this.radioButton_DSDac.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_LibListT);
            this.groupBox1.Controls.Add(this.radioButton_DSDac);
            this.groupBox1.Controls.Add(this.radioButton_DSLK);
            this.groupBox1.Location = new System.Drawing.Point(178, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 94);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kiểu dữ liệu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_NhaSach);
            this.groupBox2.Controls.Add(this.radioButton_NhanVien);
            this.groupBox2.Controls.Add(this.radioButton_Sach);
            this.groupBox2.Location = new System.Drawing.Point(35, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(115, 94);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đối tượng quản lý";
            // 
            // radioButton_Sach
            // 
            this.radioButton_Sach.AutoSize = true;
            this.radioButton_Sach.Checked = true;
            this.radioButton_Sach.Location = new System.Drawing.Point(7, 20);
            this.radioButton_Sach.Name = "radioButton_Sach";
            this.radioButton_Sach.Size = new System.Drawing.Size(50, 17);
            this.radioButton_Sach.TabIndex = 0;
            this.radioButton_Sach.TabStop = true;
            this.radioButton_Sach.Text = "Sách";
            this.radioButton_Sach.UseVisualStyleBackColor = true;
            // 
            // radioButton_NhanVien
            // 
            this.radioButton_NhanVien.AutoSize = true;
            this.radioButton_NhanVien.Location = new System.Drawing.Point(6, 43);
            this.radioButton_NhanVien.Name = "radioButton_NhanVien";
            this.radioButton_NhanVien.Size = new System.Drawing.Size(75, 17);
            this.radioButton_NhanVien.TabIndex = 1;
            this.radioButton_NhanVien.Text = "Nhân Viên";
            this.radioButton_NhanVien.UseVisualStyleBackColor = true;
            // 
            // radioButton_NhaSach
            // 
            this.radioButton_NhaSach.AutoSize = true;
            this.radioButton_NhaSach.Location = new System.Drawing.Point(7, 66);
            this.radioButton_NhaSach.Name = "radioButton_NhaSach";
            this.radioButton_NhaSach.Size = new System.Drawing.Size(71, 17);
            this.radioButton_NhaSach.TabIndex = 2;
            this.radioButton_NhaSach.Text = "Nhà sách";
            this.radioButton_NhaSach.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 183);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Thoat);
            this.Controls.Add(this.button_BatDau);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn cấu trúc dữ liệu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_BatDau;
        private System.Windows.Forms.Button button_Thoat;
        private System.Windows.Forms.RadioButton radioButton_LibListT;
        private System.Windows.Forms.RadioButton radioButton_DSLK;
        private System.Windows.Forms.RadioButton radioButton_DSDac;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton_NhaSach;
        private System.Windows.Forms.RadioButton radioButton_NhanVien;
        private System.Windows.Forms.RadioButton radioButton_Sach;
    }
}

