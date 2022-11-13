using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N19_restaurant_management_software
{
    public partial class frmNhanVien : Form
    {
        bool Them = false;
        public frmNhanVien()
        {
            InitializeComponent();
            LoadNhanVien();
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            loadComboBoxChucVu();
        }

        public void LoadNhanVien()
        {
            using(var db = new N19_QuanLyQuanAnEntities())
            {
                List<object> list = new List<object>
            {
                new
                {
                    GioiTinh = "1",
                    DisplayName = "Nam",
                },
                new
                {
                    GioiTinh = "0",
                    DisplayName = "Nữ"
                }
            };
                GioiTinh.DataSource = list;
                GioiTinh.DisplayMember = "DisplayName";
                GioiTinh.ValueMember = "GioiTinh";
                var nhanviens = db.frm_NhanVien.ToList();
                dgvNV.DataSource = nhanviens;
            }

            BindingData();


            //enable and disable component
            txtMSNV.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            panThongTinCaNhan.Enabled = false;
            panThongTinLienLac.Enabled = false;

            panDSNV.Enabled = true;
            btnLamMoi.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThoat.Enabled = true;
        }

        void BindingData()
        {
            //remove binding before add binding
            txtMSNV.DataBindings.Clear();
            txtHoTen.DataBindings.Clear();
            txtSoDienThoai.DataBindings.Clear();
            txtDiaChiThuongTru.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtCMND.DataBindings.Clear();
            txtChucVu.DataBindings.Clear();
            txtLuong.DataBindings.Clear();
            txtNgaySinh.DataBindings.Clear();
            txtNgayVaoLam.DataBindings.Clear();
            cBChucVu.DataBindings.Clear();

            //add data binding
            txtMSNV.DataBindings.Add("Text", dgvNV.DataSource, "ID");
            txtHoTen.DataBindings.Add("Text", dgvNV.DataSource, "Ho_ten");
            txtSoDienThoai.DataBindings.Add("Text", dgvNV.DataSource, "So_dien_thoai");
            txtDiaChiThuongTru.DataBindings.Add("Text", dgvNV.DataSource, "Dia_chi");
            txtCMND.DataBindings.Add("Text", dgvNV.DataSource, "CMND");
            txtEmail.DataBindings.Add("Text", dgvNV.DataSource, "Email");
            cBChucVu.DataBindings.Add("Text", dgvNV.DataSource, "Chuc_vu");
            txtLuong.DataBindings.Add("Text", dgvNV.DataSource, "Luong");
            txtNgaySinh.DataBindings.Add("Text", dgvNV.DataSource, "Ngay_sinh");
            txtNgayVaoLam.DataBindings.Add("Text", dgvNV.DataSource, "Ngay_vao_lam");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;

            txtMSNV.ResetText();
            txtHoTen.ResetText();
            txtCMND.ResetText();
            txtDiaChiThuongTru.ResetText();
            txtEmail.ResetText();
            txtSoDienThoai.ResetText();
            txtNgaySinh.ResetText();
            txtChucVu.ResetText();
            txtNgayVaoLam.ResetText();
            txtLuong.ResetText();

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            panThongTinCaNhan.Enabled = true;
            panThongTinLienLac.Enabled = true;

            panDSNV.Enabled = false;
            btnLamMoi.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThoat.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            panThongTinCaNhan.Enabled = true;
            panThongTinLienLac.Enabled = true;

            panDSNV.Enabled = false;
            btnLamMoi.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThoat.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them == true)
            {
                try
                {
                    string sql = "execute sp_ThemNhanVien @name,@gioiTinh,@ngaySinh,@ngayVaoLam,@soDienThoai,@diaChi,@CMND,@email,@luong,@chucVu";
                    using(var db = new N19_QuanLyQuanAnEntities())
                    {
                        db.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("@name",txtHoTen.Text.ToString()),
                            new SqlParameter("@diaChi", txtDiaChiThuongTru.Text.ToString()),
                            new SqlParameter("@email", txtEmail.Text.ToString()),
                            new SqlParameter("@gioiTinh", getGioiTinh()),
                            new SqlParameter("@ngaySinh", txtNgaySinh.Text),
                            new SqlParameter("@ngayVaoLam", txtNgayVaoLam.Text),
                            new SqlParameter("@soDienThoai", txtSoDienThoai.Text.ToString()),
                            new SqlParameter("@CMND", txtCMND.Text.ToString()),
                            new SqlParameter("@luong", Int32.Parse(txtLuong.Text.ToString())),
                            new SqlParameter("@chucVu", Int32.Parse(txtChucVu.Text.ToString()))
                            );
                        LoadNhanVien();
                    }
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.ToString());
                
                }

            }
            else
            {
                try
                {
                    string sql = "execute sp_SuaNhanVien @id,@name,@gioiTinh,@ngaySinh,@ngayVaoLam,@phone,@diaChi,@CMND,@email,@luong,@idChucVu";
                    using (var db = new N19_QuanLyQuanAnEntities())
                    {
                        db.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("@id", Int32.Parse(txtMSNV.Text.ToString())),
                            new SqlParameter("@name", txtHoTen.Text.ToString()),
                            new SqlParameter("@diaChi", txtDiaChiThuongTru.Text.ToString()),
                            new SqlParameter("@email", txtEmail.Text.ToString()),
                            new SqlParameter("@gioiTinh", getGioiTinh()),
                            new SqlParameter("@ngaySinh", txtNgaySinh.Text),
                            new SqlParameter("@ngayVaoLam", txtNgayVaoLam.Text),
                            new SqlParameter("@phone", txtSoDienThoai.Text.ToString()),
                            new SqlParameter("@CMND", txtCMND.Text.ToString()),
                            new SqlParameter("@luong", Int32.Parse(txtLuong.Text.ToString())),
                            new SqlParameter("@idChucVu",Int32.Parse(txtChucVu.Text.ToString()))
                            );
                        LoadNhanVien();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }

            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "execute sp_XoaNhanVien @id";
                using (var db = new N19_QuanLyQuanAnEntities())
                {
                    db.Database.ExecuteSqlCommand(sql,
                        new SqlParameter("@id", Int32.Parse(txtMSNV.Text.ToString())));
                    LoadNhanVien();
                }
                MessageBox.Show("Xóa Nhân viên thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi: " + ex.Message, "lỗi");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private char getGioiTinh()
        {
            if(radTrue.Checked == true)
            {
                return '1';
            }
            return '0';
        }
        private void getNgaySinh()
        {
            string ngay = dTPNgaySinh.Value.ToString("MM/dd/yyyy");
            txtNgaySinh.Text = ngay;
        }
        private void getNgayVaoLam()
        {
            string ngay = dTPNgaySinh.Value.ToString("MM/dd/yyyy");
            txtNgayVaoLam.Text = ngay;
        }



        private void loadComboBoxChucVu()
        {
            using(var db = new N19_QuanLyQuanAnEntities())
            {
                var chucvus = db.ChucVus.ToList();
                foreach(var i in chucvus)
                {
                    cBChucVu.Items.Add(i.TenChucVu.ToString());
                }
            }
        }

        private void cBChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            using(var db = new N19_QuanLyQuanAnEntities())
            {

                    var chucvu = db.ChucVus.FirstOrDefault(s => s.TenChucVu == cBChucVu.SelectedItem.ToString());
                    txtChucVu.Text = chucvu.idChucVu.ToString();

            }
        }

        private void dTPNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            getNgaySinh();
        }

        private void dTPNgayVaoLam_ValueChanged(object sender, EventArgs e)
        {
            getNgayVaoLam();
        }

        private void txtChucVu_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvNV.CurrentCell.RowIndex;
                if (dgvNV.Rows[r].Cells[2].Value.ToString()=="1")
                    radTrue.Checked = true;
                else
                    radfalse.Checked = true;
            }
            catch
            {

            }

        }


    }
}
