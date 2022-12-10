
namespace QL_Sach.GUI
{
    partial class Form_NhaSach
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
            this.label_MaSach = new System.Windows.Forms.Label();
            this.textbox_MaNhaSach = new System.Windows.Forms.TextBox();
            this.textBox_TenNhaSach = new System.Windows.Forms.TextBox();
            this.label_TenSach = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_DiaChi = new System.Windows.Forms.TextBox();
            this.label_Title = new System.Windows.Forms.Label();
            this.button_Nhap = new System.Windows.Forms.Button();
            this.button_NhapLai = new System.Windows.Forms.Button();
            this.button_Huy = new System.Windows.Forms.Button();
            this.textBox_TenQuanLi = new System.Windows.Forms.TextBox();
            this.textBox_SoLuongNhanVien = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_MaSach
            // 
            this.label_MaSach.AutoSize = true;
            this.label_MaSach.Location = new System.Drawing.Point(52, 75);
            this.label_MaSach.Name = "label_MaSach";
            this.label_MaSach.Size = new System.Drawing.Size(69, 13);
            this.label_MaSach.TabIndex = 999;
            this.label_MaSach.Text = "Mã nhà sách";
            // 
            // textbox_MaNhaSach
            // 
            this.textbox_MaNhaSach.Location = new System.Drawing.Point(137, 68);
            this.textbox_MaNhaSach.MaxLength = 10;
            this.textbox_MaNhaSach.Name = "textbox_MaNhaSach";
            this.textbox_MaNhaSach.Size = new System.Drawing.Size(305, 20);
            this.textbox_MaNhaSach.TabIndex = 0;
            this.textbox_MaNhaSach.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_TenNhaSach
            // 
            this.textBox_TenNhaSach.Location = new System.Drawing.Point(137, 110);
            this.textBox_TenNhaSach.MaxLength = 100;
            this.textBox_TenNhaSach.Name = "textBox_TenNhaSach";
            this.textBox_TenNhaSach.Size = new System.Drawing.Size(305, 20);
            this.textBox_TenNhaSach.TabIndex = 1;
            this.textBox_TenNhaSach.Text = "Fahasha quận 8";
            // 
            // label_TenSach
            // 
            this.label_TenSach.AutoSize = true;
            this.label_TenSach.Location = new System.Drawing.Point(52, 113);
            this.label_TenSach.Name = "label_TenSach";
            this.label_TenSach.Size = new System.Drawing.Size(73, 13);
            this.label_TenSach.TabIndex = 999;
            this.label_TenSach.Text = "Tên nhà sách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 999;
            this.label3.Text = "Tên quản lí";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 999;
            this.label2.Text = "Số lượng nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 999;
            this.label4.Text = "Địa chỉ";
            // 
            // textBox_DiaChi
            // 
            this.textBox_DiaChi.Location = new System.Drawing.Point(137, 155);
            this.textBox_DiaChi.MaxLength = 100;
            this.textBox_DiaChi.Name = "textBox_DiaChi";
            this.textBox_DiaChi.Size = new System.Drawing.Size(305, 20);
            this.textBox_DiaChi.TabIndex = 2;
            this.textBox_DiaChi.Text = "123 Cao Lỗ";
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.Location = new System.Drawing.Point(133, 22);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(205, 20);
            this.label_Title.TabIndex = 999;
            this.label_Title.Text = "Nhập thông tin nhà sách";
            // 
            // button_Nhap
            // 
            this.button_Nhap.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_Nhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Nhap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Nhap.Location = new System.Drawing.Point(107, 319);
            this.button_Nhap.Name = "button_Nhap";
            this.button_Nhap.Size = new System.Drawing.Size(75, 23);
            this.button_Nhap.TabIndex = 8;
            this.button_Nhap.Text = "Nhập";
            this.button_Nhap.UseVisualStyleBackColor = false;
            this.button_Nhap.Click += new System.EventHandler(this.button_Nhap_Click);
            // 
            // button_NhapLai
            // 
            this.button_NhapLai.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_NhapLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_NhapLai.Location = new System.Drawing.Point(212, 319);
            this.button_NhapLai.Name = "button_NhapLai";
            this.button_NhapLai.Size = new System.Drawing.Size(75, 23);
            this.button_NhapLai.TabIndex = 9;
            this.button_NhapLai.Text = "Nhập lại";
            this.button_NhapLai.UseVisualStyleBackColor = false;
            this.button_NhapLai.Click += new System.EventHandler(this.button_NhapLai_Click);
            // 
            // button_Huy
            // 
            this.button_Huy.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_Huy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Huy.Location = new System.Drawing.Point(322, 319);
            this.button_Huy.Name = "button_Huy";
            this.button_Huy.Size = new System.Drawing.Size(75, 23);
            this.button_Huy.TabIndex = 10;
            this.button_Huy.Text = "Hủy";
            this.button_Huy.UseVisualStyleBackColor = false;
            this.button_Huy.Click += new System.EventHandler(this.button_Huy_Click);
            // 
            // textBox_TenQuanLi
            // 
            this.textBox_TenQuanLi.Location = new System.Drawing.Point(137, 199);
            this.textBox_TenQuanLi.MaxLength = 100;
            this.textBox_TenQuanLi.Name = "textBox_TenQuanLi";
            this.textBox_TenQuanLi.Size = new System.Drawing.Size(305, 20);
            this.textBox_TenQuanLi.TabIndex = 1000;
            this.textBox_TenQuanLi.Text = "Quản lí 1";
            // 
            // textBox_SoLuongNhanVien
            // 
            this.textBox_SoLuongNhanVien.Location = new System.Drawing.Point(157, 244);
            this.textBox_SoLuongNhanVien.MaxLength = 100;
            this.textBox_SoLuongNhanVien.Name = "textBox_SoLuongNhanVien";
            this.textBox_SoLuongNhanVien.Size = new System.Drawing.Size(285, 20);
            this.textBox_SoLuongNhanVien.TabIndex = 1001;
            this.textBox_SoLuongNhanVien.Text = "7";
            // 
            // Form_NhaSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 404);
            this.Controls.Add(this.textBox_SoLuongNhanVien);
            this.Controls.Add(this.textBox_TenQuanLi);
            this.Controls.Add(this.button_Huy);
            this.Controls.Add(this.button_NhapLai);
            this.Controls.Add(this.button_Nhap);
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.textBox_DiaChi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_TenNhaSach);
            this.Controls.Add(this.label_TenSach);
            this.Controls.Add(this.textbox_MaNhaSach);
            this.Controls.Add(this.label_MaSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form_NhaSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_MaSach;
        private System.Windows.Forms.TextBox textbox_MaNhaSach;
        private System.Windows.Forms.TextBox textBox_TenNhaSach;
        private System.Windows.Forms.Label label_TenSach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_DiaChi;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Button button_Nhap;
        private System.Windows.Forms.Button button_NhapLai;
        private System.Windows.Forms.Button button_Huy;
        private System.Windows.Forms.TextBox textBox_TenQuanLi;
        private System.Windows.Forms.TextBox textBox_SoLuongNhanVien;
    }
}