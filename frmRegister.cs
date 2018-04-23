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
    public partial class frmRegister : Form
    {
        SqlConnection conn = connectionDB.constring();
        SqlCommand cmd = new SqlCommand();
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            txtFirst.Focus();
        }

        private static frmRegister instance;
        public static frmRegister getInstance()
        {

            if (instance == null || instance.IsDisposed)
                instance = new frmRegister();
            else
                instance.BringToFront();
            return instance;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = frmLogin.getInstance();
            login.Show();
        }

        void register() {

            try
            {
                //check before item exist in table
                string check = @"(select count(*) from register where email='" + txtEmail.Text + "')";
                SqlCommand cmd = new SqlCommand("insert into register(first_name, last_name, type, email, password, delete_status) values('" + txtFirst.Text + "', '" + txtLast.Text + "', '" + cmbType.Text + "', '" + txtEmail.Text + "', '" + txtPassword.Text + "', '1')", conn);
                conn.Open();
                SqlCommand cmda = new SqlCommand(check, conn);
                int count = (int)cmda.ExecuteScalar();
                if (count > 0)
                {

                    MessageBox.Show("This email already exist. Please enter different email", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account created Successfully!", "Create Successfully", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                conn.Close();
                clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void clear() {

            txtFirst.Clear();
            txtLast.Clear();
            cmbType.Text = "Administrator";
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirm.Clear();
            txtFirst.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtFirst.Text == ""){
                errorFirstName.SetError(txtFirst, "First name cannot be empty!");
                errorLastName.Clear();
                errorPass.Clear();
            }
            else if(txtLast.Text == ""){
                errorLastName.SetError(txtLast, "Last name cannot be empty!");
                errorFirstName.Clear();
                errorPass.Clear();
            }
            else if (txtPassword.Text == "")
            {
                errorPass.SetError(txtPassword, "Password cannot be empty!");
                errorFirstName.Clear();
                errorLastName.Clear();
            }
            else if(txtPassword.Text != txtConfirm.Text){
                MessageBox.Show("Password not match. please check confirm password", "Error password", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else {

                register();
            }
        }

        private void frmRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Environment.Exit(1);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clear();
        }
      
    }
}
