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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Employee Added");
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
            MessageBox.Show("Control Reset");
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Employee Preview");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
    }
}
