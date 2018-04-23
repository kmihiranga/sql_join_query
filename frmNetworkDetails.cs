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
    public partial class Network : Form
    {
        SqlConnection conn = connectionDB.constring();
        SqlCommand cmd = new SqlCommand();
        frmClientDetails obj = (frmClientDetails)Application.OpenForms["frmClientDetails"];
        frmJobReminder obj2 = (frmJobReminder)Application.OpenForms["frmJobReminder"];

        public Network()
        {
            InitializeComponent();         
        }      
                
        private static Network instance;
        public static Network getInstance() {

            if (instance == null || instance.IsDisposed)
                instance = new Network();
            else
                instance.BringToFront();
            return instance;
        }
      

        // refresh table when delete another table same job no
        public void loaddata()
        {
            load_table();
        }
       

        private void bunifuTileButton11_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain main = frmMain.getInstance();
            main.Show();
        }

        // save details to table

        void save() {

            try
            {
                //check before item exist in table
                string check = @"(select count(*) from network where job_no='" + txtJobNo.Text + "')";
                SqlCommand cmd = new SqlCommand("insert into network(job_no, domain_name, active_dt, deactive_dt, reminder_dt, port_no, router_model, wlan_key, ip_address, username, password, note, delete_status) values('" + txtJobNo.Text + "', '" + txtDomain.Text + "', '" + txtStartDate.Text + "', '" + dateDeactive.Text + "', '" + dateReminder.Text + "', '" + txtportno.Text + "', '" + cmbRouter.Text + "', '" + txtwlankey.Text + "', '" + txtipaddress.Text + "', '" + txtuser.Text + "', '" + txtpass.Text + "', '" + txtdescription.Text + "', '1')", conn);
                conn.Open();
                SqlCommand cmda = new SqlCommand(check, conn);
                int count = (int)cmda.ExecuteScalar();
                if (count > 0)
                {

                    MessageBox.Show("This job no already exist or not in job details. Please enter different number", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Network settings saved Successfully!", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                conn.Close();
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                if (conn.State == ConnectionState.Open)
                {

                    conn.Close();
                }
            }
            clear();
            load_table();
        }

        private void btnJob_Click(object sender, EventArgs e)
        {

        }

        // view data on grid view

        public void load_table() {

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT job_no AS 'Job No', domain_name AS 'Domain Name', active_dt AS 'Active Date', deactive_dt AS 'Deactive Date', reminder_dt AS 'Reminder Date', router_model AS 'Router', ip_address AS 'Ip Address', port_no AS 'Port', wlan_key AS 'Wireless Password', username AS 'Username', password AS 'Password', note AS 'Description' FROM network where delete_status=1";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridViewnetwork.DataSource = dt;
                conn.Close();
                dataGridViewnetwork.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewnetwork.AllowUserToResizeColumns = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridViewnetwork.Sort(dataGridViewnetwork.Columns[0], ListSortDirection.Descending);//filter category by ascending
            dataGridViewnetwork.AllowUserToAddRows = false;
        }// end load data 

        // clear textboxes

        void clear() {

            txtJobNo.Text = "";
            txtDomain.Text = "";
            txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateDeactive.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateReminder.Text = DateTime.Now.ToString("yyyy-MM-dd");
            cmbRouter.Text = "Dialog";
            txtipaddress.Text = "";
            txtportno.Text = "";
            txtwlankey.Text = "";
            txtuser.Text = "";
            txtpass.Text = "";
            txtdescription.Text = "";
            txtJobNo.Focus();

        }

        private void frmNetworkDetails_Load(object sender, EventArgs e, string value)
        {
            txtJobNo.Focus();
            load_table();
            txtJobNo.Text = value; 
        }

        private void bunifuTileButton12_Click(object sender, EventArgs e)
        {
            clear();
            load_table();
        }

        private void dataGridViewnetwork_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewnetwork.Rows[e.RowIndex];

                txtJobNo.Text = row.Cells[0].Value.ToString();
                txtDomain.Text = row.Cells[1].Value.ToString();
                txtStartDate.Text = row.Cells[2].Value.ToString();
                dateDeactive.Text = row.Cells[3].Value.ToString();
                dateReminder.Text = row.Cells[4].Value.ToString();
                cmbRouter.Text = row.Cells[5].Value.ToString();
                txtipaddress.Text = row.Cells[6].Value.ToString();
                txtportno.Text = row.Cells[7].Value.ToString();
                txtwlankey.Text = row.Cells[8].Value.ToString();
                txtuser.Text = row.Cells[9].Value.ToString();
                txtpass.Text = row.Cells[10].Value.ToString();
                txtdescription.Text = row.Cells[11].Value.ToString();               
            }
        }

        void update() {

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update network set domain_name='" + txtDomain.Text + "', active_dt='" + txtStartDate.Text + "', deactive_dt='" + dateDeactive.Text + "', reminder_dt='" + dateReminder.Text + "', router_model='" + cmbRouter.Text + "', ip_address='" + txtipaddress.Text + "', port_no='" + txtportno.Text + "', wlan_key='" + txtwlankey.Text + "', username='" + txtuser.Text + "', password='" + txtpass.Text + "', note='" + txtdescription.Text + "' where job_no='" + txtJobNo.Text + "'";
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Network settings updated successfully!", "Update details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
                clear();
                load_table();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          
        }

        private void dateReminder_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmNetworkDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frmMain main = null;

            //if (main == null)
            //{

            //    main = new frmMain();
            //    main.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    main.Close();
            //    main = null;
            //}        
            //system_notify_tray();
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
        }

        void remove() {
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update network set delete_status='0' where job_no='" + txtJobNo.Text + "'";
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {

                    MessageBox.Show("Network settings deleted successfully!", "Delete details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
                remove_client();
                remove_job();
                clear();
                load_table();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        void remove_client() {

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update client set delete_status='0' where job_no='" + txtJobNo.Text + "'";
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {

                   // MessageBox.Show("Network settings deleted successfully!", "Delete details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void remove_job() {
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update jodDetails set delete_id='0' where job_no='" + txtJobNo.Text + "'";
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {

                   // MessageBox.Show("Network settings deleted successfully!", "Delete details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // search domain
        void search_domain() {

            try
            {
                SqlConnection conn = connectionDB.constring();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT job_no AS 'Job No', domain_name AS 'Domain Name', active_dt AS 'Active Date', deactive_dt AS 'Deactive Date', reminder_dt AS 'Reminder Date', router_model AS 'Router', ip_address AS 'Ip Address', port_no AS 'Port', wlan_key AS 'Wireless Password', username AS 'Username', password AS 'Password', note AS 'Description' FROM network where delete_status='1' and network.domain_name LIKE '%" + txtdm.Text + "%'", conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dataGridViewnetwork.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void search_job() {

            try
            {
                SqlConnection conn = connectionDB.constring();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT job_no AS 'Job No', domain_name AS 'Domain Name', active_dt AS 'Active Date', deactive_dt AS 'Deactive Date', reminder_dt AS 'Reminder Date', router_model AS 'Router', ip_address AS 'Ip Address', port_no AS 'Port', wlan_key AS 'Wireless Password', username AS 'Username', password AS 'Password', note AS 'Description' FROM network where delete_status='1' and network.job_no LIKE '%" + txtjob.Text + "%'", conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dataGridViewnetwork.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            load_table();
        }

        private void txtdm_TextChanged(object sender, EventArgs e)
        {
            search_domain();
        }

        private void txtjob_TextChanged(object sender, EventArgs e)
        {
            search_job();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {

            if (txtJobNo.Text == "")
            {

                errorJob.SetError(txtJobNo, "Job no cannot be empty!");
                errorDomain.Clear();
                erroractivedate.Clear();
                errorip.Clear();
            }
            else if (txtDomain.Text == "")
            {
                errorDomain.SetError(txtDomain, "Domain name cannot be empty!");
                errorJob.Clear();
                erroractivedate.Clear();
                errorip.Clear();
            }
            else if (txtStartDate.Text == "")
            {
                erroractivedate.SetError(txtStartDate, "Domain active date cannot be empty!");
                errorDomain.Clear();
                errorJob.Clear();
                errorip.Clear();
            }
            else if (txtipaddress.Text == "")
            {
                errorip.SetError(txtipaddress, "Router ip address cannot be empty!");
                errorDomain.Clear();
                errorJob.Clear();
                erroractivedate.Clear();
            }
            else
            {
                save();
            }
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            if (txtJobNo.Text == "")
            {
                errorJob.SetError(txtJobNo, "Job no cannot be empty!");
                errorDomain.Clear();
                erroractivedate.Clear();
                errorip.Clear();
            }
            else if (txtDomain.Text == "")
            {
                errorDomain.SetError(txtDomain, "Domain name cannot be empty!");
                errorJob.Clear();
                erroractivedate.Clear();
                errorip.Clear();
            }
            else {
                DialogResult exit;
                exit = MessageBox.Show("Are you want to update this record", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (exit == DialogResult.Yes)
                {
                    try
                    {
                        update();
                        //obj.loaddata();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }   
            }
            
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            if (txtJobNo.Text == "")
            {
                errorJob.SetError(txtJobNo, "Job no cannot be empty!");
                errorDomain.Clear();
                erroractivedate.Clear();
                errorip.Clear();
            }
            else if (txtDomain.Text == "")
            {
                errorDomain.SetError(txtDomain, "Domain name cannot be empty!");
                errorJob.Clear();
                erroractivedate.Clear();
                errorip.Clear();
            }
            else {
                DialogResult exit;
                exit = MessageBox.Show("Are you want to delete this record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (exit == DialogResult.Yes)
                {
                    try
                    {
                        remove();
                        //obj2.loaddata();
                        //obj.loaddata();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }
            
          
        }

        private void Network_Load(object sender, EventArgs e)
        {
            txtJobNo.Text = frmJobReminder.passingValue;
            load_table();
        }

        private void Network_SizeChanged(object sender, EventArgs e)
        {
            //system_notify_tray();
        }

        

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
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
