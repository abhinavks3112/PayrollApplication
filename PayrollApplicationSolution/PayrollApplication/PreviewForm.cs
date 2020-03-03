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

        public void PreviewEmployeeData(string EmployeeID, string FirstName, string LastName, string Gender,
            string NationalInsuranceNumber, string DateOfBirth, string MaritalStatus,
            bool IsMember, string Address, string City, string PostCode,
            string Country, string PhoneNumber, string Email, string Notes)
        {
            _lblEmployeeID.Text = EmployeeID;
            _lblFirstName.Text = FirstName;
            _lblLastName.Text = LastName;
            _lblGender.Text = Gender;
            _lblNationalInsuranceNumber.Text = NationalInsuranceNumber;
            _lblDateOfBirth.Text = DateOfBirth;
            _lblMaritalStatus.Text = MaritalStatus;
            _lblUnionMembership.Text = IsMember.ToString();
            _lblAddress.Text = Address;
            _lblCity.Text = City;
            _lblPostCode.Text = PostCode;
            _lblCountry.Text = Country;
            _lblPhoneNumber.Text = PhoneNumber;
            _lblEmailAddress.Text = Email;
            _lblNotes.Text = Notes;
        }
    }
}
