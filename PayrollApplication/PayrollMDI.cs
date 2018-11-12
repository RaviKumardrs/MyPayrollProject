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
    public partial class PayrollMDI : Form
    {
        public PayrollMDI()
        {
            InitializeComponent();
        }

       
        private void manageEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employeeForm == null)
            {
                employeeForm = new EmployeeForm();
                employeeForm.MdiParent = this;
                employeeForm.FormClosed += EmployeeForm_FormClosed1;
                employeeForm.Show();
            }

            else
            {
                employeeForm.Activate();
            }
        }

        private void EmployeeForm_FormClosed1(object sender, FormClosedEventArgs e)
        {
            employeeForm = null;
        }

        private void payrollCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (payrollCalculatorForm == null)
            {
                payrollCalculatorForm = new PayrollCalculatorForm();
                payrollCalculatorForm.MdiParent = this;
                payrollCalculatorForm.FormClosed += PayrollCalculatorForm_FormClosed1;
                payrollCalculatorForm.Show();
            }

            else
            {
                payrollCalculatorForm.Activate();
            }

        }

        private void PayrollCalculatorForm_FormClosed1(object sender, FormClosedEventArgs e)
        {
            payrollCalculatorForm = null;
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        EmployeeForm employeeForm = null;
        private void manageEmployeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (employeeForm == null)
            {
                employeeForm = new EmployeeForm();
                employeeForm.MdiParent = this;
                employeeForm.FormClosed += EmployeeForm_FormClosed;
                employeeForm.Show();
            }

            else
            {
                employeeForm.Activate();
            }
        }

        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            employeeForm = null;
        }

        PayrollCalculatorForm payrollCalculatorForm = null;
        private void payrollCalculatorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (payrollCalculatorForm == null)
            {
                payrollCalculatorForm = new PayrollCalculatorForm();
                payrollCalculatorForm.MdiParent = this;
                payrollCalculatorForm.FormClosed += PayrollCalculatorForm_FormClosed;
                payrollCalculatorForm.Show();
            }

            else
            {
                payrollCalculatorForm.Activate();
            }
            
        }

        private void PayrollCalculatorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            payrollCalculatorForm = null;
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void arrangeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        AboutPayrollSystem aboutPayrollSystem = null;
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aboutPayrollSystem == null)
            {
                AboutPayrollSystem aboutPayrollSystem = new AboutPayrollSystem();
                aboutPayrollSystem.MdiParent = this;
                aboutPayrollSystem.Show();
            }

            else
            {
                aboutPayrollSystem.Activate();
            }
            
        }

        private void allEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllEmployee allEmployee = new AllEmployee();
            allEmployee.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            allEmployee.MdiParent = this;
            allEmployee.Visible = true;
        }

        private void allPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllPayments allPayments = new AllPayments();
            allPayments.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            allPayments.MdiParent = this;
            allPayments.Visible = true;
            
        }

        private void currentMonthPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentMonthPayment currentMonthPayment = new CurrentMonthPayment();
            currentMonthPayment.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            currentMonthPayment.MdiParent = this;
            currentMonthPayment.Visible = true;
        }
    }
}
