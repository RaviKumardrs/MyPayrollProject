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
using System.Configuration;

namespace PayrollApplication
{
    public partial class PayrollCalculatorForm : Form
    {
        string FullName = string.Empty;

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

        private void btnGetEmployee_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select FirstName,LastName,NINumber from tblEmployee where EmployeeId="+txtEmployeeId.Text+"", con);
            try
            {
                SqlDataReader dr= cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtFirstName.Text = dr[0].ToString();
                    txtLastName.Text = dr[1].ToString();
                    txtNINumber.Text = dr[2].ToString();
                    FullName = txtFirstName.Text + " " + txtLastName.Text;
                    lblEmployeeFullName.Text = FullName;
                }

                else
                {
                    MessageBox.Show("No Employee Found with Employee Id "+txtEmployeeId.Text,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message");
            }

            finally
            {
                con.Close();
            }
        }
    }
}
