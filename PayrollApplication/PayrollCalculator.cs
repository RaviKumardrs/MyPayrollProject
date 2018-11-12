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
using System.Diagnostics;
using System.Globalization;

namespace PayrollApplication
{
    public partial class PayrollCalculatorForm : Form
    {

        #region ---Variables declarations


        string FullName = string.Empty;

        //Declaring variables for each day of the weeks
        double Mon1 = 0.00, Tues1 = 0.00, Wen1 = 0.00, Thurs1 = 0.00, Fri1 = 0.00, Sat1 = 0.00, Sun1 = 0.00;
        double Mon2 = 0.00, Tues2 = 0.00, Wen2 = 0.00, Thurs2 = 0.00, Fri2 = 0.00, Sat2 = 0.00, Sun2 = 0.00;
        double Mon3 = 0.00, Tues3 = 0.00, Wen3 = 0.00, Thurs3 = 0.00, Fri3 = 0.00, Sat3 = 0.00, Sun3 = 0.00;
        double Mon4 = 0.00, Tues4 = 0.00, Wen4 = 0.00, Thurs4 = 0.00, Fri4 = 0.00, Sat4 = 0.00, Sun4 = 0.00;

        //Declaring variables for Hours
        double contractualHoursWk1, contractualHoursWk2, contractualHoursWk3, contractualHoursWk4;
        double overtimeHoursWk1, overtimeHoursWk2, overtimeHoursWk3, overtimeHoursWk4;
        double totalHoursWk1, totalHoursWk2, totalHoursWk3, totalHoursWk4;

        double totalContractualHours;

        double totalOvertimeHours;

        double totalHoursWorked;

        //Declaring variables for Amount
        double contractualAmountWk1, contractualAmountWk2, contractualAmountWk3, contractualAmountWk4;
        double overtimeAmountWk1, overtimeAmountWk2, overtimeAmountWk3, overtimeAmountWk4;
        double totalContractualAmount;
        double totalOvertimeAmount;
        double totalAmountEarned;

        //Declaring variables for deduction
        double tax, NIContribution, taxRate, NIRate, SLC;
        double totalDeductions;

        //Declare and Initalize consants for Voluntary deductions
        const double Union = 10.00;
        const double SLCRate = .05;

        //Declaring variables for pay Rates
        double hourlySalaryRate, overtimeSalaryRate;

        //Declaring variable for Net pay
        double netPay;

        #endregion

        private void PayrollCalculatorForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payrollSystemDBDataSet1.tblPayRecords' table. You can move, or remove it, as needed.
            this.tblPayRecordsTableAdapter.Fill(this.payrollSystemDBDataSet1.tblPayRecords);
            ListOfMonths();
            ResetControls();
            PayrollTimer1.Start();
        }

        public PayrollCalculatorForm()
        {
            InitializeComponent();
        }

