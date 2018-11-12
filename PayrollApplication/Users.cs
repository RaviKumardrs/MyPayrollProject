using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PayrollApplication
{
    class Users
    {
        private string userName;
        private string password;
        private string role;
        private string description;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public void AddUser()
        {
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spInsertCommand", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Roles", Role);
            cmd.Parameters.AddWithValue("@Description", Description);
            try
            {
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("New User Added Sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex.Message, "sql insert error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                con.Close();
            }
        }

        public void UpdateUser()
        {
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateCommand", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Roles", Role);
            cmd.Parameters.AddWithValue("@Description", Description);
            try
            {
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("User updated Sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex.Message, "sql updation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                con.Close();
            }
        }
    }


}
