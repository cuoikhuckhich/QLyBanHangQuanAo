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

namespace QLyBanHangQuanAo
{
    public partial class frmTheLoai : Form
    {
        public frmTheLoai()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();
        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            string connectionString = " Data Source = localhost\\SQLEXPRESS; Initial Catalog = QlyBanHangQuanAo; Integrated Security = True";
            con.ConnectionString = connectionString;
            con.Open();
            loadDataGridView();

        }
        private void loadDataGridView()
        {
            string sql = "Select * from TheLoai";
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable tableTheLoai = new DataTable();
            adp.Fill(tableTheLoai);
            DataGridView_TheLoai.DataSource = tableTheLoai;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaloai.Text = "";
            txtTenloai.Text = "";
            txtMaloai.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaloai.Text == "")
            {
                MessageBox.Show("Ban can nhap Ma Loai");
                txtMaloai.Focus();
                return;
            }
            if (txtTenloai.Text == "")
            {
                MessageBox.Show("Ban can nhap Ten loai");
                txtTenloai.Focus();
                return;
            }
            string sql="insert into TheLoai values ( '"+txtMaloai.Text+"','"+txtTenloai.Text+"')";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.ExecuteNonQuery();
            loadDataGridView();
        }

        private void DataGridView_TheLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaloai.Text = DataGridView_TheLoai.CurrentRow.Cells["MaLoai"].Value.ToString();
            txtTenloai.Text= DataGridView_TheLoai.CurrentRow.Cells["TenLoai"].Value.ToString();
            txtMaloai.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sqldelete = "DELETE from TheLoai Where Maloai=@Maloai";
            SqlCommand cmd = new SqlCommand(sqldelete,con);
            cmd.Parameters.AddWithValue("Maloai", txtMaloai.Text);
            cmd.Parameters.AddWithValue("Tenloai", txtTenloai.Text);
            cmd.ExecuteNonQuery();
            loadDataGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sqlupdate = "update TheLoai set Maloai ='" + txtMaloai.Text + "',Tenloai='" + txtTenloai.Text + "'where(Maloai='" + txtMaloai + "')";
            SqlCommand cmd = new SqlCommand(sqlupdate,con);
            cmd.ExecuteNonQuery();
            loadDataGridView();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