        private void ListOfMonths()
        {
            string[] months = { "Select a Month", "January", "Feburary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            foreach (var month in months)
            {
                cmbCurrentMonth.Items.Add(month);
                cmbCurrentMonth.SelectedIndex = 0;

                cmbSearchPayMonth.Items.Add(month);
                cmbSearchPayMonth.SelectedIndex = 0;
            }
        }

        private void btnComputePayment_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                GetWeek1Values();
                GetWeek2Values();
                GetWeek3Values();
                GetWeek4Values();

                totalHoursWk1 = Mon1 + Tues1 + Wen1 + Thurs1 + Fri1 + Sat1 + Sun1;
                totalHoursWk2 = Mon2 + Tues2 + Wen2 + Thurs2 + Fri2 + Sat2 + Sun2;
                totalHoursWk3 = Mon3 + Tues3 + Wen3 + Thurs3 + Fri3 + Sat3 + Sun3;
                totalHoursWk4 = Mon4 + Tues4 + Wen4 + Thurs4 + Fri4 + Sat4 + Sun4;

                hourlySalaryRate = double.Parse(nudHourlyRate.Value.ToString());

                overtimeSalaryRate = hourlySalaryRate * 1.5;

                #region ----Week 1 computation----

                //Hours worked, No overtime
                if (totalHoursWk1 <= 36)
                {
                    contractualHoursWk1 = totalHoursWk1;
                    contractualAmountWk1 = hourlySalaryRate * totalHoursWk1;
                    overtimeHoursWk1 = 0.00;
                    overtimeAmountWk1 = 0.00;

                }

                //Hours worked, with Overtime
                else if (totalHoursWk1 > 36)
                {
                    contractualHoursWk1 = 36;
                    contractualAmountWk1 = hourlySalaryRate * contractualHoursWk1;
                    overtimeHoursWk1 = totalHoursWk1 - contractualHoursWk1;
                    overtimeAmountWk1 = overtimeSalaryRate * overtimeHoursWk1;


                }

                #endregion
                #region ----Week 2 computation----

                //Hours worked, No overtime
                if (totalHoursWk2 <= 36)
                {
                    contractualHoursWk2 = totalHoursWk2;
                    contractualAmountWk2 = hourlySalaryRate * totalHoursWk2;
                    overtimeHoursWk2 = 0.00;
                    overtimeAmountWk2 = 0.00;

                }

                //Hours worked, with Overtime
                else if (totalHoursWk2 > 36)
                {
                    contractualHoursWk2 = 36;
                    contractualAmountWk2 = hourlySalaryRate * contractualHoursWk2;
                    overtimeHoursWk2 = totalHoursWk2 - contractualHoursWk2;
                    overtimeAmountWk2 = overtimeSalaryRate * overtimeHoursWk2;


                }

                #endregion
                #region ----Week 3 computation----

                //Hours worked, No overtime
                if (totalHoursWk3 <= 36)
                {
                    contractualHoursWk3 = totalHoursWk3;
                    contractualAmountWk3 = hourlySalaryRate * totalHoursWk3;
                    overtimeHoursWk3 = 0.00;
                    overtimeAmountWk3 = 0.00;

                }

                //Hours worked, with Overtime
                else if (totalHoursWk3 > 36)
                {
                    contractualHoursWk3 = 36;
                    contractualAmountWk3 = hourlySalaryRate * contractualHoursWk3;
                    overtimeHoursWk3 = totalHoursWk3 - contractualHoursWk3;
                    overtimeAmountWk3 = overtimeSalaryRate * overtimeHoursWk3;


                }

                #endregion
                #region ----Week 4 computation----

                //Hours worked, No overtime
                if (totalHoursWk4 <= 36)
                {
                    contractualHoursWk4 = totalHoursWk4;
                    contractualAmountWk4 = hourlySalaryRate * totalHoursWk4;
                    overtimeHoursWk4 = 0.00;
                    overtimeAmountWk4 = 0.00;

                }

                //Hours worked, with Overtime
                else if (totalHoursWk4 > 36)
                {
                    contractualHoursWk4 = 36;
                    contractualAmountWk4 = hourlySalaryRate * contractualHoursWk4;
                    overtimeHoursWk4 = totalHoursWk4 - contractualHoursWk4;
                    overtimeAmountWk4 = overtimeSalaryRate * overtimeHoursWk4;


                }

                #endregion

                //Compute total Hours and Amount
                totalContractualHours = contractualHoursWk1 + contractualHoursWk2 + contractualHoursWk3 + contractualHoursWk4;
                totalContractualAmount = contractualAmountWk1 + contractualAmountWk2 + contractualAmountWk3 + contractualAmountWk4;
                totalOvertimeHours = overtimeHoursWk1 + overtimeHoursWk2 + overtimeHoursWk3 + overtimeHoursWk4;
                totalOvertimeAmount = overtimeAmountWk1 + overtimeAmountWk2 + overtimeAmountWk3 + overtimeAmountWk4;
                totalHoursWorked = totalContractualHours + totalOvertimeHours;
                totalAmountEarned = totalContractualAmount + totalOvertimeAmount;

                //Compute for deductions
                #region ---Tax Computation---
                if (totalAmountEarned <= 916.67)
                {
                    taxRate = .0;
                    tax = totalAmountEarned * taxRate;
                }

                else if (totalAmountEarned > 916.67 && totalAmountEarned <= 3583.33)
                {
                    taxRate = .20;
                    tax = ((916.67 * .0) + ((totalAmountEarned - 916.67) * taxRate));
                }

                else if (totalAmountEarned > 3583.33 && totalAmountEarned <= 12500)
                {
                    taxRate = .40;
                    tax = ((916.67 * .0) + ((3583.33 - 916.67) * .20) + ((totalAmountEarned - 3583.33) * taxRate));
                }

                else if (totalAmountEarned > 12500)
                {
                    taxRate = .45;
                    tax = ((916.67 * .0) + ((3583.33 - 916.67) * .20) + ((12500 - 3583.33) * .40) + ((totalAmountEarned - 12500) * taxRate));
                }
                #endregion
                #region ---NI Computation---
                if (totalAmountEarned < 620)
                {
                    NIRate = .0;
                }

                else if (totalAmountEarned >= 620 && totalAmountEarned <= 3308)
                {
                    NIRate = .12;
                }

                else if (totalAmountEarned > 3308)
                {
                    NIContribution = .02;
                }
                #endregion

                NIContribution = totalAmountEarned * NIRate;
                SLC = totalAmountEarned * SLCRate;

                //Total amount deductable
                totalDeductions = tax + NIContribution + SLC + Union;

                //Compute Net Pay after deductions
                netPay = totalAmountEarned - totalDeductions;

                txtContracturalHours.Text = totalContractualHours.ToString("F");
                txtOvertimeHours.Text = totalOvertimeHours.ToString("F");
                txtTotalHoursWorked.Text = totalHoursWorked.ToString("F");
                txtContracturalEarnings.Text = totalContractualAmount.ToString("C");
                txtOvertimeEarnings.Text = totalOvertimeAmount.ToString("C");
                txtTotalEarnings.Text = totalAmountEarned.ToString("C");
                txtOvertimeRate.Text = overtimeSalaryRate.ToString("F");
                txtTaxAmount.Text = tax.ToString("C");
                txtNIContribution.Text = NIContribution.ToString("C");
                txtSLC.Text = SLC.ToString("C");
                txtUnion.Text = SLC.ToString("C");
                txtTotalDeductions.Text = totalDeductions.ToString("C");
                txtNetPay.Text = netPay.ToString("C");
            }
        }

        private void btnSavePay_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Insert into tblPayRecords(EmployeeId,FullName,NINumber,PayDate,PayPeriod,PayMonth,HourlyRate,ContractualHours,OvertimeHours,TotalHours,ContractualEarnings,OvertimeEarnings,TotalEarnings,TaxCode,TaxAmount,NIContribution,UnionFee,SLC,TotalDeductions,NetPay) values(@EmployeeId,@FullName,@NINumber,@PayDate,@PayPeriod,@PayMonth,@HourlyRate,@ContractualHours,@OvertimeHours,@TotalHours,@ContractualEarnings,@OvertimeEarnings,@TotalEarnings,@TaxCode,@TaxAmount,@NIContribution,@UnionFee,@SLC,@TotalDeductions,@NetPay)", con);
            cmd.Parameters.AddWithValue("@EmployeeId", txtEmployeeId.Text);
            cmd.Parameters.AddWithValue("@FullName", lblEmployeeFullName.Text);
            cmd.Parameters.AddWithValue("@NINumber", txtNINumber.Text);
            cmd.Parameters.AddWithValue("@PayDate", dtpCurrentDate.Value.ToString("MM/dd/yyyy"));
            cmd.Parameters.AddWithValue("@PayPeriod", listBoxPayPeriod.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@PayMonth", cmbCurrentMonth.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@HourlyRate", nudHourlyRate.Value.ToString());
            cmd.Parameters.AddWithValue("@ContractualHours", txtContracturalHours.Text);
            cmd.Parameters.AddWithValue("@OvertimeHours", txtOvertimeHours.Text);
            cmd.Parameters.AddWithValue("@TotalHours", txtTotalHoursWorked.Text);
            cmd.Parameters.AddWithValue("@ContractualEarnings", txtOvertimeHours.Text);
            cmd.Parameters.AddWithValue("@OvertimeEarnings", txtOvertimeHours.Text);
            cmd.Parameters.AddWithValue("@TotalEarnings", txtOvertimeHours.Text);
            cmd.Parameters.AddWithValue("@TaxCode", txtOvertimeHours.Text);
            cmd.Parameters.AddWithValue("@TaxAmount", txtOvertimeHours.Text);
            cmd.Parameters.AddWithValue("@NIContribution", txtOvertimeHours.Text);
            cmd.Parameters.AddWithValue("@UnionFee", txtOvertimeHours.Text);
            cmd.Parameters.AddWithValue("@SLC", txtOvertimeHours.Text);
            cmd.Parameters.AddWithValue("@TotalDeductions", txtOvertimeHours.Text);
            cmd.Parameters.AddWithValue("@NetPay", txtOvertimeHours.Text);

            try
            {
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("The Payment added Sucessfully", "Insertion Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            catch (SqlException ex)
            {
                MessageBox.Show("The following Error occurred:" + ex.Message + ex.StackTrace, "Query Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                con.Close();
            }

            ResetControls();

            this.tblPayRecordsTableAdapter.Fill(this.payrollSystemDBDataSet1.tblPayRecords);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void btnGeneratePaySlip_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();
        }

        private void btnPrintPaySlip_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
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
            SqlCommand cmd = new SqlCommand("Select FirstName,LastName,NINumber from tblEmployee where EmployeeId=" + txtEmployeeId.Text + "", con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
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
                    MessageBox.Show("No Employee Found with Employee Id " + txtEmployeeId.Text, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void GetWeek1Values()
        {
            try
            {
                Mon1 = double.Parse(nudMon1.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Tues1 = double.Parse(nudTue1.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Wen1 = double.Parse(nudWed1.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Thurs1 = double.Parse(nudThu1.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Fri1 = double.Parse(nudFri1.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Sat1 = double.Parse(nudSat1.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Sun1 = double.Parse(nudSun1.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }
        }

        private void GetWeek2Values()
        {
            try
            {
                Mon2 = double.Parse(nudMon2.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Tues2 = double.Parse(nudTue2.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Wen2 = double.Parse(nudWed2.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Thurs2 = double.Parse(nudThu2.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Fri2 = double.Parse(nudFri2.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Sat2 = double.Parse(nudSat2.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Sun2 = double.Parse(nudSun2.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }
        }

        private void GetWeek3Values()
        {
            try
            {
                Mon3 = double.Parse(nudMon3.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Tues3 = double.Parse(nudTue3.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Wen3 = double.Parse(nudWed3.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Thurs3 = double.Parse(nudThu3.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Fri3 = double.Parse(nudFri3.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Sat3 = double.Parse(nudSat3.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Sun3 = double.Parse(nudSun3.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }
        }

        private void GetWeek4Values()
        {
            try
            {
                Mon4 = double.Parse(nudMon4.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Tues4 = double.Parse(nudTue4.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Wen4 = double.Parse(nudWed4.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Thurs4 = double.Parse(nudThu4.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Fri4 = double.Parse(nudFri4.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Sat4 = double.Parse(nudSat4.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }

            try
            {
                Sun4 = double.Parse(nudSun4.Value.ToString());
            }

            catch (FormatException ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message, "Error Message");
            }
        }

        private bool ValidateControls()
        {
            if (txtEmployeeId.Text == "")
            {
                MessageBox.Show("Please, Enter Employee Id", "Data Entry Error");
                txtEmployeeId.Focus();
                return false;
            }

            if (listBoxPayPeriod.SelectedIndex == 0)
            {
                MessageBox.Show("Please, Select Pay period", "Data Entry Error");
                listBoxPayPeriod.Focus();
                return false;
            }

            if (cmbCurrentMonth.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Current Month", "Data Entry error");
                cmbCurrentMonth.Focus();
                return false;
            }

            return true;
        }

        private void ResetControls()
        {
            txtEmployeeId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNINumber.Text = "";
            lblEmployeeFullName.Text = "";
            listBoxPayPeriod.SelectedIndex = 0;
            cmbCurrentMonth.SelectedIndex = 0;

            nudMon1.Text = "0.00";
            nudTue1.Text = "0.00";
            nudWed1.Text = "0.00";
            nudThu1.Text = "0.00";
            nudFri1.Text = "0.00";
            nudSat1.Text = "0.00";
            nudSun1.Text = "0.00";

            nudMon2.Text = "0.00";
            nudTue2.Text = "0.00";
            nudWed2.Text = "0.00";
            nudThu2.Text = "0.00";
            nudFri2.Text = "0.00";
            nudSat2.Text = "0.00";
            nudSun2.Text = "0.00";

            nudMon3.Text = "0.00";
            nudTue3.Text = "0.00";
            nudWed3.Text = "0.00";
            nudThu3.Text = "0.00";
            nudFri3.Text = "0.00";
            nudSat3.Text = "0.00";
            nudSun3.Text = "0.00";

            nudMon4.Text = "0.00";
            nudTue4.Text = "0.00";
            nudWed4.Text = "0.00";
            nudThu4.Text = "0.00";
            nudFri4.Text = "0.00";
            nudSat4.Text = "0.00";
            nudSun4.Text = "0.00";

            txtContracturalHours.Text = "";
            txtContracturalEarnings.Text = "";
            txtOvertimeHours.Text = "";
            txtOvertimeEarnings.Text = "";
            nudHourlyRate.Text = "10.00";
            txtNIContribution.Text = "";
            txtUnion.Text = "0.00";
            txtTaxAmount.Text = "0.00";
            txtSLC.Text = "0.00";
            txtTotalDeductions.Text = "0.00";
            txtTotalEarnings.Text = "0.00";
            txtTotalHoursWorked.Text = "0.00";
            txtNetPay.Text = "0.00";
            txtOvertimeRate.Text = "0.00";
            txtHours.Text = "00";
            txtMinutes.Text = "00";
            txtDecimalHours.Text = "0.00";

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            decimal hours, minutes, decimalHours = 0.00M;
            if (decimal.TryParse(txtHours.Text, out hours))
            {
                if (decimal.TryParse(txtMinutes.Text, out minutes))
                {
                    decimalHours = ConvertTimeToDecimal(hours, minutes);
                    txtDecimalHours.Text = decimalHours.ToString("F2");
                }

                else
                {
                    MessageBox.Show("Please, Enter Real Number Only for Minutes");
                    txtMinutes.Focus();
                }
            }

            else
            {
                MessageBox.Show("Please, Enter Real Number Only for Hours.");
                txtHours.Focus();
            }
        }

        private decimal ConvertTimeToDecimal(decimal hh, decimal mm)
        {
            return (hh + (mm / 60));
        }

        private void linkLabelWinCalculator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void PayrollTimer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            btnTime.Text = dt.ToString("HH:mm:ss");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                StringBuilder SearchStatement = new StringBuilder();
                if (txtSearchPaymentId.Text.Length > 0)
                {
                    SearchStatement.Append("Convert(PaymentId,'System.String') like '%" +  txtSearchPaymentId.Text + "%'");
                }

                if (txtSearchEmployeeId.Text.Length > 0)
                {
                    if (SearchStatement.Length > 0)
                    {
                        SearchStatement.Append("and");
                    }

                    SearchStatement.Append("Convert(EmployeeId,'System.String') like '%" + txtSearchEmployeeId.Text + "%'");
                }

                if (txtSearchFullName.Text.Length > 0)
                {
                    if (SearchStatement.Length > 0)
                    {
                        SearchStatement.Append("and");
                    }

                    SearchStatement.Append(" FullName like '%" + txtSearchFullName.Text + "%'");
                }

                if (txtSearchNINumber.Text.Length > 0)
                {
                    if (SearchStatement.Length > 0)
                    {
                        SearchStatement.Append("and");
                    }

                    SearchStatement.Append(" NINumber like '%" + txtSearchNINumber.Text + "%'");
                }

                if (txtSearchPayDate.Text.Length > 0)
                {
                    if (SearchStatement.Length > 0)
                    {
                        SearchStatement.Append("and");
                    }

                    SearchStatement.Append(" Convert(PayDate,'System.String') like '%" + txtSearchPayDate.Text + "%'");
                }

                if (cmbSearchPayMonth.SelectedIndex > 0)
                {
                    if (SearchStatement.Length > 0)
                    {
                        SearchStatement.Append("and");
                    }

                    SearchStatement.Append(" PayMonth like '%" + cmbSearchPayMonth.Text + "%'");
                }

                tblPayRecordsBindingSource.Filter = SearchStatement.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show("The following error has occured:" + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchPaymentId.Text = "";
            txtSearchEmployeeId.Text = "";
            txtSearchFullName.Text = "";
            txtSearchNINumber.Text = "";
            txtSearchPayDate.Text = DateTime.Now.ToShortDateString();
            cmbSearchPayMonth.SelectedIndex = 0;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Blue,2),60,90,750,90 );
            Image image = Image.FromFile(@"E:\Project Windows Form\PayrollApplicationSolution\PayrollApplication\Resources\company-logo.png");
            e.Graphics.DrawImage(image,60,100);
            e.Graphics.DrawString("Payroll Application Inc.", new Font("Arial", 24, FontStyle.Bold), Brushes.DarkBlue   , new Point(200, 140));
            e.Graphics.DrawLine(new Pen(Color.Blue, 2), 60, 230, 750, 230);
            e.Graphics.DrawString("Pay Date :"+dtpCurrentDate.Value.ToString("MM/dd/yyyy"),new Font("Times New Roman",16,FontStyle.Regular),Brushes.DarkBlue,new Point(500,250));

            e.Graphics.DrawRectangle(new Pen(Color.Blue,2),60,290,700,50);
            e.Graphics.DrawString("  Employee Id :"+txtEmployeeId.Text+"        Name: "+lblEmployeeFullName.Text+"       NINO:"+txtNINumber.Text,new Font("Times New Roman",16,FontStyle.Regular),Brushes.DarkBlue,new Point(60,300));

            e.Graphics.DrawLine(new Pen(Color.Blue,3),60,420,750,420);
            e.Graphics.DrawString("EARNINGS", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.DarkBlue, new Point(60, 385));
            e.Graphics.DrawString("HOURS", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.DarkBlue, new Point(180, 385));
            e.Graphics.DrawString("RATES", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.DarkBlue, new Point(260, 385));
            e.Graphics.DrawString("AMOUNTS", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.DarkBlue, new Point(350, 385));
            e.Graphics.DrawString("DEDUCTIONS", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.DarkBlue, new Point(500, 385));
            e.Graphics.DrawString("AMOUNTS", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.DarkBlue, new Point(650, 385));

            e.Graphics.DrawString("Basic :", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.DarkBlue, new Point(60, 430));
            e.Graphics.DrawString(txtContracturalHours.Text, new Font("Times New Roman", 14, FontStyle.Italic), Brushes.DarkBlue, new Point(180,430));
            e.Graphics.DrawString(nudHourlyRate.Value.ToString("F"), new Font("Times New Roman", 14, FontStyle.Italic), Brushes.DarkBlue, new Point(260, 430));
            e.Graphics.DrawString(txtContracturalEarnings.Text, new Font("Times New Roman", 14, FontStyle.Italic), Brushes.DarkBlue, new Point(350, 430));
            e.Graphics.DrawString("Tax (1100L)", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.DarkBlue, new Point(500, 430));
            e.Graphics.DrawString(txtTaxAmount.Text, new Font("Times New Roman", 14, FontStyle.Italic), Brushes.DarkBlue, new Point(650, 430));

            e.Graphics.DrawString("Overtime :", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.DarkBlue, new Point(60, 470));
            e.Graphics.DrawString(txtOvertimeHours.Text, new Font("Times New Roman", 14, FontStyle.Italic), Brushes.DarkBlue, new Point(180, 470));
            e.Graphics.DrawString(txtOvertimeRate.Text, new Font("Times New Roman", 14, FontStyle.Italic), Brushes.DarkBlue, new Point(260, 470));
            e.Graphics.DrawString(txtOvertimeEarnings.Text, new Font("Times New Roman", 14, FontStyle.Italic), Brushes.DarkBlue, new Point(350, 470));
            e.Graphics.DrawString("NIC", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.DarkBlue, new Point(500, 470));
            e.Graphics.DrawString(txtNIContribution.Text, new Font("Times New Roman", 14, FontStyle.Italic), Brushes.DarkBlue, new Point(650, 470));

            e.Graphics.DrawString("Union:", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.DarkBlue, new Point(500, 510));
            e.Graphics.DrawString(txtUnion.Text, new Font("Times New Roman", 14, FontStyle.Italic), Brushes.DarkBlue, new Point(650, 510));

            e.Graphics.DrawString("SLC:", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.DarkBlue, new Point(500, 540));
            e.Graphics.DrawString(txtSLC.Text, new Font("Times New Roman", 14, FontStyle.Italic), Brushes.DarkBlue, new Point(650, 540));

            e.Graphics.DrawLine(new Pen(Color.Blue,1),60,590,750,590);

            e.Graphics.DrawString("Total Earnings: ", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.DarkBlue, new Point(60,620));
            e.Graphics.DrawString(txtTotalEarnings.Text, new Font("Times New Roman", 14, FontStyle.Italic), Brushes.DarkBlue, new Point(350, 620));
            e.Graphics.DrawString("Total Deductions:  ", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.DarkBlue, new Point(480, 620));
            e.Graphics.DrawString(txtTotalDeductions.Text, new Font("Times New Roman", 14, FontStyle.Italic), Brushes.DarkBlue, new Point(650, 620));

            e.Graphics.DrawLine(new Pen(Color.Blue, 1), 60, 680, 750, 680);

            e.Graphics.DrawRectangle(new Pen(Color.Blue, 2), 60, 710, 700, 50);
            e.Graphics.DrawString("NET PAY: ", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.DarkBlue, new Point(500, 720));
            e.Graphics.DrawString(txtNetPay.Text, new Font("Times New Roman", 14, FontStyle.Italic), Brushes.DarkBlue, new Point(650, 720));

        }

    }
}
