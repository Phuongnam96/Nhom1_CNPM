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

namespace QL1
{
    public partial class Form1 : Form
    {
        private SqlConnection con;
        public Form1()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}

        //private void button3_Click(object sender, EventArgs e)
        //{

        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            string constring = @"Data Source=KJ2A98ZIASLT6VD\SQLEXPRESS;Initial Catalog=SinhVien;Integrated Security=True";
            con = new SqlConnection(constring);
            con.Open();
            HienThi();

        }
        private void HienThi()
        {
            string SqlSelect = "SELECT [MaLop],[TenLop],[GiaoVien] FROM [dbo].[QLLop]";
            SqlCommand cmd = new SqlCommand(SqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvHienThi.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = MessageBox.Show("Bạn có muốn thêm không.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dg == DialogResult.Yes)
            {
                int c = 0;
                for (int i = 0; i < dgvHienThi.RowCount; i++)
                {
                    if (txtMaLop.Text == Convert.ToString(dgvHienThi.Rows[i].Cells[0].Value))
                    {
                        MessageBox.Show("Mã lớp đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        c = 1;
                    }
                    MessageBox.Show(c.ToString());
                }
                if (c == 1)
                {
                    string SqlInsert = "INSERT INTO [dbo].[QLLop]([MaLop],[TenLop],[GiaoVien]) VALUES('" + txtMaLop.Text + "','" + txtTenLop.Text + "','" + txtGiaoVienDay.Text + "')";
                    SqlCommand cmd = new SqlCommand(SqlInsert, con);
                    cmd.ExecuteNonQuery();
                    HienThi();
                }
            }
            else
            {
                this.Close();
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = MessageBox.Show("Bạn có muốn sửa không.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dg == DialogResult.Yes)
            {
                string MaLop = Convert.ToString(dgvHienThi.Rows[dgvHienThi.CurrentCell.RowIndex].Cells[0].Value);
                string SqlUpdate = "UPDATE [dbo].[QLLop] SET [MaLop] = '" + txtMaLop.Text + "',[TenLop] = '" + txtTenLop.Text + "',[GiaoVien] = '" + txtGiaoVienDay.Text + "' WHERE [MaLop]='" + txtMaLop.Text + "'";
                SqlCommand cmd = new SqlCommand(SqlUpdate, con);
                cmd.ExecuteNonQuery();
                HienThi();
            }
            else
            {
                this.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = MessageBox.Show("Bạn có muốn xóa không.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dg == DialogResult.Yes)
            {
                string MaLop = Convert.ToString(dgvHienThi.Rows[dgvHienThi.CurrentCell.RowIndex].Cells[0].Value);
                string SqlDelete = "DELETE FROM [dbo].[QLLop] WHERE [MaLop]='" + txtMaLop.Text + "'";
                //MessageBox.Show(SqlDelete);
                SqlCommand cmd = new SqlCommand(SqlDelete, con);
                cmd.ExecuteNonQuery();
                HienThi();
            }
            else {
                this.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = MessageBox.Show("Bạn có muốn thoát không.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);

            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
