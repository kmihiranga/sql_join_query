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
    public partial class frmClientDetails : Form
    {
        SqlConnection conn = connectionDB.constring();
        SqlCommand cmd = new SqlCommand();
        //frmNetworkDetails network = new frmNetworkDetails();
        Network obj = (Network)Application.OpenForms["Network"];
        frmJobReminder obj2 = (frmJobReminder)Application.OpenForms["frmJobReminder"];
        Network network;
        frmJobReminder job;
        public frmClientDetails()
        {
            InitializeComponent();
            txtJobNo.Text = frmJobReminder.passingValue;
        }

        public void loaddata()
        {
            load_data();
        }

        //prevent open exist window
        private static frmClientDetails instance;
        public static frmClientDetails getInstance()
        {

            if (instance == null || instance.IsDisposed)
                instance = new frmClientDetails();
            else
                instance.BringToFront();
            return instance;
        }
        private void status_SelectedIndexChanged(object sender, EventArgs e)
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void routeStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        // save client details
        void save() {

            try
            {
                //check before item exist in table
                string check = @"(select count(*) from client where job_no='" + txtJobNo.Text + "')";
                SqlCommand cmd = new SqlCommand("insert into client(job_no, name, email, address, phone, location, agreement_duration, duration_type, status, deactive_date, router_model, router_qty, delete_status) values('" + txtJobNo.Text + "', '" + txtname.Text + "', '" + txtemail.Text + "', '" + txtaddress.Text + "', '" + txtphone.Text + "', '" + txtlocation.Text + "', '" + txtduration.Text + "', '" + cmbtype.Text + "', '" + status.Text + "', '" + dateDeactive.Text + "', '" + txtmodel.Text + "', '" + txtqty.Text + "', '1')", conn);
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
                    MessageBox.Show("Client details saved Successfully!", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
                clear();
                load_data();               
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
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            
        }

        // clear textboxes
        void clear() {

            txtJobNo.Clear();
            txtname.Clear();
            txtemail.Clear();
            txtaddress.Clear();
            txtphone.Clear();
            txtlocation.Clear();
            txtduration.Clear();
            cmbtype.Text = "Day";
            status.Text = "Active";
            dateDeactive.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtmodel.Text = "Dialog";
            txtqty.Clear();
            txtJobNo.Focus();
        }

        void load_data() {

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT job_no AS 'Job No', name AS 'Name', location AS 'Location', address AS 'Address', phone AS 'Phone', location AS 'Location', agreement_duration AS 'Duration', duration_type AS 'Measure', status AS 'Status', deactive_date AS 'Deactive Date', router_model AS 'Router Model', router_qty AS 'QTY' FROM client where delete_status=1";
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
        }

        private void frmClientDetails_Load(object sender, EventArgs e)
        {
            txtJobNo.Text = frmJobReminder.passingValue;
            load_data();           
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView.Rows[e.RowIndex];

                txtJobNo.Text = row.Cells[0].Value.ToString();
                txtname.Text = row.Cells[1].Value.ToString();
                txtemail.Text = row.Cells[2].Value.ToString();
                txtaddress.Text = row.Cells[3].Value.ToString();
                txtphone.Text = row.Cells[4].Value.ToString();
                txtlocation.Text = row.Cells[5].Value.ToString();
                txtduration.Text = row.Cells[6].Value.ToString();
                cmbtype.Text = row.Cells[7].Value.ToString();
                status.Text = row.Cells[8].Value.ToString();
                dateDeactive.Text = row.Cells[9].Value.ToString();
                txtmodel.Text = row.Cells[10].Value.ToString();
                txtqty.Text = row.Cells[11].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        // update client details
        void update() {

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update client set name='"+txtname.Text+"', email='"+txtemail.Text+"', address='"+txtaddress.Text+"', phone='"+txtphone.Text+"', location='"+txtlocation.Text+"', agreement_duration='"+txtduration.Text+"', duration_type='"+cmbtype.Text+"', status='"+status.Text+"', deactive_date='"+dateDeactive.Text+"', router_model='"+txtmodel.Text+"', router_qty='"+txtqty.Text+"' where job_no='"+txtJobNo.Text+"'";
                int i = cmd.ExecuteNonQuery();
                if(i > 0){

                    MessageBox.Show("Client details updated successfully!", "Update details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
                clear();
                load_data();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
   
        }

        // delete method

        void delete() {

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update client set name='" + txtname.Text + "', email='" + txtemail.Text + "', address='" + txtaddress.Text + "', phone='" + txtphone.Text + "', location='" + txtlocation.Text + "', agreement_duration='" + txtduration.Text + "', duration_type='" + cmbtype.Text + "', status='" + status.Text + "', deactive_date='" + dateDeactive.Text + "', router_model='" + txtmodel.Text + "', router_qty='" + txtqty.Text + "', delete_status='0' where job_no='"+txtJobNo.Text+"'";                
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Client details deleted successfully!", "Delete details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
                delete_network();
                delete_job();
                clear();
                load_data();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void delete_network() {

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update network set delete_status='0' where job_no='" + txtJobNo.Text + "'";
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    //MessageBox.Show("Client details deleted successfully!", "Delete details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
                //clear();
                //load_data();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //delete job details
        void delete_job() {
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update jodDetails set delete_id='0' where job_no='" + txtJobNo.Text + "'";
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    //MessageBox.Show("Client details deleted successfully!", "Delete details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmClientDetails_Load_1(object sender, EventArgs e)
        {
            //txtJobNo.Text = value;     
            
        }

        private void btnHome_Click(object sender, EventArgs e)
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

            this.Hide();
            frmMain main = frmMain.getInstance();
            main.Show();
        }

        private void frmClientDetails_FormClosing(object sender, FormClosingEventArgs e)
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
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            load_data();
        }


        void search_name() {

            try
            {
                SqlConnection conn = connectionDB.constring();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT job_no AS 'Job No', name AS 'Name', location AS 'Location', address AS 'Address', phone AS 'Phone', location AS 'Location', agreement_duration AS 'Duration', duration_type AS 'Measure', status AS 'Status', deactive_date AS 'Deactive Date', router_model AS 'Router Model', router_qty AS 'QTY' FROM client where delete_status='1' and client.name LIKE '%" + txtnm.Text + "%'", conn);
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
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT job_no AS 'Job No', name AS 'Name', location AS 'Location', address AS 'Address', phone AS 'Phone', location AS 'Location', agreement_duration AS 'Duration', duration_type AS 'Measure', status AS 'Status', deactive_date AS 'Deactive Date', router_model AS 'Router Model', router_qty AS 'QTY' FROM client where delete_status='1' and client.job_no LIKE '%" + txtjob.Text + "%'", conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dataGridView.DataSource = data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtnm_TextChanged(object sender, EventArgs e)
        {
            search_name();
        }

        private void txtjob_TextChanged(object sender, EventArgs e)
        {
            search_job();
        }

        private void txtphone_Leave(object sender, EventArgs e)
        {
           
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

        private void bunifuTileButton12_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void bunifuTileButton13_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtJobNo.Text == "")
            {

                errorjob.SetError(txtJobNo, "Job no cannot be empty!");
                errorname.Clear();
                errorphone.Clear();
                errordeactive.Clear();
            }
            else if (txtname.Text == "")
            {

                errorname.SetError(txtname, "Client name cannot be empty!");
                errorjob.Clear();
                errorphone.Clear();
                errordeactive.Clear();
            }
            else if (txtphone.Text == "")
            {

                errorphone.SetError(txtphone, "Phone number cannot be empty!");
                errorname.Clear();
                errorjob.Clear();
                errordeactive.Clear();
            }
            else
            {
                save();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show("Are you want to Update this record", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (exit == DialogResult.Yes)
            {
                if (txtname.Text == "")
                {

                    errorname.SetError(txtname, "Name cannot be empty!");
                    errorjob.Clear();
                    errorphone.Clear();
                    errordeactive.Clear();
                }
                else if (txtphone.Text == "")
                {

                    errorphone.SetError(txtphone, "Phone no cannot be empty!");
                    errorjob.Clear();
                    errorname.Clear();
                    errordeactive.Clear();
                }
                else
                {

                    update();//call update method
                }

            }   
        }

        private void btnRemoveData_Click(object sender, EventArgs e)
        {

            if (txtname.Text == "")
            {
                errorname.SetError(txtname, "Client name cannot be empty!");
                errorjob.Clear();
                errorphone.Clear();
                errordeactive.Clear();
            }
            else
            {
                DialogResult exit;
                exit = MessageBox.Show("Are you want to delete this record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (exit == DialogResult.Yes)
                {
                    try
                    {                     
                        if(network != null){
                            obj.loaddata();
                            delete();
                        }
                        else if (job != null)
                        {
                            obj2.loaddata();
                            delete();
                        }
                        else {
                            delete();
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }      
        }
       

      
    }
}
