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
    public partial class frmThucDon : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-P2BSC4LO;Initial Catalog = N19_QuanLyQuanAn; User ID = sa; Password=hoang2002");
        public frmThucDon()
        {
            InitializeComponent();
            connection.Open();
        }

        string query = "SELECT * FROM frm_MonAn";
        void LoadData()
        {

            var cmd = new SqlCommand(query, connection);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            dataGridView1.DataSource = dt;

        }
        private void frmThucDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmThucDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {

                string query = "sp_ThemMonAn";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenMonAn", tenMonAnTxt.Text);
                cmd.Parameters.AddWithValue("@GiaTien", giaTienTxt.Text);
                cmd.Parameters.AddWithValue("@idDanhMuc", idDanhMucTxt.Text);
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

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {

                string query = "sp_SuaMonAn";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMonAn", idTxt.Text);
                cmd.Parameters.AddWithValue("@TenMonAn", tenMonAnTxt.Text);
                cmd.Parameters.AddWithValue("@GiaTien", giaTienTxt.Text);
                cmd.Parameters.AddWithValue("@idDanhMuc", idDanhMucTxt.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thanh cong!");
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
            tenMonAnTxt.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            giaTienTxt.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            idDanhMucTxt.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "sp_XoaMonAn";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMonAn", idTxt.Text);
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
    }
}
