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
    public partial class frmJobReminder : Form
    {
        // define connection class

        SqlConnection conn = connectionDB.constring();
        SqlCommand cmd = new SqlCommand();
        public static string passingValue;
        //frmClientDetails obj = (frmClientDetails)Application.OpenForms["frmClientDetails"];
        //Network obj2 = (Network)Application.OpenForms["frmNetworkDetails"];

        public frmJobReminder()
        {
            InitializeComponent();
        }

        public void loaddata()
        {
            select_data();
        }
       
        private void status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(status.Text == "Deactive" ){

                lblDeactive.Visible = true;
                dateDeactive.Visible = true;
            }
            else if(status.Text == "Active"){

                lblDeactive.Visible = false;
                dateDeactive.Visible = false;
            }
        }

        private void updateStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(updateStatus.Text == "Yes"){
                
                lblExtend.Visible = true;
                lblExpire.Visible = true;
                dateExtend.Visible = true;
                dateExpire.Visible = true;

            }
            else if(updateStatus.Text == "No"){

                lblExtend.Visible = false;
                lblExpire.Visible = false;
                dateExtend.Visible = false;
                dateExpire.Visible = false;
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //bool isOpen = false;
            //foreach (Form f in Application.OpenForms)
            //{
            //    if (f.Text == "Network")
            //    {
            //        isOpen = true;
            //        f.BringToFront();
            //        break;
            //    }
            //}
            //if (isOpen == false)
            //{
            //    //check_job();
            //    //MessageBox.Show("already open");
            //    frmSummeryTable table = new frmSummeryTable();
            //    table.Show();
            //}

            passingValue = txtJobNo.Text;
            check_job();  
                     
        }

        // check job no
        void check_job()
        {
            if (txtJobNo.Text == "")
            {

                MessageBox.Show("Please enter a job number before add network settings", "Error job no", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string check = @"select count(*) from jodDetails where job_no='" + txtJobNo.Text + "'";
                conn.Open();
                SqlCommand cmda = new SqlCommand(check, conn);
                int count = (int)cmda.ExecuteScalar();
                if (count > 0)
                {
                    Network frm = Network.getInstance();
                    frm.Show();
                    frm.btnHome.Visible = false;
                }
                else
                {
                    MessageBox.Show("Job no " + txtJobNo.Text + " is not in database. please save job no and enter network settings", "Error job no", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();

            }
        
        }

        private void bunifuTileButton11_Click(object sender, EventArgs e)
        {
            //frmMain main = null;

            //if(main == null){

            //    main = new frmMain();
            //    main.Show();
            //    this.Hide();
            //}
            //else{
            //    main.Close();
            //    main = null;
            //}
            this.Hide();
            frmMain main = frmMain.getInstance();
            main.Show();
        }

        // insert data 

        void insert() {

            try
            {
                string check = @"(select count(*) from jodDetails where job_no='" + txtJobNo.Text + "')";
                SqlCommand cmd = new SqlCommand("insert into jodDetails(job_no, date_now, name, invoice, quatation, location, ag_start, duration, du_type, end_date, reminder, status, deactive_dt, description, domain_update, extend_dt, expire_dt, delete_id) values ('" + txtJobNo.Text + "', '" + txtdate.Text + "', '" + txtCustomer.Text + "', '" + txtinvoice.Text + "', '" + txtQuatation.Text + "', '" + txtLocation.Text + "', '" + txtStartDate.Text + "', '" + txtDuration.Text + "', '" + cmbtype.Text + "', '" + txtEndDate.Text + "', '" + txtReminderDate.Text + "', '" + status.Text + "', '" + dateDeactive.Text + "', '" + txtDescription.Text + "', '" + updateStatus.Text + "', '" + dateExtend.Text + "', '" + dateExpire.Text + "', '1')", conn);
                conn.Open();
                SqlCommand cmda = new SqlCommand(check, conn);
                int count = (int)cmda.ExecuteScalar();
                if (count > 0)
                {

                    MessageBox.Show("This job no already exist. Please enter different number", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Job details added successfully to reminder domain", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                conn.Close();
                clear();
                select_data();              

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
        }// end insert function

        // clear textbox

        void clear() {

            txtJobNo.Text = "";
            txtdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtCustomer.Text = "";
            txtinvoice.Text = "";
            txtQuatation.Text = "";
            txtLocation.Text = "";
            txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtDuration.Text = "";
            cmbtype.Text = "Day";
            txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtReminderDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            status.Text = "Active";
            dateDeactive.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtDescription.Text = "";
            updateStatus.Text = "No";
            dateExtend.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateExpire.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtJobNo.ReadOnly = false;
            txtJobNo.Focus();
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void frmJobReminder_Load(object sender, EventArgs e)
        {
            txtJobNo.Focus();
            select_data();
        } // end insert

        // select data from table

        void select_data() {

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT job_no AS 'Job No', date_now AS 'Date', name AS 'NAME', invoice AS 'Invoice', quatation AS 'Quatation', location AS 'Location', ag_start AS 'Agreement Start', duration AS 'Duration', du_type AS 'Type', end_date AS 'End Date', reminder AS 'Reminder Date', status AS 'Status', deactive_dt AS 'Deactive Date', description AS 'Description', domain_update AS 'Domain Update', extend_dt AS 'Extend Date', expire_dt AS 'Domain Expire' FROM jodDetails where delete_id=1";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView.DataSource = dt;
                conn.Close();
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView.AllowUserToResizeColumns = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView.Sort(dataGridView.Columns[0], ListSortDirection.Descending);//filter category by ascending
            dataGridView.AllowUserToAddRows = false;
        }// end select data

        private void status_TextChanged(object sender, EventArgs e)
        {
            if (status.Text == "Deactive")
            {

                lblDeactive.Visible = true;
                dateDeactive.Visible = true;
            }
            else if (status.Text == "Active")
            {

                lblDeactive.Visible = false;
                dateDeactive.Visible = false;
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (txtJobNo.Text == "")
            {
                MessageBox.Show("Please enter a job number before add client details", "Error job no", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                this.Show();
                frmClientDetails client = new frmClientDetails();
                client.Show();
            }            
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView.Rows[e.RowIndex];

                txtJobNo.Text = row.Cells[0].Value.ToString();
                txtdate.Text = row.Cells[1].Value.ToString();
                txtCustomer.Text = row.Cells[2].Value.ToString();
                txtinvoice.Text = row.Cells[3].Value.ToString();
                txtQuatation.Text = row.Cells[4].Value.ToString();
                txtLocation.Text = row.Cells[5].Value.ToString();
                txtStartDate.Text = row.Cells[6].Value.ToString();
                txtDuration.Text = row.Cells[7].Value.ToString();
                cmbtype.Text = row.Cells[8].Value.ToString();
                txtEndDate.Text = row.Cells[9].Value.ToString();
                txtReminderDate.Text = row.Cells[10].Value.ToString();
                status.Text = row.Cells[11].Value.ToString();
                dateDeactive.Text = row.Cells[12].Value.ToString();
                txtDescription.Text = row.Cells[13].Value.ToString();
                updateStatus.Text = row.Cells[14].Value.ToString();
                dateExtend.Text = row.Cells[15].Value.ToString();
                dateExpire.Text = row.Cells[16].Value.ToString();
                txtJobNo.ReadOnly = true;
            }
        }

        private void bunifuTileButton12_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void customerForm_Click(object sender, EventArgs e)
        {
            passingValue = txtJobNo.Text;
            if (txtJobNo.Text == "")
            {
                MessageBox.Show("Please enter a job number before add client details", "Error job no", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {

                string check = @"select count(*) from jodDetails where job_no='" + txtJobNo.Text + "'";
                conn.Open();
                SqlCommand cmda = new SqlCommand(check, conn);
                int count = (int)cmda.ExecuteScalar();
                if (count > 0)
                {
                    frmClientDetails frm = frmClientDetails.getInstance();
                    frm.Show();
                    frm.btnHome.Visible = false;

                }
                else
                {
                    MessageBox.Show("Job no " + txtJobNo.Text + " is not in database. please save first and add a new client", "Error job no", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
        }

        private void frmJobReminder_FormClosing(object sender, FormClosingEventArgs e)
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
            Application.Exit();
            Environment.Exit(1);
        }

        // update method
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        { 

        }

        void update() {

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update jodDetails set date_now='" + txtdate.Text + "', name='" + txtCustomer.Text + "', invoice='" + txtinvoice.Text + "', quatation='" + txtQuatation.Text + "', location='" + txtLocation.Text + "', ag_start='" + txtStartDate.Text + "', duration='" + txtDuration.Text + "', du_type='" + cmbtype.Text + "', end_date='" + txtEndDate.Text + "', reminder='" + txtReminderDate.Text + "', status='" + status.Text + "', deactive_dt='" + dateDeactive.Text + "', description='" + txtDescription.Text + "', domain_update='" + updateStatus.Text + "', extend_dt='" + dateExtend.Text + "', expire_dt='" + dateExpire.Text + "' where job_no='" + txtJobNo.Text + "'";
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {

                    MessageBox.Show("Job details updated successfully!", "Update details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
                clear();
                select_data();
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        
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
                cmd.CommandText = "update jodDetails set delete_id='0' where job_no='" + txtJobNo.Text + "'";
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {

                    MessageBox.Show("Job details deleted successfully!", "Delete details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
                remove_client();
                remove_network();
                clear();
                select_data();
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

                   // MessageBox.Show("Job details deleted successfully!", "Delete details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void remove_network() {

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update network set delete_status='0' where job_no='" + txtJobNo.Text + "'";
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {

                    // MessageBox.Show("Job details deleted successfully!", "Delete details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            select_data();
        }

        void search_name() {

            try
            {
                SqlConnection conn = connectionDB.constring();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT job_no AS 'Job No', date_now AS 'Date', name AS 'NAME', invoice AS 'Invoice', quatation AS 'Quatation', location AS 'Location', ag_start AS 'Agreement Start', duration AS 'Duration', du_type AS 'Type', end_date AS 'End Date', reminder AS 'Reminder Date', status AS 'Status', deactive_dt AS 'Deactive Date', description AS 'Description', domain_update AS 'Domain Update', extend_dt AS 'Extend Date', expire_dt AS 'Domain Expire' FROM jodDetails where delete_id='1' and jodDetails.name LIKE '%" + txtname.Text + "%'", conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dataGridView.DataSource = data;
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
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT job_no AS 'Job No', date_now AS 'Date', name AS 'NAME', invoice AS 'Invoice', quatation AS 'Quatation', location AS 'Location', ag_start AS 'Agreement Start', duration AS 'Duration', du_type AS 'Type', end_date AS 'End Date', reminder AS 'Reminder Date', status AS 'Status', deactive_dt AS 'Deactive Date', description AS 'Description', domain_update AS 'Domain Update', extend_dt AS 'Extend Date', expire_dt AS 'Domain Expire' FROM jodDetails where delete_id='1' and jodDetails.job_no LIKE '%" + txtjob.Text + "%'", conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dataGridView.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            search_name();
        }

        private void txtjob_TextChanged(object sender, EventArgs e)
        {
            search_job();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {

            if (txtJobNo.Text == "")
            {
                errorJobNo.SetError(txtJobNo, "Job No cannot be empty!");
                errorName.Clear();
                errorDuration.Clear();
            }
            else if (txtdate.Text == "")
            {
                errorDate.SetError(txtdate, "Date cannot be empty!");
                errorJobNo.Clear();
                errorName.Clear();
                errorDuration.Clear();
            }
            else if (txtCustomer.Text == "")
            {
                errorName.SetError(txtCustomer, "Customer name cannot be empty!");
                errorJobNo.Clear();
                errorDuration.Clear();
            }
            else if (txtDuration.Text == "")
            {
                errorDuration.SetError(txtDuration, "Agreement duration cannot be empty!");
                errorJobNo.Clear();
                errorName.Clear();
            }
            else
            {
                insert();
            }
            
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
              if (txtCustomer.Text == "")
                {
                    errorName.SetError(txtCustomer, "Customer name cannot be empty!");
                    errorJobNo.Clear();
                    errorDuration.Clear();
                    errorDate.Clear();
                }
              else if(txtJobNo.Text == ""){
                  errorJobNo.SetError(txtJobNo, "Job no cannot be empty!");
                  errorName.Clear();
                  errorDuration.Clear();
                  errorDate.Clear();
              }
                else if (txtDuration.Text == "")
                {
                    errorDuration.SetError(txtDuration, "Agreement duration cannot be empty!");
                    errorName.Clear();
                    errorJobNo.Clear();
                    errorDate.Clear();
                }
                else
                {
                     DialogResult exit;
                    exit = MessageBox.Show("Are you want to Update this record", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (exit == DialogResult.Yes)
                    {
                        update();
                    }
                }

            
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            if (txtJobNo.Text == "")
            {
                errorJobNo.SetError(txtJobNo, "Job no cannot be empty!");
                errorName.Clear();
                errorDuration.Clear();
                errorDate.Clear();
            }
            else if(txtCustomer.Text == "")
            {
                errorName.SetError(txtname, "Name cannot be empty");
                errorJobNo.Clear();
                errorDuration.Clear();
                errorDate.Clear();
            }
            else {
                DialogResult exit;
                exit = MessageBox.Show("Are you want to Delete this record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (exit == DialogResult.Yes)
                {
                    try
                    {
                        remove();
                        //obj.loaddata();
                        //obj2.loaddata();
                        open_forms_check();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }           
        }// end remove

        void open_forms_check() {

            try
            {
                frmClientDetails client = null;
                Network network = null;

                if (client == null && network == null)
                {
                                      
                }
                else
                {
                    //obj.loaddata();
                    //obj2.loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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
