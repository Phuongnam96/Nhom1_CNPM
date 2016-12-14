using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom1_CNPM
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Main mMenu = new Main();
            if(txtTenDangNhap.Text == "admin" && txtMatKhau.Text == "admin")
            {
                MessageBox.Show("Bạn đã đăng nhập thành công!", "Thành công", MessageBoxButtons.OK);
                mMenu.Show();
                this.Hide();
            }
            else if(txtTenDangNhap.Text != "admin" || txtMatKhau.Text != "admin")
            {
                if(MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai!", "Thất bại", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    txtTenDangNhap.Focus();
                else
                    this.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
            else
                txtTenDangNhap.Focus();
        }
    }
}
