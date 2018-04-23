using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NW_Pos
{
    public partial class frmSalesOrder : Form
    {
        public frmSalesOrder()
        {
            InitializeComponent();
            datetimepicker.Value = DateTime.Now;
        }

        private void bunifuTileButton1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            this.Show();
            frmCustomerReport cusreport = new frmCustomerReport();
            cusreport.Show();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuMaterialTextbox7_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void frmSalesOrder_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox9_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel9_Click(object sender, EventArgs e)
        {

        }
    }
}
