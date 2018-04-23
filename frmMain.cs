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
    public partial class frmMain : Form
    {
        SqlConnection conn = connectionDB.constring();
        SqlCommand cmd = new SqlCommand();
        public string first_name;
        public string last_name;
        public frmMain()
        {
            InitializeComponent();
            panelLeft.Height = btnDashboard.Height;
            panelLeft.Top = btnDashboard.Top;
        }

        //prevent open exist form twice
        private static frmMain instance;
        public static frmMain getInstance()
        {

            if (instance == null || instance.IsDisposed)
                instance = new frmMain();
            else
                instance.BringToFront();
            return instance;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnDashboard.Height;
            panelLeft.Top = btnDashboard.Top;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnProfile.Height;
            panelLeft.Top = btnProfile.Top;
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnBackup.Height;
            panelLeft.Top = btnBackup.Top;
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnCalendar.Height;
            panelLeft.Top = btnCalendar.Top;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnSettings.Height;
            panelLeft.Top = btnSettings.Top;
        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNotification notify = frmNotification.getInstance();
            notify.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmJobReminder job = new frmJobReminder();
            job.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            frmJobReminder job = new frmJobReminder();
            this.Hide();
            frmClientDetails customer = frmClientDetails.getInstance();
            customer.Show();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSummeryTable summery = new frmSummeryTable();
            summery.Show();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblreminder.Text = DateTime.Now.ToString("yyyy-MM-dd");
            search_reminder_date();
            //lblFirst.Text = first_name.ToUpper();
            if (cmbreminder.Text.Length > 0)
            {
                //MessageBox.Show("You have to remind domain name for renew customer payment", "Check domain name", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                DialogResult exit;
                exit = MessageBox.Show("You have some domain names to be expire. Are you want to check these domain names now?", "Check domain name", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (exit == DialogResult.Yes)
                {
                    frmNotification summery = new frmNotification();
                    summery.ShowDialog();
                }
            }
        }

        void search_reminder_date() {

            try
            {
                SqlConnection conn = connectionDB.constring();
                SqlDataAdapter adapter = new SqlDataAdapter("select job_no, reminder_dt, delete_status from network where reminder_dt like '%" + lblreminder.Text + "%' and delete_status='1'", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmbreminder.DataSource = dt;
                cmbreminder.ValueMember = "job_no";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Environment.Exit(1);
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Network network = new Network();
            network.Show();
            
        }

        private void bunifuTileButton13_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
        }

        
    }
}
