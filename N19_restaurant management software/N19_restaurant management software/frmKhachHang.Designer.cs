namespace N19_restaurant_management_software
{
    partial class frmKhachHang
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
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.genTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sdtTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmndTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTxt = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.delbtn = new System.Windows.Forms.Button();
            this.idTxt = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(873, 348);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(1028, 149);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(124, 22);
            this.nameTxt.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(956, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // genTxt
            // 
            this.genTxt.Location = new System.Drawing.Point(1028, 190);
            this.genTxt.Name = "genTxt";
            this.genTxt.Size = new System.Drawing.Size(124, 22);
            this.genTxt.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(956, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "gender";
            // 
            // sdtTxt
            // 
            this.sdtTxt.Location = new System.Drawing.Point(1028, 233);
            this.sdtTxt.Name = "sdtTxt";
            this.sdtTxt.Size = new System.Drawing.Size(124, 22);
            this.sdtTxt.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(956, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sdt";
            // 
            // cmndTxt
            // 
            this.cmndTxt.Location = new System.Drawing.Point(1028, 274);
            this.cmndTxt.Name = "cmndTxt";
            this.cmndTxt.Size = new System.Drawing.Size(124, 22);
            this.cmndTxt.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(956, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "CMND";
            // 
            // dateTxt
            // 
            this.dateTxt.Location = new System.Drawing.Point(578, 22);
            this.dateTxt.Name = "dateTxt";
            this.dateTxt.Size = new System.Drawing.Size(274, 22);
            this.dateTxt.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(518, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "date";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(959, 342);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(89, 45);
            this.addBtn.TabIndex = 13;
            this.addBtn.Text = "Them";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(1093, 342);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(89, 45);
            this.editBtn.TabIndex = 16;
            this.editBtn.Text = "Sua";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // delbtn
            // 
            this.delbtn.Location = new System.Drawing.Point(1093, 422);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(89, 39);
            this.delbtn.TabIndex = 17;
            this.delbtn.Text = "Xoa";
            this.delbtn.UseVisualStyleBackColor = true;
            this.delbtn.Click += new System.EventHandler(this.delbtn_Click);
            // 
            // idTxt
            // 
            this.idTxt.Location = new System.Drawing.Point(1028, 104);
            this.idTxt.Name = "idTxt";
            this.idTxt.Size = new System.Drawing.Size(123, 22);
            this.idTxt.TabIndex = 19;
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(955, 107);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(18, 16);
            this.id.TabIndex = 18;
            this.id.Text = "id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Tìm kiếm";
            // 
            // searchTxt
            // 
            this.searchTxt.Location = new System.Drawing.Point(97, 55);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(228, 22);
            this.searchTxt.TabIndex = 22;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(358, 47);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(89, 45);
            this.searchBtn.TabIndex = 23;
            this.searchBtn.Text = "Tìm";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 573);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.idTxt);
            this.Controls.Add(this.id);
            this.Controls.Add(this.delbtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTxt);
            this.Controls.Add(this.cmndTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sdtTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.genTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmKhachHang";
            this.Text = "frmKhachHang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKhachHang_FormClosing);
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox genTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sdtTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cmndTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button delbtn;
        private System.Windows.Forms.TextBox idTxt;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.Button searchBtn;
    }
}