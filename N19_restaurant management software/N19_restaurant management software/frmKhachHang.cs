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
    public partial class frmKhachHang : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-P2BSC4LO;Initial Catalog = N19_QuanLyQuanAn; User ID = sa; Password=hoang2002");
        public frmKhachHang()
        {
            InitializeComponent();
            connection.Open();
        }

        string query = "SELECT * FROM frm_KhachHang";
        void LoadData()
        {
            string query = "SELECT * FROM frm_KhachHang";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            dataGridView1.DataSource = dt;
           
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                connection.Open();
                string query = "sp_ThemKhachHang";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HoTen", nameTxt.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", genTxt.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", DateTime.Parse(dateTxt.Text));
                cmd.Parameters.AddWithValue("@SoDienThoai", sdtTxt.Text);
                cmd.Parameters.AddWithValue("@CMND", cmndTxt.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Them thanh cong!");
                LoadData();
            }
            catch
            {
                MessageBox.Show("That bai");
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                i = dataGridView1.CurrentRow.Index;
            }
            catch
            {
                return;
            }
            idTxt.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            nameTxt.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dateTxt.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            genTxt.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            sdtTxt.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            cmndTxt.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "sp_SuaKhachHang";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idKhachHang", idTxt.Text);
                cmd.Parameters.AddWithValue("@HoTen", nameTxt.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", DateTime.Parse(dateTxt.Text));
                cmd.Parameters.AddWithValue("@GioiTinh", genTxt.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", sdtTxt.Text);
                cmd.Parameters.AddWithValue("@CMND", cmndTxt.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cap nhat thanh cong!");
                LoadData();
            }
            catch
            {
                MessageBox.Show("That bai");
            }
            finally
            {
                connection.Close();
            }
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "sp_XoaKhachHang";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idKhachHang", idTxt.Text);
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoa thanh cong!");
                LoadData();
            }
            catch
            {
                MessageBox.Show("That bai");
            }
            finally
            {
                connection.Close();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM dbo.TimKhachHang(@TenKhachHang)";
                SqlCommand cmd = new SqlCommand(query, connection);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenKhachHang", searchTxt.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tìm thành công!");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("That bai");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
