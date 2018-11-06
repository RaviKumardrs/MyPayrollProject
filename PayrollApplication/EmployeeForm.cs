using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;

namespace PayrollApplication
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private bool isControlsDataValid()
        {
            Regex objEmployeeId = new Regex("^[0-9]{3,4}$");
            Regex objFirstName = new Regex("^[A-Z][a-zA-Z]*$");
            Regex objLastName = new Regex("^[A-Z][a-zA-Z]*$");
            Regex objNi = new Regex(@"^[A-CEGHJ-PR-TW-Z]{1}[A-CEGHJ-NPR-TW-Z]{1}[0-9]{6}[A-D\s]$");
            Regex objEmail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");



            //Employee Id validation
            if (Convert.ToInt32(txtEmployeeId.Text.Length) < 1)
            {
                MessageBox.Show("Please, Enter Employee Id","Data Entry Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtEmployeeId.Focus();
                txtEmployeeId.BackColor = Color.Red;
                txtEmployeeId.ForeColor = Color.White;
                return false;
            }

            else if (!objEmployeeId.IsMatch(txtEmployeeId.Text))
            {
                MessageBox.Show("Please, Enter a valid Employee Id", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeId.Focus();
                txtEmployeeId.BackColor = Color.Red;
                txtEmployeeId.ForeColor = Color.White;
                return false;
            }

            else
            {
                txtEmployeeId.BackColor = Color.White;
                txtEmployeeId.ForeColor = Color.Black;
            }

            //First Name validation
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBox.Show("Please, Enter First Name", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                txtFirstName.BackColor = Color.Red;
                txtFirstName.ForeColor = Color.White;
                return false;
            }

            else if (!objFirstName.IsMatch(txtFirstName.Text))
            {

                MessageBox.Show("Please, Enter valid First Name", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                txtFirstName.BackColor = Color.Red;
                txtFirstName.ForeColor = Color.White;
                return false;
            }

            else
            {
                txtFirstName.BackColor = Color.White;
                txtFirstName.ForeColor = Color.Black;
            }


            //Last Name validation
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Please, Enter Last Name", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                txtLastName.BackColor = Color.Red;
                txtLastName.ForeColor = Color.White;
                return false;
            }

            else if (!objLastName.IsMatch(txtLastName.Text))
            {

                MessageBox.Show("Please, Enter valid Last Name", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                txtLastName.BackColor = Color.Red;
                txtLastName.ForeColor = Color.White;
                return false;
            }

            else
            {
                txtLastName.BackColor = Color.White;
                txtLastName.ForeColor = Color.Black;
            }

            //Gender validation

            if(rdbMale.Checked==false && rdbMale.Checked==false)
            {
                MessageBox.Show("Please, check either Male or Female.", "Data Entry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grpGender.Focus();
                rdbMale.BackColor = Color.Red;
                rdbFemale.BackColor = Color.Red;
                rdbMale.ForeColor = Color.White;
                rdbFemale.ForeColor = Color.White;
                return false;
            }

            else
            {
                rdbMale.BackColor = Color.CornflowerBlue;
                rdbFemale.BackColor = Color.CornflowerBlue;
                txtEmployeeId.ForeColor = Color.Black;
            }

            //National Insurence validation

            if (txtNationalInsurenceNumber.Text=="")
            {
                MessageBox.Show("Please, Enter National Insurence Number", "Data Entry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNationalInsurenceNumber.Focus();
                txtNationalInsurenceNumber.BackColor = Color.Red;
                txtNationalInsurenceNumber.ForeColor = Color.White;
                return false;
            }

            else if (!objNi.IsMatch(txtNationalInsurenceNumber.Text))
            {
                MessageBox.Show("Please, Enter valid National Insurence Number", "Data Entry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNationalInsurenceNumber.Focus();
                txtNationalInsurenceNumber.BackColor = Color.Red;
                txtNationalInsurenceNumber.ForeColor = Color.White;
                return false;
            }

            else
            {
                txtNationalInsurenceNumber.BackColor = Color.White;
                txtNationalInsurenceNumber.ForeColor = Color.Black;
            }

            //Marital status validation

            if (rdbSingle.Checked == false && rdbMarried.Checked == false)
            {
                MessageBox.Show("Please, check either Married or Single.", "Data Entry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grpMartialStatus.Focus();
                rdbSingle.BackColor = Color.Red;
                rdbMarried.BackColor = Color.Red;
                rdbSingle.ForeColor = Color.White;
                rdbMarried.ForeColor = Color.White;
                return false;
            }

            else
            {
                rdbSingle.BackColor = Color.CornflowerBlue;
                rdbMarried.BackColor = Color.CornflowerBlue;
                txtEmployeeId.ForeColor = Color.Black;
                rdbSingle.ForeColor = Color.Black;
                rdbMarried.ForeColor = Color.Black;
            }

            //Address validation
            if (txtAddress.Text=="")
            {
                MessageBox.Show("Please, Enter Address", "Data Entry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                txtAddress.BackColor = Color.Red;
                txtAddress.ForeColor = Color.White;

                return false;
            }

            else
            {
                txtAddress.BackColor = Color.White;
                txtAddress.ForeColor = Color.Black;
            }

            //City validation
            if (txtCity.Text == "")
            {
                MessageBox.Show("Please, Enter City", "Data Entry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCity.Focus();
                txtCity.BackColor = Color.Red;
                txtCity.ForeColor = Color.White;
                return false;
            }

            else
            {
                txtCity.BackColor = Color.White;
                txtCity.ForeColor = Color.Black;
            }

            //Post code validation
            if (txtPostCode.Text == "")
            {
                MessageBox.Show("Please, Enter Post Code", "Data Entry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPostCode.Focus();
                txtPostCode.BackColor = Color.Red;
                txtPostCode.ForeColor = Color.White;
                return false;
            }

            else
            {
                txtPostCode.BackColor = Color.White;
                txtPostCode.ForeColor = Color.Black;
            }

            //Country validation
            if (cmbCountry.SelectedIndex==0 || cmbCountry.SelectedIndex==-1)
            {
                MessageBox.Show("Please, select country from list", "Data Entry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCountry.Focus();
                cmbCountry.BackColor = Color.Red;
                cmbCountry.ForeColor = Color.White;
                return false;
            }

            else
            {
                cmbCountry.BackColor = Color.White;
                cmbCountry.ForeColor = Color.Black;
            }

            //Phone number validation

            if (txtPhoneNumber.Text.Length==0)
            {
                MessageBox.Show("Please, Enter Phone Number", "Data Entry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNumber.Focus();
                txtPhoneNumber.BackColor = Color.Red;
                txtPhoneNumber.ForeColor = Color.White;
                return false;
            }

            else
            {
                txtPhoneNumber.BackColor = Color.White;
                txtPhoneNumber.ForeColor = Color.Black;
            }

            //Email Address validation
            if (txtEmailAddress.Text=="")
            {
                MessageBox.Show("Please, Enter Email Address", "Data Entry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmailAddress.Focus();
                txtEmailAddress.BackColor = Color.Red;
                txtEmailAddress.ForeColor = Color.White;
                return false;
            }

            else if (!objEmail.IsMatch(txtEmailAddress.Text))
            {
                MessageBox.Show("Please, Enter valid Email Address", "Data Entry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmailAddress.Focus();
                txtEmailAddress.BackColor = Color.Red;
                txtEmailAddress.ForeColor = Color.White;
                return false;
            }

            else
            {
                txtEmailAddress.BackColor = Color.White;
                txtEmailAddress.ForeColor = Color.Black;
            }

            //Notes validation
            if (txtNotes.Text.Length >30)
            {
                MessageBox.Show("Too Much Text! Please, eneter fewer text", "Data Entry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNotes.Focus();
                txtNotes.BackColor = Color.Red;
                txtNotes.ForeColor = Color.White;
                return false;
            }

            else
            {
                txtNotes.BackColor = Color.White;
                txtNotes.ForeColor = Color.Black;
            }

            return true;
        }

        string gender;
        string maritalStatus;
        bool isMember;

        private void CheckedItems()
        {
            if (rdbMale.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            if (rdbMarried.Checked)
            {
                maritalStatus = "Married";
            }

            else
            {
                maritalStatus = "Single";
            }

            if (cbIsMember.Checked)
            {
                isMember=true;
            }

            else
            {
                isMember = false;
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (isControlsDataValid())
            {
                CheckedItems();
                string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                //try
                //{
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into tblEmployee values(" + Convert.ToInt32(txtEmployeeId.Text) + ",'"+txtFirstName.Text+"','"+txtLastName.Text+"','"+gender+"','"+txtNationalInsurenceNumber.Text+"','"+dtpDateOfBirth.Value.ToString("MM/dd/yyyy")+"','"+maritalStatus+"','"+isMember+"','"+txtAddress.Text+"','"+txtCity.Text+"','"+txtPostCode.Text+"','"+cmbCountry.SelectedItem.ToString()+"','"+txtPhoneNumber.Text+"','"+txtEmailAddress.Text+"','"+txtNotes.Text+"')",con);
                    cmd.ExecuteNonQuery();
                    this.tblEmployeeTableAdapter.Fill(this.payrollSystemDBDataSet.tblEmployee);
                    MessageBox.Show("Employee with Id =" +txtEmployeeId.Text+" "+"has been addeded Sucessfully!","Insertion Sucessfully",MessageBoxButtons.OK,MessageBoxIcon.Information);

                //}

                //catch (Exception ex)
                //{
                //    MessageBox.Show("The following error occurred :" + ex.Message, "Data entry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

                //finally
                //{
                //    con.Close();
                //}
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Employee Updated");
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Employee Deleted");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmployeeId.Clear();
            txtFirstName.Clear();
            txtLastName.Text = "";
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            txtNationalInsurenceNumber.Text = "";
            dtpDateOfBirth.Value = new DateTime(1990, 12, 30);
            rdbMarried.Checked = false;
            rdbSingle.Checked = false;
            cbIsMember.Checked = false;
            txtAddress.Text = "";
            txtCity.Text = "";
            txtPostCode.Text = "";
            cmbCountry.SelectedIndex = 0;
            txtPhoneNumber.Text = "";
            txtEmailAddress.Text = "";
            txtNotes.Text = "";
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PreviewForm previewForm = new PreviewForm();
            CheckedItems();
            previewForm.PreviewEmployeeData(Convert.ToInt32(txtEmployeeId.Text),txtFirstName.Text,txtLastName.Text,gender,txtNationalInsurenceNumber.Text,dtpDateOfBirth.Text,maritalStatus,isMember,txtAddress.Text,txtCity.Text,txtPostCode.Text,cmbCountry.SelectedItem.ToString(),txtPhoneNumber.Text,txtEmailAddress.Text,txtNotes.Text);
            previewForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region //keypress Event validation

        bool IsNumberOrBackspace;
        private void txtEmployeeId_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsNumberOrBackspace = false;
            if(char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                IsNumberOrBackspace = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsNumberOrBackspace = false;
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                IsNumberOrBackspace = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        #endregion

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payrollSystemDBDataSet.tblEmployee' table. You can move, or remove it, as needed.
            this.tblEmployeeTableAdapter.Fill(this.payrollSystemDBDataSet.tblEmployee);

        }
    }
}
