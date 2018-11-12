﻿using System;
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
    public partial class RegisterUser : Form
    {
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void ClearControls()
        {
            txtRegisterUserName.Text = "";
            txtRegisterPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtRoles.Text = "";
            txtDescription.Text = "";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private bool isRegisterControlsValid()
        {
            if (txtRegisterUserName.Text.Length == 0)
            {
                MessageBox.Show("Please, Enter UserName", "Data Enter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegisterUserName.Focus();
                return false;
            }

            if (txtRegisterPassword.Text.Length == 0)
            {
                MessageBox.Show("Please, Enter Password", "Data Enter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegisterPassword.Focus();
                return false;
            }

            else
            {
                if (txtRegisterPassword.Text.Length < 8 || checkUppercase(txtRegisterPassword.Text) < 1 || checkLowerCase(txtRegisterPassword.Text) < 1 || checkNumeric(txtRegisterPassword.Text) < 1)
                {
                    MessageBox.Show("Please, Enter a valid Password. \n\n The Password must be a minimum 8 characters long. \n The Password must contain at least one uppercase letter.\n The Password must contain at least one lowercase letter. \n The password must contain at least one numeric digit", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRegisterPassword.Focus();
                    return false;
                }
            }

            if (txtConfirmPassword.Text.Length == 0)
            {
                MessageBox.Show("Please, Enter Confirm Password", "Data Enter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPassword.Focus();
                return false;
            }

            else
            {
                if (txtConfirmPassword.Text != txtRegisterPassword.Text)
                {
                    MessageBox.Show("Both Passwords do not match Please, try again!", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmPassword.Focus();
                    return false;
                }
            }

            if (txtRoles.Text.Length == 0)
            {
                MessageBox.Show("Please, Enter Role", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRoles.Focus();
                return false;
            }

            return true;
        }

        private int checkUppercase(string strPassword)
        {
            int numberOfUppercase = 0;
            foreach (char ch in strPassword)
            {
                if (char.IsUpper(ch))
                {
                    numberOfUppercase++;
                }
            }

            return numberOfUppercase;
        }

        private int checkLowerCase(string strPassword)
        {
            int numberOfLowercase = 0;
            foreach (char ch in strPassword)
            {
                if (char.IsLower(ch))
                {
                    numberOfLowercase++;
                }
            }

            return numberOfLowercase;
        }
       
        private int checkNumeric(string strPassword)
        {
            int numberOfDigits = 0;
            foreach(char ch in strPassword)
            {
                if (char.IsNumber(ch))
                {
                    numberOfDigits++;
                }
            }

            return numberOfDigits;
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            if (isRegisterControlsValid())
            {
                MessageBox.Show("Valid Data");
            }
        }
    }
}
