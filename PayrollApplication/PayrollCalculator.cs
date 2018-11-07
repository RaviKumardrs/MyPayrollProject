using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollApplication
{
    public partial class PayrollCalculatorForm : Form
    {
        public PayrollCalculatorForm()
        {
            InitializeComponent();
        }

        private void btnComputePayment_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Compute Pay");
        }


        private void btnSavePay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save Payment");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reset");
        }

        private void btnGeneratePaySlip_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Generate Payslip");
        }

        private void btnPrintPaySlip_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Print Payslip");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
