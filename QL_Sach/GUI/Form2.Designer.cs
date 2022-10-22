﻿namespace QL_Sach.GUI
{
    partial class Form2
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhaSanXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhaXuatBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Them = new System.Windows.Forms.Button();
            this.button_ChinhSua = new System.Windows.Forms.Button();
            this.button_Xoa = new System.Windows.Forms.Button();
            this.button_Thoát = new System.Windows.Forms.Button();
            this.button_LamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TenSach,
            this.TheLoai,
            this.TacGia,
            this.NhaSanXuat,
            this.NhaXuatBan,
            this.GhiChu,
            this.Gia});
            this.dataGridView.Location = new System.Drawing.Point(9, 45);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1050, 471);
            this.dataGridView.TabIndex = 8;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "MaSach";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // TenSach
            // 
            this.TenSach.DataPropertyName = "TenSach";
            this.TenSach.HeaderText = "Tên sách";
            this.TenSach.MinimumWidth = 6;
            this.TenSach.Name = "TenSach";
            this.TenSach.Width = 125;
            // 
            // TheLoai
            // 
            this.TheLoai.DataPropertyName = "TheLoai";
            this.TheLoai.HeaderText = "Thể loại";
            this.TheLoai.MinimumWidth = 6;
            this.TheLoai.Name = "TheLoai";
            this.TheLoai.Width = 125;
            // 
            // TacGia
            // 
            this.TacGia.DataPropertyName = "TenTacGia";
            this.TacGia.HeaderText = "Tác giả";
            this.TacGia.MinimumWidth = 6;
            this.TacGia.Name = "TacGia";
            this.TacGia.Width = 125;
            // 
            // NhaSanXuat
            // 
            this.NhaSanXuat.DataPropertyName = "NgayXuatBan";
            this.NhaSanXuat.HeaderText = "Ngày xuất bản";
            this.NhaSanXuat.MinimumWidth = 6;
            this.NhaSanXuat.Name = "NhaSanXuat";
            this.NhaSanXuat.Width = 125;
            // 
            // NhaXuatBan
            // 
            this.NhaXuatBan.DataPropertyName = "NhaXuatBan";
            this.NhaXuatBan.HeaderText = "Nhà xuất bản";
            this.NhaXuatBan.MinimumWidth = 6;
            this.NhaXuatBan.Name = "NhaXuatBan";
            this.NhaXuatBan.Width = 125;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 125;
            // 
            // Gia
            // 
            this.Gia.DataPropertyName = "Gia";
            this.Gia.HeaderText = "Giá";
            this.Gia.MinimumWidth = 6;
            this.Gia.Name = "Gia";
            this.Gia.Width = 125;
            // 
            // button_Them
            // 
            this.button_Them.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Them.Location = new System.Drawing.Point(32, 537);
            this.button_Them.Margin = new System.Windows.Forms.Padding(2);
            this.button_Them.Name = "button_Them";
            this.button_Them.Size = new System.Drawing.Size(89, 39);
            this.button_Them.TabIndex = 9;
            this.button_Them.Text = "Thêm";
            this.button_Them.UseVisualStyleBackColor = false;
            this.button_Them.Click += new System.EventHandler(this.button_Them_Click);
            // 
            // button_ChinhSua
            // 
            this.button_ChinhSua.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_ChinhSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ChinhSua.Location = new System.Drawing.Point(234, 537);
            this.button_ChinhSua.Margin = new System.Windows.Forms.Padding(2);
            this.button_ChinhSua.Name = "button_ChinhSua";
            this.button_ChinhSua.Size = new System.Drawing.Size(89, 39);
            this.button_ChinhSua.TabIndex = 10;
            this.button_ChinhSua.Text = "Chỉnh sửa";
            this.button_ChinhSua.UseVisualStyleBackColor = false;
            this.button_ChinhSua.Click += new System.EventHandler(this.button_ChinhSua_Click);
            // 
            // button_Xoa
            // 
            this.button_Xoa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Xoa.Location = new System.Drawing.Point(448, 537);
            this.button_Xoa.Margin = new System.Windows.Forms.Padding(2);
            this.button_Xoa.Name = "button_Xoa";
            this.button_Xoa.Size = new System.Drawing.Size(89, 39);
            this.button_Xoa.TabIndex = 11;
            this.button_Xoa.Text = "Xóa";
            this.button_Xoa.UseVisualStyleBackColor = false;
            this.button_Xoa.Click += new System.EventHandler(this.button_Xoa_Click);
            // 
            // button_Thoát
            // 
            this.button_Thoát.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_Thoát.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Thoát.Location = new System.Drawing.Point(874, 537);
            this.button_Thoát.Margin = new System.Windows.Forms.Padding(2);
            this.button_Thoát.Name = "button_Thoát";
            this.button_Thoát.Size = new System.Drawing.Size(89, 39);
            this.button_Thoát.TabIndex = 12;
            this.button_Thoát.Text = "Thoát";
            this.button_Thoát.UseVisualStyleBackColor = false;
            // 
            // button_LamMoi
            // 
            this.button_LamMoi.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_LamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LamMoi.Location = new System.Drawing.Point(662, 537);
            this.button_LamMoi.Margin = new System.Windows.Forms.Padding(2);
            this.button_LamMoi.Name = "button_LamMoi";
            this.button_LamMoi.Size = new System.Drawing.Size(89, 39);
            this.button_LamMoi.TabIndex = 13;
            this.button_LamMoi.Text = "Làm mới";
            this.button_LamMoi.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 609);
            this.Controls.Add(this.button_LamMoi);
            this.Controls.Add(this.button_Thoát);
            this.Controls.Add(this.button_Xoa);
            this.Controls.Add(this.button_ChinhSua);
            this.Controls.Add(this.button_Them);
            this.Controls.Add(this.dataGridView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button button_Them;
        private System.Windows.Forms.Button button_ChinhSua;
        private System.Windows.Forms.Button button_Xoa;
        private System.Windows.Forms.Button button_Thoát;
        private System.Windows.Forms.Button button_LamMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TheLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhaSanXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhaXuatBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
    }
}