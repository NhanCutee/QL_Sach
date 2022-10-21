namespace QL_Sach
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
            this.label_ID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_TacGia = new System.Windows.Forms.Label();
            this.label_Gia = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.textBox_TenSach = new System.Windows.Forms.TextBox();
            this.textBox_TacGia = new System.Windows.Forms.TextBox();
            this.textBox_Gia = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Them = new System.Windows.Forms.Button();
            this.button_Sửa = new System.Windows.Forms.Button();
            this.button_Xoa = new System.Windows.Forms.Button();
            this.button_Thoát = new System.Windows.Forms.Button();
            this.button_LamMoi = new System.Windows.Forms.Button();
            this.label_test = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ID.Location = new System.Drawing.Point(6, 24);
            this.label_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(25, 15);
            this.label_ID.TabIndex = 0;
            this.label_ID.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên sách:";
            // 
            // label_TacGia
            // 
            this.label_TacGia.AutoSize = true;
            this.label_TacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TacGia.Location = new System.Drawing.Point(388, 26);
            this.label_TacGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_TacGia.Name = "label_TacGia";
            this.label_TacGia.Size = new System.Drawing.Size(62, 15);
            this.label_TacGia.TabIndex = 2;
            this.label_TacGia.Text = "Tác giả: ";
            // 
            // label_Gia
            // 
            this.label_Gia.AutoSize = true;
            this.label_Gia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Gia.Location = new System.Drawing.Point(598, 27);
            this.label_Gia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Gia.Name = "label_Gia";
            this.label_Gia.Size = new System.Drawing.Size(37, 15);
            this.label_Gia.TabIndex = 3;
            this.label_Gia.Text = "Giá: ";
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(32, 23);
            this.textBox_ID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(140, 20);
            this.textBox_ID.TabIndex = 4;
            // 
            // textBox_TenSach
            // 
            this.textBox_TenSach.Location = new System.Drawing.Point(242, 23);
            this.textBox_TenSach.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_TenSach.Name = "textBox_TenSach";
            this.textBox_TenSach.Size = new System.Drawing.Size(140, 20);
            this.textBox_TenSach.TabIndex = 5;
            // 
            // textBox_TacGia
            // 
            this.textBox_TacGia.Location = new System.Drawing.Point(448, 24);
            this.textBox_TacGia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_TacGia.Name = "textBox_TacGia";
            this.textBox_TacGia.Size = new System.Drawing.Size(140, 20);
            this.textBox_TacGia.TabIndex = 6;
            // 
            // textBox_Gia
            // 
            this.textBox_Gia.Location = new System.Drawing.Point(635, 23);
            this.textBox_Gia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Gia.Name = "textBox_Gia";
            this.textBox_Gia.Size = new System.Drawing.Size(140, 20);
            this.textBox_Gia.TabIndex = 7;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TenSach,
            this.TacGia,
            this.Gia});
            this.dataGridView.Location = new System.Drawing.Point(9, 58);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1010, 459);
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
            // TacGia
            // 
            this.TacGia.DataPropertyName = "TenTacGia";
            this.TacGia.HeaderText = "Tác giả";
            this.TacGia.MinimumWidth = 6;
            this.TacGia.Name = "TacGia";
            this.TacGia.Width = 125;
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
            this.button_Them.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Them.Name = "button_Them";
            this.button_Them.Size = new System.Drawing.Size(89, 39);
            this.button_Them.TabIndex = 9;
            this.button_Them.Text = "Thêm";
            this.button_Them.UseVisualStyleBackColor = false;
            this.button_Them.Click += new System.EventHandler(this.button_Them_Click);
            // 
            // button_Sửa
            // 
            this.button_Sửa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_Sửa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Sửa.Location = new System.Drawing.Point(234, 537);
            this.button_Sửa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Sửa.Name = "button_Sửa";
            this.button_Sửa.Size = new System.Drawing.Size(89, 39);
            this.button_Sửa.TabIndex = 10;
            this.button_Sửa.Text = "Sửa";
            this.button_Sửa.UseVisualStyleBackColor = false;
            // 
            // button_Xoa
            // 
            this.button_Xoa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Xoa.Location = new System.Drawing.Point(448, 537);
            this.button_Xoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.button_Thoát.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.button_LamMoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_LamMoi.Name = "button_LamMoi";
            this.button_LamMoi.Size = new System.Drawing.Size(89, 39);
            this.button_LamMoi.TabIndex = 13;
            this.button_LamMoi.Text = "Làm mới";
            this.button_LamMoi.UseVisualStyleBackColor = false;
            // 
            // label_test
            // 
            this.label_test.AutoSize = true;
            this.label_test.Location = new System.Drawing.Point(814, 27);
            this.label_test.Name = "label_test";
            this.label_test.Size = new System.Drawing.Size(35, 13);
            this.label_test.TabIndex = 14;
            this.label_test.Text = "label1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 609);
            this.Controls.Add(this.label_test);
            this.Controls.Add(this.button_LamMoi);
            this.Controls.Add(this.button_Thoát);
            this.Controls.Add(this.button_Xoa);
            this.Controls.Add(this.button_Sửa);
            this.Controls.Add(this.button_Them);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.textBox_Gia);
            this.Controls.Add(this.textBox_TacGia);
            this.Controls.Add(this.textBox_TenSach);
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.label_Gia);
            this.Controls.Add(this.label_TacGia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_ID);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_TacGia;
        private System.Windows.Forms.Label label_Gia;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.TextBox textBox_TenSach;
        private System.Windows.Forms.TextBox textBox_TacGia;
        private System.Windows.Forms.TextBox textBox_Gia;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button button_Them;
        private System.Windows.Forms.Button button_Sửa;
        private System.Windows.Forms.Button button_Xoa;
        private System.Windows.Forms.Button button_Thoát;
        private System.Windows.Forms.Button button_LamMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.Label label_test;
    }
}