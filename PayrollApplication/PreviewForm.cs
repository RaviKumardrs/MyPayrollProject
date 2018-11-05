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
    public partial class PreviewForm : Form
    {
        public PreviewForm()
        {
            InitializeComponent();
        }

        private void PreviewEmployeeData(int EmployeeId,string FirstName,string LastName,string Gender,string NationalInsurence,string DateofBirth,string MartialStatus,bool IsMember,string Address,string City,string PostCode,string Country,string PhoneNo,string EmailAddress,string Notes)
        {
            _lblEmployeeId.Text = Convert.ToString(EmployeeId);
            _lblFirstName.Text = FirstName;
            _lblLastName.Text = LastName;
            _lblGender.Text = Gender;
            _lblNationalInsurenceNo.Text = NationalInsurence;
            _lblDateofBirth.Text = DateofBirth;
            _lblMartialStatus.Text = MartialStatus;
            _lblUnionMembership.Text = IsMember.ToString();
            _lblAddress.Text = Address;
            _lblCity.Text = City;
            _lblPostCode.Text = PostCode;
            _lblCountry.Text = Country;
            _lblPhoneNo.Text = PhoneNo;
            _lblEmailAddress.Text = EmailAddress;
            _lblNotes.Text = Notes;

        }
    }
}
