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
    public partial class FrmChatLieu : Form
    {
        SqlConnection con = new SqlConnection();
        public FrmChatLieu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//nút thêm
        {
            txtMachatlieu.Text = "";
            txtTenchatlieu.Text = "";
            txtMachatlieu.Enabled = true;

        }
        private void loadDataGridView()
        {
            string sql = "Select * from ChatLieu";
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable tableChatLieu = new DataTable();
            adp.Fill(tableChatLieu);
            DataGridView_ChatLieu.DataSource = tableChatLieu;
        }
        private void FrmChatLieu_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QlyBanHangQuanAo;Integrated Security=True";
            con.ConnectionString = connectionString;
            con.Open();
            loadDataGridView();
        }

        private void DataGridView_ChatLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMachatlieu.Text = DataGridView_ChatLieu.CurrentRow.Cells["Machatlieu"].Value.ToString();
            txtTenchatlieu.Text = DataGridView_ChatLieu.CurrentRow.Cells["Tenchatlieu"].Value.ToString();
            txtMachatlieu.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string Sql = "DELETE FROM ChatLieu WHERE Machatlieu= @Machatlieu";
            SqlCommand cmd = new SqlCommand(Sql, con);
            cmd.Parameters.AddWithValue("Machatlieu", txtMachatlieu.Text);
            cmd.Parameters.AddWithValue("Tenchatlieu", txtTenchatlieu.Text);
            cmd.ExecuteNonQuery();
            loadDataGridView();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE ChatLieu SET Machatlieu='" + txtMachatlieu.Text + "',Tenchatlieu='" + txtTenchatlieu.Text + "' Where (Machatlieu='" + txtMachatlieu.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            loadDataGridView();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (txtMachatlieu.Text == "")
            {
                MessageBox.Show("Ban can nhap Ma Chat Lieu");
                txtMachatlieu.Focus();
                return;
            }
            if (txtTenchatlieu.Text == "")
            {
                MessageBox.Show("Ban can nhap Ten chat lieu");
                txtTenchatlieu.Focus();
                return;
            }
            string sql = "insert into Chatlieu values('" + txtMachatlieu.Text + "','" + txtTenchatlieu.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            loadDataGridView();
        }
    }
}
