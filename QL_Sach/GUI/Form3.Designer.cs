
namespace QL_Sach.GUI
{
    partial class Form3
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
            this.textbox_MaSach = new System.Windows.Forms.TextBox();
            this.textBox_TenSach = new System.Windows.Forms.TextBox();
            this.label_TenSach = new System.Windows.Forms.Label();
            this.comboBox_TheLoai = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_NhaXuatBan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker_NgayXuatBan = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_GhiChu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Gia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_TacGia = new System.Windows.Forms.TextBox();
            this.label_Title = new System.Windows.Forms.Label();
            this.button_Nhap = new System.Windows.Forms.Button();
            this.button_NhapLai = new System.Windows.Forms.Button();
            this.button_Huy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_MaSach
            // 
            this.label_MaSach.AutoSize = true;
            this.label_MaSach.Location = new System.Drawing.Point(52, 75);
            this.label_MaSach.Name = "label_MaSach";
            this.label_MaSach.Size = new System.Drawing.Size(48, 13);
            this.label_MaSach.TabIndex = 999;
            this.label_MaSach.Text = "Mã sách";
            // 
            // textbox_MaSach
            // 
            this.textbox_MaSach.Location = new System.Drawing.Point(137, 68);
            this.textbox_MaSach.MaxLength = 10;
            this.textbox_MaSach.Name = "textbox_MaSach";
            this.textbox_MaSach.Size = new System.Drawing.Size(305, 20);
            this.textbox_MaSach.TabIndex = 0;
            this.textbox_MaSach.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_TenSach
            // 
            this.textBox_TenSach.Location = new System.Drawing.Point(137, 106);
            this.textBox_TenSach.MaxLength = 100;
            this.textBox_TenSach.Name = "textBox_TenSach";
            this.textBox_TenSach.Size = new System.Drawing.Size(305, 20);
            this.textBox_TenSach.TabIndex = 1;
            // 
            // label_TenSach
            // 
            this.label_TenSach.AutoSize = true;
            this.label_TenSach.Location = new System.Drawing.Point(52, 113);
            this.label_TenSach.Name = "label_TenSach";
            this.label_TenSach.Size = new System.Drawing.Size(54, 13);
            this.label_TenSach.TabIndex = 999;
            this.label_TenSach.Text = "Tên Sách";
            // 
            // comboBox_TheLoai
            // 
            this.comboBox_TheLoai.FormattingEnabled = true;
            this.comboBox_TheLoai.Location = new System.Drawing.Point(137, 194);
            this.comboBox_TheLoai.Name = "comboBox_TheLoai";
            this.comboBox_TheLoai.Size = new System.Drawing.Size(305, 21);
            this.comboBox_TheLoai.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 999;
            this.label3.Text = "Thể loại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 999;
            this.label2.Text = "Nhà xuất bản";
            // 
            // comboBox_NhaXuatBan
            // 
            this.comboBox_NhaXuatBan.FormattingEnabled = true;
            this.comboBox_NhaXuatBan.Location = new System.Drawing.Point(137, 235);
            this.comboBox_NhaXuatBan.Name = "comboBox_NhaXuatBan";
            this.comboBox_NhaXuatBan.Size = new System.Drawing.Size(305, 21);
            this.comboBox_NhaXuatBan.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 999;
            this.label4.Text = "Tác Giả";
            // 
            // dateTimePicker_NgayXuatBan
            // 
            this.dateTimePicker_NgayXuatBan.Location = new System.Drawing.Point(137, 279);
            this.dateTimePicker_NgayXuatBan.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker_NgayXuatBan.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_NgayXuatBan.Name = "dateTimePicker_NgayXuatBan";
            this.dateTimePicker_NgayXuatBan.Size = new System.Drawing.Size(305, 20);
            this.dateTimePicker_NgayXuatBan.TabIndex = 5;
            this.dateTimePicker_NgayXuatBan.Value = new System.DateTime(2022, 10, 23, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 999;
            this.label5.Text = "Ngày xuất bản";
            // 
            // textBox_GhiChu
            // 
            this.textBox_GhiChu.Location = new System.Drawing.Point(137, 358);
            this.textBox_GhiChu.Multiline = true;
            this.textBox_GhiChu.Name = "textBox_GhiChu";
            this.textBox_GhiChu.Size = new System.Drawing.Size(305, 67);
            this.textBox_GhiChu.TabIndex =7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 999;
            this.label6.Text = "Ghi chú ";
            // 
            // textBox_Gia
            // 
            this.textBox_Gia.Location = new System.Drawing.Point(137, 316);
            this.textBox_Gia.MaxLength = 9;
            this.textBox_Gia.Name = "textBox_Gia";
            this.textBox_Gia.Size = new System.Drawing.Size(151, 20);
            this.textBox_Gia.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 323);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex =999;
            this.label7.Text = "Giá";
            // 
            // textBox_TacGia
            // 
            this.textBox_TacGia.Location = new System.Drawing.Point(137, 151);
            this.textBox_TacGia.MaxLength = 100;
            this.textBox_TacGia.Name = "textBox_TacGia";
            this.textBox_TacGia.Size = new System.Drawing.Size(305, 20);
            this.textBox_TacGia.TabIndex = 2;
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.Location = new System.Drawing.Point(133, 22);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(226, 20);
            this.label_Title.TabIndex = 999;
            this.label_Title.Text = "Nhập thông tin quyển Sách";
            // 
            // button_Nhap
            // 
            this.button_Nhap.Location = new System.Drawing.Point(100, 468);
            this.button_Nhap.Name = "button_Nhap";
            this.button_Nhap.Size = new System.Drawing.Size(75, 23);
            this.button_Nhap.TabIndex = 8;
            this.button_Nhap.Text = "Nhập";
            this.button_Nhap.UseVisualStyleBackColor = true;
            this.button_Nhap.Click += new System.EventHandler(this.button_Nhap_Click);
            // 
            // button_NhapLai
            // 
            this.button_NhapLai.Location = new System.Drawing.Point(210, 468);
            this.button_NhapLai.Name = "button_NhapLai";
            this.button_NhapLai.Size = new System.Drawing.Size(75, 23);
            this.button_NhapLai.TabIndex = 9;
            this.button_NhapLai.Text = "Nhập lại";
            this.button_NhapLai.UseVisualStyleBackColor = true;
            this.button_NhapLai.Click += new System.EventHandler(this.button_NhapLai_Click);
            // 
            // button_Huy
            // 
            this.button_Huy.Location = new System.Drawing.Point(316, 468);
            this.button_Huy.Name = "button_Huy";
            this.button_Huy.Size = new System.Drawing.Size(75, 23);
            this.button_Huy.TabIndex = 10;
            this.button_Huy.Text = "Hủy";
            this.button_Huy.UseVisualStyleBackColor = true;
            this.button_Huy.Click += new System.EventHandler(this.button_Huy_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 534);
            this.Controls.Add(this.button_Huy);
            this.Controls.Add(this.button_NhapLai);
            this.Controls.Add(this.button_Nhap);
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.textBox_TacGia);
            this.Controls.Add(this.textBox_Gia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_GhiChu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker_NgayXuatBan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_NhaXuatBan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_TheLoai);
            this.Controls.Add(this.textBox_TenSach);
            this.Controls.Add(this.label_TenSach);
            this.Controls.Add(this.textbox_MaSach);
            this.Controls.Add(this.label_MaSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_MaSach;
        private System.Windows.Forms.TextBox textbox_MaSach;
        private System.Windows.Forms.TextBox textBox_TenSach;
        private System.Windows.Forms.Label label_TenSach;
        private System.Windows.Forms.ComboBox comboBox_TheLoai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_NhaXuatBan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_NgayXuatBan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_GhiChu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Gia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_TacGia;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Button button_Nhap;
        private System.Windows.Forms.Button button_NhapLai;
        private System.Windows.Forms.Button button_Huy;
    }
}