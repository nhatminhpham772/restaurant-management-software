using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N19_restaurant_management_software
{
    public partial class frmBanAn : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog = N19_QuanLyQuanAn; User ID = sa; Password=sa");
        bool TrangThaiBanAn;
        int SttBanAn;

        public frmBanAn()
        {
            InitializeComponent();
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();
        }

        private void btnThemDatMon_Click(object sender, EventArgs e)
        {
            int idBanAn;
            int idMonAn;
            int idKhachHang;
            try
            {

                if((cbxBan.SelectedValue == null))
                {
                    MessageBox.Show("chưa chọn bàn ăn");
                }
                else if((cbxMonAn.SelectedValue == null))
                {
                    MessageBox.Show("chưa chọn món ăn");
                }
                else if (txtIdKH.Text == null)
                {
                    MessageBox.Show("chưa chọn khách hàng");
                }
                else if (numSoLuong.Value <= 0)
                {
                    MessageBox.Show("số lượng món ăn phải lớn hơn 0");
                }
                else
                {
                    idKhachHang = Convert.ToInt32(txtIdKH.Text);
                    idBanAn = int.Parse(cbxBan.SelectedValue.ToString());
                    idMonAn = int.Parse(cbxMonAn.SelectedValue.ToString());

                    SqlCommand sql_cmnd = new SqlCommand("sp_ThemDatMon", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@idBanAn", SqlDbType.Int).Value = idBanAn;
                    sql_cmnd.Parameters.AddWithValue("@idMonAn", SqlDbType.Int).Value = idMonAn;
                    sql_cmnd.Parameters.AddWithValue("@idKhachHang", SqlDbType.Int).Value = idKhachHang;
                    sql_cmnd.Parameters.AddWithValue("@SoLuong", SqlDbType.Int).Value = int.Parse(numSoLuong.Value.ToString());
                    sql_cmnd.ExecuteNonQuery();

                    MessageBox.Show("Thêm Món thành công!", "Thông báo");
                    if (!TrangThaiBanAn)
                    {
                        MessageBox.Show("f");
                        SqlCommand sql_cmnd2 = new SqlCommand("sp_SuaBanAn", connection);
                        sql_cmnd2.CommandType = CommandType.StoredProcedure;
                        sql_cmnd2.Parameters.AddWithValue("@idBanAn", SqlDbType.Int).Value = idBanAn;
                        sql_cmnd2.Parameters.AddWithValue("@sttBan", SqlDbType.Int).Value = SttBanAn;
                        sql_cmnd2.Parameters.AddWithValue("@trangThai", SqlDbType.Bit).Value = !TrangThaiBanAn;
                        sql_cmnd2.ExecuteNonQuery();

                    }
                    LoadBanAn();
                    ShowFood(idBanAn);
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("chưa chọn khách hàng");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void frmBanAn_Load(object sender, EventArgs e)
        {
            LoadBanAn();
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            TrangThaiBanAn = bool.Parse((btn.Tag as DataRow)["Trang_thai"].ToString());
            SttBanAn = int.Parse((btn.Tag as DataRow)["STT"].ToString());
            int idBanAn = int.Parse((btn.Tag as DataRow)["ID"].ToString());
            cbxBan.SelectedValue = idBanAn;
            ShowFood(idBanAn);
            try
            {
                
                SqlCommand Total = new SqlCommand("SELECT dbo.ThanhToan(" +idBanAn.ToString() +")", connection);
               
                var result = Total.ExecuteScalar();
                
                txtTongTien.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            
        }
        void LoadBanAn()
        {
            string query = "SELECT * FROM frm_BanAn";
           
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();


            fPanelBan.Controls.Clear();
            foreach (DataRow Ban in dt.Rows)
            {
                Button btn = new Button();
                string tt;
                if (bool.Parse(Ban["Trang_thai"].ToString()) == true)
                {
                    btn.BackColor = Color.Orange;
                    tt = "Có người";
                }
                else
                {
                    btn.BackColor = Color.White;
                    tt = "Trống";
                }
                btn.Tag = Ban;
                btn.Text = "Bàn " + Ban["STT"] + Environment.NewLine + tt;
                btn.Size = new Size(89, 84);
                //btn.BackgroundImage = Properties.Resources.pngwing;
                btn.Click += new EventHandler(btn_Click);
                fPanelBan.Controls.Add(btn);

                
            }
            LoadComBoBox();
        }
        void LoadComBoBox()
        {
            string queryDanhMuc = "SELECT * FROM frm_DanhMuc";
            string queryBanAn = "SELECT * FROM frm_BanAn";
            string queryKM = "SELECT * FROM frm_KhuyenMai";


            SqlCommand cmd = new SqlCommand(queryDanhMuc, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();


            //datasource -->cbxDanhMuc
            cbxDanhMuc.DataSource = dt;
            cbxDanhMuc.DisplayMember = "Ten_danh_muc";
            cbxDanhMuc.ValueMember = "ID";
            cbxDanhMuc.SelectedIndex = -1;


            cmd = new SqlCommand(queryBanAn, connection);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            da.Dispose();

            cbxBan.DataSource =dt;
            cbxBan.DisplayMember = "STT";
            cbxBan.ValueMember = "ID";
            cbxBan.SelectedIndex = -1;


            cmd = new SqlCommand(queryKM, connection);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            DataTable table = new DataTable("ParentTable");
            DataColumn column;
            DataRow row;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ID";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Giam_Gia";
            table.Columns.Add(column);

            foreach (DataRow km in dt.Rows)
            {
                row = table.NewRow();
                row["ID"] = km["ID"];
                row["Giam_Gia"] = km["Giam_Gia"] + (bool.Parse(km["Loai"].ToString()) ? "%" : "$");
                table.Rows.Add(row);
            }

            cbxKM.DataSource = table;
            cbxKM.DisplayMember = "Giam_Gia";
            cbxKM.ValueMember = "ID";
            cbxKM.SelectedIndex = -1;
        }


        void ShowFood(int id)
        {
            string query = "SELECT * FROM frm_DatMon WHERE Id_Ban_An =" + id.ToString();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            dgvFood.DataSource = dt;

        }

        private void cbxDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxDanhMuc.SelectedIndex >= 0)
            {
                
                int id;
                Int32.TryParse(cbxDanhMuc.SelectedValue.ToString(), out id);
                string query = "SELECT * FROM frm_MonAn WHERE Id_danh_muc =" + id.ToString();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();

                cbxMonAn.DataSource = dt;
                cbxMonAn.DisplayMember = "Ten_Mon_An";
                cbxMonAn.ValueMember = "ID";
            }
            cbxMonAn.SelectedIndex = -1;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try 
            {
                /*SqlCommand sql_cmnd = new SqlCommand("sp_TinhTien", connection);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@idDatMon", SqlDbType.Int).Value = idBanAn;
                sql_cmnd.Parameters.AddWithValue("@idKhuyenMai", SqlDbType.Int).Value = idMonAn;
                sql_cmnd.Parameters.AddWithValue("@thongTin", SqlDbType.VarChar).Value = "c";
                
                sql_cmnd.ExecuteNonQuery();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void frmBanAn_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void btnSuaDatMon_Click(object sender, EventArgs e)
        {
            int idBanAn;
            int idMonAn;
            int idKhachHang = Convert.ToInt32(txtIdKH.Text);
            int r = dgvFood.CurrentCell.RowIndex;
            int idDatMon = int.Parse(dgvFood.Rows[r].Cells[0].Value.ToString());
            try
            {
                Int32.TryParse(cbxBan.SelectedValue.ToString(), out idBanAn);
                Int32.TryParse(cbxMonAn.SelectedValue.ToString(), out idMonAn);
                ShowFood(idBanAn);

                MessageBox.Show("Sửa Món thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi: " + ex.Message, "lỗi");
            }
        }

        private void btnXoaDatMon_Click(object sender, EventArgs e)
        {
            int idBanAn;
            int r = dgvFood.CurrentCell.RowIndex;
            int idDatMon = int.Parse(dgvFood.Rows[r].Cells[0].Value.ToString());
            try
            {
                Int32.TryParse(cbxBan.SelectedValue.ToString(), out idBanAn);

                SqlCommand sql_cmnd = new SqlCommand("sp_XoaDatMon", connection);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@idDatMon", SqlDbType.Int).Value = idDatMon;
                sql_cmnd.ExecuteNonQuery();
               
                //if (dgvFood.RowCount == 0)
                   
                LoadBanAn();
                ShowFood(idBanAn);


                MessageBox.Show("Xóa Món thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi: " + ex.Message, "lỗi");
            }
        }
    }

}
