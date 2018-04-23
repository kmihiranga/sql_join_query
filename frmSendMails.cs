using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace NW_Pos
{
    public partial class frmSendMails : Form
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;

        public frmSendMails()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                login = new NetworkCredential(txtusername.Text, txtpassword.Text);
                client = new SmtpClient(txtsmtp.Text);
                client.Port = Convert.ToInt32(txtport.Text);
                client.EnableSsl = chkssl.Checked;
                client.Credentials = login;
                msg = new MailMessage { From = new MailAddress(txtusername.Text + txtsmtp.Text.Replace("smtp.", "@"), "kalana", Encoding.UTF8) };
                msg.To.Add(new MailAddress(txtTo.Text));
                if (!string.IsNullOrEmpty(txtCC.Text))
                    msg.To.Add(new MailAddress(txtCC.Text));
                msg.Subject = txtSubject.Text;
                msg.Body = txtmessage.Text;
                msg.BodyEncoding = Encoding.UTF8;
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.Normal;
                msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                string userstate = "Sending.....";
                client.SendAsync(msg, userstate);
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {

            if (e.Cancelled) {
                MessageBox.Show(string.Format("{0} send cancelled", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Error != null)
            {
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("Your message has been successfully sent", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                
            }
            
                
        }

       void clear() {

            txtTo.Clear();
            txtCC.Clear();
            txtSubject.Clear();
            txtmessage.Clear();
            txtusername.Clear();
            txtpassword.Clear();
            txtTo.Focus();        
        }
    }
}
