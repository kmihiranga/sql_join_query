using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NW_Pos
{
    public partial class frmNotification : Form
    {
        SqlConnection conn = connectionDB.constring();
        SqlCommand cmd = new SqlCommand();
        public frmNotification()
        {
            InitializeComponent();
        }

        private void frmNotification_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            load_table();
        }

        // prevent opening exist form
        private static frmNotification instance;
        public static frmNotification getInstance()
        {

            if (instance == null || instance.IsDisposed)
                instance = new frmNotification();
            else
                instance.BringToFront();
            return instance;
        }

        // load table data
        void load_table()
        {

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT client.job_no AS 'Job No', client.name AS 'Client Name', client.phone AS 'Phone', client.email AS 'Email', client.location AS 'Location', client.status AS 'Status', network.domain_name AS 'Domain Name', network.router_model AS 'Router Model', network.ip_address AS 'Ip Address', network.port_no AS 'Port No', network.deactive_dt AS 'Expire Date', network.note AS 'Note' FROM client INNER JOIN network on client.job_no=network.job_no WHERE client.delete_status='1' and network.reminder_dt='"+DateTime.Now.ToString("yyyy-MM-dd")+"'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridViewSummery.DataSource = dt;
                conn.Close();
                dataGridViewSummery.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewSummery.AllowUserToResizeColumns = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridViewSummery.Sort(dataGridViewSummery.Columns[0], ListSortDirection.Descending);//filter category by ascending
            dataGridViewSummery.AllowUserToAddRows = false;
        }

        private void bunifuTileButton11_Click(object sender, EventArgs e)
        {
        }

        private void frmNotification_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMain main = frmMain.getInstance();
            main.Show();
        }

        private void dataGridViewSummery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmSummeryView summery = new frmSummeryView();
            summery.Show();
            summery.txtJob.Text = this.dataGridViewSummery.CurrentRow.Cells[0].Value.ToString();
            summery.txtname.Text = this.dataGridViewSummery.CurrentRow.Cells[1].Value.ToString();
            summery.txtphone.Text = this.dataGridViewSummery.CurrentRow.Cells[2].Value.ToString();
            summery.txtemail.Text = this.dataGridViewSummery.CurrentRow.Cells[3].Value.ToString();
            summery.txtlocation.Text = this.dataGridViewSummery.CurrentRow.Cells[4].Value.ToString();
            summery.txtstatus.Text = this.dataGridViewSummery.CurrentRow.Cells[5].Value.ToString();
            summery.txtdomain.Text = this.dataGridViewSummery.CurrentRow.Cells[6].Value.ToString();
            summery.txtmodel.Text = this.dataGridViewSummery.CurrentRow.Cells[7].Value.ToString();
            summery.txtip.Text = this.dataGridViewSummery.CurrentRow.Cells[8].Value.ToString();
            summery.txtport.Text = this.dataGridViewSummery.CurrentRow.Cells[9].Value.ToString();
            summery.txtexpire.Text = this.dataGridViewSummery.CurrentRow.Cells[10].Value.ToString();
            summery.txtnote.Text = this.dataGridViewSummery.CurrentRow.Cells[11].Value.ToString();
        }

        void search_name() {
            try
            {
                SqlConnection conn = connectionDB.constring();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT client.job_no AS 'Job No', client.name AS 'Client Name', client.phone AS 'Phone', client.email AS 'Email', client.location AS 'Location', client.status AS 'Status', network.domain_name AS 'Domain Name', network.router_model AS 'Router Model', network.ip_address AS 'Ip Address', network.port_no AS 'Port No', network.deactive_dt AS 'Expire Date', network.note AS 'Note' FROM client INNER JOIN network on client.job_no=network.job_no WHERE client.delete_status='1' and network.reminder_dt='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and client.job_no LIKE '%" + txtcus.Text + "%'", conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dataGridViewSummery.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtcus_TextChanged(object sender, EventArgs e)
        {
            search_name();
        }

        private void bunifuTileButton13_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
        }
    }
}
