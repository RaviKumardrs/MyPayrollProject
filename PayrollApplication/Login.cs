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
    public partial class Login : Form
    {
        Users users;
        public Login()
        {
            InitializeComponent();
        }

        private void UsersData()
        {
            users.UserName = txtUserName.Text;
            users.Password = txtPassword.Text;
            users.Role = cmbRoles.Text;
        }

        private void GetRoles()
        {
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAllUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmbRoles.Items.Add(dr[3]);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error:", ex.Message);
            }

            finally
            {
                con.Close();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            GetRoles();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {

            users = new Users();
            UsersData();
            try
            {
                if(users.AuthorizeUser())
                {
                    PayrollMDI payrollMDI = new PayrollMDI();
                    this.Hide();
                    payrollMDI.Show();
                }

                else
                {
                    MessageBox.Show("Unauthorized Credentials provided!", "Unquthorized User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

         

           

           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
