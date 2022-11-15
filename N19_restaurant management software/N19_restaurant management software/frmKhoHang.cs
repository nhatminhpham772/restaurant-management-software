using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N19_restaurant_management_software
{
    public partial class frmKhoHang : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog = N19_QuanLyQuanAn; User ID = sa; Password=sa");

        int Them = 0;
        public frmKhoHang()
        {
            InitializeComponent();
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();
        }

        private void frmKhoHang_Load(object sender, EventArgs e)
        {
            LoadKhoHang();
        }

        void LoadKhoHang()
        {
            txtid.Enabled = false;
            txtSLNhapKho.Enabled = false;

            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            btnLoad.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnThoat.Enabled = true;
            btnNhapHang.Enabled = true;
            panNguyenLieu.Enabled = false;

            txtTenNguyenLieu.Enabled = true;
            txtSoLuong.Enabled = true;
            txtDonVi.Enabled = true;

            

            string query = "SELECT * FROM frm_KhoHang";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();

            dgvNgLieu.DataSource = dt;
            BindingData();
        }
        void BindingData()
        {
            txtid.DataBindings.Clear();
            txtTenNguyenLieu.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
            txtDonVi.DataBindings.Clear();

            txtid.DataBindings.Add("Text", dgvNgLieu.DataSource, "ID");
            txtTenNguyenLieu.DataBindings.Add("Text", dgvNgLieu.DataSource, "Ten_nguyen_lieu");
            txtSoLuong.DataBindings.Add("Text", dgvNgLieu.DataSource, "So_Luong");
            txtDonVi.DataBindings.Add("Text", dgvNgLieu.DataSource, "Don_vi");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadKhoHang();
        }

        private void frmKhoHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Them = 0;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            btnLoad.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnThoat.Enabled = false;
            btnNhapHang.Enabled = false;
            panNguyenLieu.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them = 1;

            txtid.ResetText();
            txtTenNguyenLieu.ResetText();
            txtDonVi.ResetText();
            txtSoLuong.ResetText();

            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            btnLoad.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnThoat.Enabled = false;
            btnNhapHang.Enabled = false;
            panNguyenLieu.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand sql_cmnd = new SqlCommand("sp_XoaNguyenLieu ", connection);
            sql_cmnd.CommandType = CommandType.StoredProcedure;
            sql_cmnd.Parameters.AddWithValue("@idNguyenLieu", SqlDbType.Int).Value = int.Parse(txtid.Text);
            sql_cmnd.ExecuteNonQuery();
            MessageBox.Show("Xóa Nguyên liệu thành công!", "Thông báo");
            LoadKhoHang();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            txtSLNhapKho.Enabled = true;
            Them = 2;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            btnLoad.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnThoat.Enabled = false;
            btnNhapHang.Enabled = false;

            txtTenNguyenLieu.Enabled = false;
            txtSoLuong.Enabled = false;
            txtDonVi.Enabled = false;
            panNguyenLieu.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadKhoHang();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Them == 1)
            {
                try
                {
                    SqlCommand sql_cmnd = new SqlCommand("sp_ThemNguyenLieu", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@TenNguyenLieu", SqlDbType.NVarChar).Value = txtTenNguyenLieu.Text;
                    sql_cmnd.Parameters.AddWithValue("@SoLuong", SqlDbType.Int).Value = int.Parse(txtSoLuong.Text);
                    sql_cmnd.Parameters.AddWithValue("@DonViTinh", SqlDbType.NVarChar).Value = txtDonVi.Text;
                    sql_cmnd.ExecuteNonQuery();

                    LoadKhoHang();

                    MessageBox.Show("Thêm Nguyên liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi " + ex.Message, "lỗi");
                }
            }
            else if (Them == 0)
            {
                try
                {
                    SqlCommand sql_cmnd = new SqlCommand("sp_SuaNguyenLieu", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@idNguyenLieu", SqlDbType.Int).Value = int.Parse(txtid.Text);
                    sql_cmnd.Parameters.AddWithValue("@TenNguyenLieu", SqlDbType.NVarChar).Value = txtTenNguyenLieu.Text;
                    sql_cmnd.Parameters.AddWithValue("@SoLuong", SqlDbType.Int).Value = int.Parse(txtSoLuong.Text);
                    sql_cmnd.Parameters.AddWithValue("@DVTinh", SqlDbType.NVarChar).Value = txtDonVi.Text;
                    sql_cmnd.ExecuteNonQuery();

                    LoadKhoHang();


                    MessageBox.Show("Sửa Nguyên liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi " + ex.Message, "lỗi");
                }
            }
            else
            {
                try
                {
                    SqlCommand sql_cmnd = new SqlCommand("sp_SuaNguyenLieu", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@idNguyenLieu", SqlDbType.Int).Value = int.Parse(txtid.Text);
                    sql_cmnd.Parameters.AddWithValue("@TenNguyenLieu", SqlDbType.NVarChar).Value = txtTenNguyenLieu.Text;
                    sql_cmnd.Parameters.AddWithValue("@SoLuong", SqlDbType.Int).Value = int.Parse(txtSoLuong.Text) + int.Parse(txtSLNhapKho.Text);
                    sql_cmnd.Parameters.AddWithValue("@DVTinh", SqlDbType.NVarChar).Value = txtDonVi.Text;
                    sql_cmnd.ExecuteNonQuery();

                    LoadKhoHang();


                    MessageBox.Show("Nhập Hàng thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi " + ex.Message, "lỗi");
                }
            }
        }
    }
}
