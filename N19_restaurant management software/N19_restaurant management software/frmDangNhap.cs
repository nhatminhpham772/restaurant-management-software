using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N19_restaurant_management_software
{
    public partial class frmDangNhap : Form
    {
        private readonly DbContext dbContext = null;
        public frmDangNhap()
        {
            InitializeComponent();
            dbContext = new N19_QuanLyQuanAnEntities();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtPassWord.Focus();
        }

        private void txtPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnLogin.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Login() == 2)
            {
                this.Hide();
                frmBanAn frmBanAn = new frmBanAn();
                frmBanAn.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài Khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int Login()
        {
            var sql = "SELECT dbo.KiemTraDangNhap(@userName,@passWord)";
            var r = dbContext.Database.SqlQuery<int>(sql, 
                new SqlParameter("@userName",txtUsername.Text.ToString()),
                new SqlParameter("@passWord", txtPassWord.Text.ToString())
                );
            return r.First(); 
    
        }
    }
}
