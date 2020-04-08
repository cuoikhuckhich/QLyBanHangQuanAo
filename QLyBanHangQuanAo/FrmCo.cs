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
    public partial class FrmCo : Form
    {
        public FrmCo()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();
        private void loadDataGridView()
        {
            string sql = "Select * from Co";
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable tableCo = new DataTable();
            adp.Fill(tableCo);
            DataGridView_Co.DataSource = tableCo;
        }

        private void FrmCo_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QlyBanHangQuanAo;Integrated Security=True";
            con.ConnectionString = connectionString;
            con.Open();
            loadDataGridView();

        }

        private void DataGridView_Co_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaco.Text = DataGridView_Co.CurrentRow.Cells["Maco"].Value.ToString();
            txtTenco.Text = DataGridView_Co.CurrentRow.Cells["Tenco"].Value.ToString();
            txtMaco.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaco.Text = "";
            txtTenco.Text = "";
            txtMaco.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Co SET Maco='" + txtMaco.Text + "',Tenco='" + txtTenco.Text + "' Where (Maco='" + txtMaco.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            loadDataGridView();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (txtMaco.Text == "")
            {
                MessageBox.Show("Ban can nhap Ma Co");
                txtMaco.Focus();
                return;
            }
            if (txtTenco.Text == "")
            {
                MessageBox.Show("Ban can nhap Ten Quan ao");
                txtTenco.Focus();
                return;
            }
            string sql = "insert into Co values('" + txtMaco.Text + "','" + txtTenco.Text + "')";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.ExecuteNonQuery();
            loadDataGridView();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string Sql = "DELETE FROM Co WHERE Maco= @MaCo";
            SqlCommand cmd = new SqlCommand(Sql,con);
            cmd.Parameters.AddWithValue("Maco", txtMaco.Text);
            cmd.Parameters.AddWithValue("Tenco", txtTenco.Text);
            cmd.ExecuteNonQuery();
            loadDataGridView();
        }
    }
}
