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
    public partial class frmLogin : Form
    {
        SqlConnection conn = connectionDB.constring();
        SqlCommand cmd = new SqlCommand();
        frmMain main = new frmMain();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(1);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //frmMain main = new frmMain();
            //main.Show();
            if(txtEmail.Text == ""){
                errorEmail.SetError(txtEmail, "Email cannot be empty!");
                errorPassword.Clear();
            }
            else if (txtPassword.Text == "")
            {
                errorPassword.SetError(txtPassword, "Password cannot be empty!");
                errorEmail.Clear();
            }
            else {
                check_login();
            }            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegister register = frmRegister.getInstance();
            register.Show();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }


        private static frmLogin instance;
        public static frmLogin getInstance()
        {

            if (instance == null || instance.IsDisposed)
                instance = new frmLogin();
            else
                instance.BringToFront();
            return instance;
        }

        void check_login() {

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT first_name, last_name, type, email, password, delete_status FROM register WHERE email='" + txtEmail.Text + "' and password='" + txtPassword.Text + "' and delete_status='1'";
                //MySqlDataAdapter da = new MySqlDataAdapter();
                //da.SelectCommand = cmd;
                SqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                int count = 0;
                string username = "";
                string first_name = "";
                string last_name = "";
                string type = "";
                
                string pass = Convert.ToString(txtPassword.Text);
                while (myReader.Read())
                {
                    count = count + 1;
                    username = (myReader["email"].ToString());
                    first_name = (myReader["first_name"].ToString());
                    last_name = (myReader["last_name"].ToString());
                    type = (myReader["type"].ToString());
                }
                if (count == 1 /*&& pass.Any(char.IsUpper) && pass.Any(char.IsLower)*/)
                {
                    this.Hide();
                    //getuserdata();
                    frmMain main = frmMain.getInstance();
                    //frmMain main = new frmMain();
                    main.Show();
                    //main.label3.Text = username;
                    main.lblFirst.Text = first_name.ToUpper() + " " + last_name.ToUpper();
                    main.lbltype.Text = type;
                }
                else
                {
                    MessageBox.Show("Please check your Email or Password!", "Error Login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                    txtEmail.Text = "";
                    txtPassword.Text = "•••••••••";
                    txtEmail.Focus();
                }
                conn.Close();
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
                
        }
    }
}
