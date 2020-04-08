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
    public partial class FrmSanPham : Form
    {
        public FrmSanPham()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaquanao.Text = "";
            txtTenquanao.Text = "";
            txtMaloai.Text = "";
            txtMaco.Text = "";
            txtMachatlieu.Text = "";
            txtMamau.Text = "";
            txtMadoituong.Text = "";
            txtMamua.Text = "";
            txtMaNSX.Text = "";
            txtSoluong.Text = "";
            txtAnh.Text = "";
            txtĐongiaban.Text = "";
            txtĐongianhap.Text = "";
            txtMaquanao.Enabled = true;
          

        }
        private void loadDataGridView()
        {
            string sql = "Select * from SanPham";
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable tableSanPham = new DataTable();
            adp.Fill(tableSanPham);
            DataGridView_SanPham.DataSource = tableSanPham;
        }


        private void FrmSanPham_Load(object sender, EventArgs e)
        {

            string connectionString = " Data Source = localhost\\SQLEXPRESS; Initial Catalog = QlyBanHangQuanAo; Integrated Security = True";
                con.ConnectionString = connectionString;
                con.Open();
                loadDataGridView();
            

        }

        private void DataGridView_SanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaquanao.Text = DataGridView_SanPham.CurrentRow.Cells["Maquanao"].Value.ToString();
            txtTenquanao.Text = DataGridView_SanPham.CurrentRow.Cells["Tenquanao"].Value.ToString();
            txtMaloai.Text = DataGridView_SanPham.CurrentRow.Cells["Maloai"].Value.ToString();
            txtMaco.Text = DataGridView_SanPham.CurrentRow.Cells["Maco"].Value.ToString();
            txtMachatlieu.Text = DataGridView_SanPham.CurrentRow.Cells["Machatlieu"].Value.ToString();
            txtMamau.Text = DataGridView_SanPham.CurrentRow.Cells["Mamau"].Value.ToString();
            txtMadoituong.Text = DataGridView_SanPham.CurrentRow.Cells["Madoituong"].Value.ToString();
            txtMamua.Text = DataGridView_SanPham.CurrentRow.Cells["Mamua"].Value.ToString();
            txtMaNSX.Text = DataGridView_SanPham.CurrentRow.Cells["MaNSX"].Value.ToString();
            txtSoluong.Text = DataGridView_SanPham.CurrentRow.Cells["Soluong"].Value.ToString();
            txtAnh.Text = DataGridView_SanPham.CurrentRow.Cells["Anh"].Value.ToString();
            txtĐongianhap.Text = DataGridView_SanPham.CurrentRow.Cells["Đongianhap"].Value.ToString();
            txtĐongiaban.Text = DataGridView_SanPham.CurrentRow.Cells["Đongiaban"].Value.ToString();
            txtMaquanao.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
                string sql = @" UPDATE SanPham SET
                        Maquanao=N'" + txtMaquanao.Text + @"',Tenquanao =N'" + txtTenquanao.Text + @"',Maloai =N'" + txtMaloai.Text + @"'
                      ,Maco =N'" + txtMaco.Text + @"',Machatlieu =N'" + txtMachatlieu.Text + @"',Mamau =N'" + txtMamau.Text + @"',Madoituong =N'" + txtMadoituong.Text + @"'
                      ,Mamua =N'" + txtMamua.Text + @"',MaNSX =N'" + txtMaNSX.Text + @"',Soluong =N'" + txtSoluong.Text + @"',Anh =N'" + txtAnh.Text + @"',Đongianhap =N'" + txtĐongianhap.Text + @"',Đongiaban =N'" + txtĐongiaban.Text + @"'
                     Where (Maquanao=N'" + txtMaquanao.Text + @"')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                loadDataGridView();
            


        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
                if (txtMaquanao.Text == "")
                {
                    MessageBox.Show("Ban can nhap Ma quan ao");
                    txtMaquanao.Focus();
                    return;
                }
                if (txtTenquanao.Text == "")
                {
                    MessageBox.Show("Ban can nhap Ten Quan ao");
                    txtTenquanao.Focus();
                    return;
                }
            if (txtMaloai.Text == "")
            {
                txtMaloai.Focus();
                return;
            }
            if (txtMaco.Text == "")
            {
                txtMaco.Focus();
                return;
            }
            if (txtMachatlieu.Text == "")
            {
                txtMachatlieu.Focus();
                return;
            }
            if (txtMamau.Text == "")
            {
                txtMamau.Focus();
                return;
            }
            if (txtMadoituong.Text == "")
            {
                txtMadoituong.Focus();
                return;
            }
            if (txtMamua.Text == "")
            {
                txtMamua.Focus();
                return;
            }
            if (txtMaNSX.Text == "")
            {
                txtMaNSX.Focus();
                return;
            }
            if (txtAnh.Text == "")
            {
                txtAnh.Focus();
                return;
            }
            else
                {
                string sql = "insert into SanPham Values('" + txtMaquanao.Text + "','" + txtTenquanao.Text + "','" + txtMaloai.Text + "','" + txtMaco.Text
                + "','" + txtMachatlieu.Text + "','" + txtMamau.Text + "','" + txtMadoituong.Text + "','" + txtMamua.Text + "','" + txtMaNSX.Text + "','" + txtAnh.Text + "'";
                if(txtSoluong.Text!="")
                {
                    sql = sql + "," + txtSoluong.Text.Trim();
                }    
                if(txtĐongianhap.Text!="")
                {
                    sql = sql + "," + txtĐongianhap.Text.Trim();
                }
                if (txtĐongiaban.Text != "")
                {
                    sql = sql + "," + txtSoluong.Text.Trim();
                }

                sql = sql + ")";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                loadDataGridView();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM SanPham WHERE Maquanao = @Maquanao";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("Maquanao", txtMaquanao.Text);
            cmd.Parameters.AddWithValue("Tenquanao", txtTenquanao.Text);
            cmd.Parameters.AddWithValue("Maloai", txtMaloai.Text);
            cmd.Parameters.AddWithValue("Maco", txtMaco.Text);
            cmd.Parameters.AddWithValue("Machatlieu", txtMachatlieu.Text);
            cmd.Parameters.AddWithValue("Mamau", txtMamau.Text);
            cmd.Parameters.AddWithValue("Madoituong", txtMadoituong.Text);
            cmd.Parameters.AddWithValue("Mamua", txtMamua.Text);
            cmd.Parameters.AddWithValue("MaNSX", txtMaNSX.Text);
            cmd.Parameters.AddWithValue("Soluong", txtSoluong.Text);
            cmd.Parameters.AddWithValue("Anh", txtAnh.Text);
            cmd.Parameters.AddWithValue("Đongiaban", txtĐongiaban.Text);
            cmd.Parameters.AddWithValue("Đongianhap", txtĐongianhap.Text);
            cmd.ExecuteNonQuery();
            loadDataGridView();
        }
    }
   
}
