namespace N19_restaurant_management_software
{
    partial class frmThucDon
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.idTxt = new System.Windows.Forms.TextBox();
            this.tenMonAnTxt = new System.Windows.Forms.TextBox();
            this.giaTienTxt = new System.Windows.Forms.TextBox();
            this.idDanhMucTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(610, 362);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(848, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Món Ăn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(875, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Giá tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(835, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên danh mục";
            // 
            // idTxt
            // 
            this.idTxt.Location = new System.Drawing.Point(946, 86);
            this.idTxt.Name = "idTxt";
            this.idTxt.Size = new System.Drawing.Size(224, 22);
            this.idTxt.TabIndex = 6;
            // 
            // tenMonAnTxt
            // 
            this.tenMonAnTxt.Location = new System.Drawing.Point(946, 138);
            this.tenMonAnTxt.Name = "tenMonAnTxt";
            this.tenMonAnTxt.Size = new System.Drawing.Size(224, 22);
            this.tenMonAnTxt.TabIndex = 7;
            // 
            // giaTienTxt
            // 
            this.giaTienTxt.Location = new System.Drawing.Point(946, 197);
            this.giaTienTxt.Name = "giaTienTxt";
            this.giaTienTxt.Size = new System.Drawing.Size(224, 22);
            this.giaTienTxt.TabIndex = 8;
            // 
            // idDanhMucTxt
            // 
            this.idDanhMucTxt.Location = new System.Drawing.Point(946, 257);
            this.idDanhMucTxt.Name = "idDanhMucTxt";
            this.idDanhMucTxt.Size = new System.Drawing.Size(224, 22);
            this.idDanhMucTxt.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(907, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(820, 327);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(107, 49);
            this.addBtn.TabIndex = 11;
            this.addBtn.Text = "Thêm";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(1004, 327);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(107, 49);
            this.editBtn.TabIndex = 12;
            this.editBtn.Text = "Sửa";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(1004, 409);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(107, 49);
            this.deleteBtn.TabIndex = 13;
            this.deleteBtn.Text = "Xóa";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(807, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(276, 22);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // frmThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 562);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idDanhMucTxt);
            this.Controls.Add(this.giaTienTxt);
            this.Controls.Add(this.tenMonAnTxt);
            this.Controls.Add(this.idTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmThucDon";
            this.Text = "frmThucDon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmThucDon_FormClosing);
            this.Load += new System.EventHandler(this.frmThucDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox idTxt;
        private System.Windows.Forms.TextBox tenMonAnTxt;
        private System.Windows.Forms.TextBox giaTienTxt;
        private System.Windows.Forms.TextBox idDanhMucTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}