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
    public partial class frmSummeryTable : Form
    {
        SqlConnection conn = connectionDB.constring();
        SqlCommand cmd = new SqlCommand();
        public frmSummeryTable()
        {
            InitializeComponent();
        }

        private void frmSummeryTable_Load(object sender, EventArgs e)
        {
            load_table();
        }

        void load_table() {

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT client.job_no AS 'Job No', client.name AS 'Client Name', client.phone AS 'Phone', client.email AS 'Email', client.location AS 'Location', client.status AS 'Status', network.domain_name AS 'Domain Name', network.router_model AS 'Router Model', network.ip_address AS 'Ip Address', network.port_no AS 'Port No', network.deactive_dt AS 'Expire Date', network.note AS 'Note' FROM client INNER JOIN network on client.job_no=network.job_no WHERE client.delete_status='1'";
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

        private void dataGridViewSummery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmSummeryView summery = frmSummeryView.getInstance();
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

        private void bunifuTileButton11_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain main = frmMain.getInstance();
            main.Show();
        }

        private void frmSummeryTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        void search_phone() {

            try
            {
                SqlConnection conn = connectionDB.constring();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT client.job_no AS 'Job No', client.name AS 'Client Name', client.phone AS 'Phone', client.email AS 'Email', client.location AS 'Location', client.status AS 'Status', network.domain_name AS 'Domain Name', network.router_model AS 'Router Model', network.ip_address AS 'Ip Address', network.port_no AS 'Port No', network.deactive_dt AS 'Expire Date', network.note AS 'Note' FROM client INNER JOIN network on client.job_no=network.job_no WHERE client.delete_status='1' and client.phone LIKE '%" + txtphone.Text + "%'", conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dataGridViewSummery.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        void search_domain() {

            try
            {
                SqlConnection conn = connectionDB.constring();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT client.job_no AS 'Job No', client.name AS 'Client Name', client.phone AS 'Phone', client.email AS 'Email', client.location AS 'Location', client.status AS 'Status', network.domain_name AS 'Domain Name', network.router_model AS 'Router Model', network.ip_address AS 'Ip Address', network.port_no AS 'Port No', network.deactive_dt AS 'Expire Date', network.note AS 'Note' FROM client INNER JOIN network on client.job_no=network.job_no WHERE client.delete_status='1' and network.domain_name LIKE '%" + txtdm.Text + "%'", conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dataGridViewSummery.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtjob_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void bunifuTileButton12_Click(object sender, EventArgs e)
        {
            txtphone.Clear();
            //txtjob.Clear();
            //txtjob.Focus();
            txtdm.Clear();
            txtphone.Focus();
            load_table();
        }

        private void txtdm_TextChanged(object sender, EventArgs e)
        {
            search_domain();
        }

        private void dateDeactive_ValueChanged(object sender, EventArgs e)
        {
            search_expire_dt();
        }

        void search_expire_dt() {

            try
            {
                SqlConnection conn = connectionDB.constring();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT client.job_no AS 'Job No', client.name AS 'Client Name', client.phone AS 'Phone', client.email AS 'Email', client.location AS 'Location', client.status AS 'Status', network.domain_name AS 'Domain Name', network.router_model AS 'Router Model', network.ip_address AS 'Ip Address', network.port_no AS 'Port No', network.deactive_dt AS 'Expire Date', network.note AS 'Note' FROM client INNER JOIN network on client.job_no=network.job_no WHERE client.delete_status='1' and network.deactive_dt LIKE '%" + dateDeactive.Text + "%' and client.status='Active'", conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dataGridViewSummery.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void search_active() {
            try
            {
                SqlConnection conn = connectionDB.constring();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT client.job_no AS 'Job No', client.name AS 'Client Name', client.phone AS 'Phone', client.email AS 'Email', client.location AS 'Location', client.status AS 'Status', network.domain_name AS 'Domain Name', network.router_model AS 'Router Model', network.ip_address AS 'Ip Address', network.port_no AS 'Port No', network.deactive_dt AS 'Expire Date', network.note AS 'Note' FROM client INNER JOIN network on client.job_no=network.job_no WHERE client.delete_status='1' and client.status='Active' ", conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dataGridViewSummery.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtphone_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void txtphone_TextChanged_2(object sender, EventArgs e)
        {
            search_phone();
        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 45)
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }
            txtphone.MaxLength = 10;
        }

        void search_expired() {

            try
            {
                SqlConnection conn = connectionDB.constring();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT client.job_no AS 'Job No', client.name AS 'Client Name', client.phone AS 'Phone', client.email AS 'Email', client.location AS 'Location', client.status AS 'Status', network.domain_name AS 'Domain Name', network.router_model AS 'Router Model', network.ip_address AS 'Ip Address', network.port_no AS 'Port No', network.deactive_dt AS 'Expire Date', network.note AS 'Note' FROM client INNER JOIN network on client.job_no=network.job_no WHERE client.delete_status='1' and network.deactive_dt<='"+DateTime.Now.ToString("yyyy-MM-dd")+"' and client.status='Active'", conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dataGridViewSummery.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void deactive() {
            try
            {
                SqlConnection conn = connectionDB.constring();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT client.job_no AS 'Job No', client.name AS 'Client Name', client.phone AS 'Phone', client.email AS 'Email', client.location AS 'Location', client.status AS 'Status', network.domain_name AS 'Domain Name', network.router_model AS 'Router Model', network.ip_address AS 'Ip Address', network.port_no AS 'Port No', network.deactive_dt AS 'Expire Date', network.note AS 'Note' FROM client INNER JOIN network on client.job_no=network.job_no WHERE client.delete_status='1' and client.status='Deactive'", conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dataGridViewSummery.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtype.Text == "Expired")
            {
                search_expired();
            }
            else if(cmbtype.Text == "Active"){
                search_active();
            }
            else if(cmbtype.Text == "Deactive"){
                deactive();
            }
        }

        private void cmbtype_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbtype_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuTileButton13_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
        }

    }
}
