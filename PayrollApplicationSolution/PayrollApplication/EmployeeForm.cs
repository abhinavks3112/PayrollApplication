using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PayrollApplication.Enums;

namespace PayrollApplication
{
    public partial class EmployeeForm : Form
    {
        CustomValidationsFunctions cvf = new CustomValidationsFunctions();
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private bool IsControlsDataValid()
        {
            bool isValid = true;

            // Validate field to check if  it filled or not
            Dictionary<Control, TextBoxEntryCheck> controlsToValidate = new Dictionary<Control, TextBoxEntryCheck>();
            controlsToValidate.Add(txtEmployeeID, TextBoxEntryCheck.CHECK_IF_ANY_NUMBER_ENTERED);
            controlsToValidate.Add(txtFirstName, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);
            controlsToValidate.Add(txtLastName, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);
            controlsToValidate.Add(txtNationalInsuranceNumber, TextBoxEntryCheck.CHECK_IF_ANY_NUMBER_ENTERED);
            controlsToValidate.Add(txtAddress, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);
            controlsToValidate.Add(txtCity, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);
            controlsToValidate.Add(txtPostCode, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);
            controlsToValidate.Add(txtPhoneNumber, TextBoxEntryCheck.CHECK_IF_ANY_NUMBER_ENTERED);
            controlsToValidate.Add(txtEmailAddress, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);

            if (cvf.IsFormControlNullOrEmptyValidation(controlsToValidate) == false)
            {
                return false;
            }

            // Validate field for regular expression
            Dictionary<Control, FieldsToValidateForRegex> controlsToValidateRegex = new Dictionary<Control, FieldsToValidateForRegex>();
            controlsToValidateRegex.Add(txtEmployeeID, FieldsToValidateForRegex.EMPLOYEE_ID);
            controlsToValidateRegex.Add(txtFirstName, FieldsToValidateForRegex.EMPLOYEE_FIRST_LAST_NAME);
            controlsToValidateRegex.Add(txtLastName, FieldsToValidateForRegex.EMPLOYEE_FIRST_LAST_NAME);
            controlsToValidateRegex.Add(txtNationalInsuranceNumber, FieldsToValidateForRegex.EMPLOYEE_NINO);
            controlsToValidateRegex.Add(txtEmailAddress, FieldsToValidateForRegex.EMPLOYEE_EMAIL_ADDRESS);

            if (cvf.IsEmployeeDetailValid(controlsToValidateRegex) == false)
            {
                return false;
            }

            // Gender Validation
            if (rdbMale.Checked == false && rdbFemale.Checked == false)
            {
                MessageBox.Show("Please Select either Male or Female Gender", "Data Entry Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grpGender.Focus();
                rdbMale.BackColor = Color.Silver;
                rdbFemale.BackColor = Color.Silver;
                isValid = false;
                return isValid;
            }
            else
            {
                rdbMale.BackColor = Color.White;
                rdbFemale.BackColor = Color.White;
            }


            // Marital Status Validation
            if (rdbMarried.Checked == false && rdbSingle.Checked == false)
            {
                MessageBox.Show("Please Select either Married or Single", "Data Entry Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grpGender.Focus();
                rdbMarried.BackColor = Color.Silver;
                rdbSingle.BackColor = Color.Silver;
                isValid = false;
                return isValid;
            }
            else
            {
                rdbMarried.BackColor = Color.White;
                rdbSingle.BackColor = Color.White;
            }

            // Marital Status Validation
            if (rdbMarried.Checked == false && rdbSingle.Checked == false)
            {
                MessageBox.Show("Please Select either Married or Single", "Data Entry Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grpGender.Focus();
                rdbMarried.BackColor = Color.Silver;
                rdbSingle.BackColor = Color.Silver;
                isValid = false;
                return isValid;
            }
            else
            {
                rdbMarried.BackColor = Color.White;
                rdbSingle.BackColor = Color.White;
            }

            // Country Validation
            if (cmbCountry.SelectedIndex == Constants.INDEX_ZERO || cmbCountry.SelectedIndex == Constants.INDEX_MINUS_ONE_OR_DEFAULT_INDEX)
            {
                MessageBox.Show("Please Select a Country From the list", "Data Entry Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCountry.Focus();
                cmbCountry.BackColor = Color.Silver;
                isValid = false;
                return isValid;
            }
            else
            {
                cmbCountry.BackColor = Color.White;
            }

            // Country Validation
            if (Convert.ToInt32(txtNotes.Text.Length) > Constants.NOTES_FIELD_SIZE_CONSTRAINT)
            {
                MessageBox.Show("Too much Text! Please enter fewer text", "Data Entry Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNotes.Focus();
                txtNotes.BackColor = Color.Silver;
                isValid = false;
                return isValid;
            }
            else
            {
                txtNotes.BackColor = Color.White;
            }

            return isValid;
        }

        private void FormReset()
        {
            txtEmployeeID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            txtNationalInsuranceNumber.Clear();
            dtpDateOfBirth.Value = new DateTime(1990, 12, 31);
            rdbMarried.Checked = false;
            rdbSingle.Checked = false;
            chkIsMember.Checked = false;
            txtAddress.Clear();
            txtCity.Clear();
            txtPostCode.Clear();
            cmbCountry.SelectedIndex = 0;
            txtPhoneNumber.Clear();
            txtEmailAddress.Clear();
            txtNotes.Clear();
        }
        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if(IsControlsDataValid())
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
            FormReset();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Employee Preview");
        }

        #region KeyPressEventValidation
        private void txtEmployeeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            cvf.IsNumberOrBackspaceValidation(txtEmployeeID, e);           
        }

        private static bool DataEntryErrorValidation(Control control, string Message)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                MessageBox.Show(Message, "Data Entry Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                control.Focus();
                control.BackColor = Color.Silver;
                return false;
            }
            else
            {
                control.BackColor = Color.White;
            }
            return true;
        }

        private static void IsNumberOrBackspace(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Check for either a number or backspace. Backspace checked using its ASCII value  
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                MessageBox.Show("Please enter numbers only!", "Numbers only!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                if(textBox != null)
                {
                    textBox.Focus();
                    textBox.BackColor = Color.Silver;
                }               
                e.Handled = true;
                return;
            }
            if (textBox != null)
            {
                textBox.Focus();
                textBox.BackColor = Color.White;
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            cvf.IsNumberOrBackspaceValidation(txtPhoneNumber, e);            
        }
        #endregion
    }
}
