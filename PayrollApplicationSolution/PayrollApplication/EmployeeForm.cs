using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static PayrollApplication.Enums;

namespace PayrollApplication
{
    public partial class EmployeeForm : Form
    {
        CustomValidationsFunctions cvf = new CustomValidationsFunctions();
        string gender;
        string maritalStatus;
        bool isMember;
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
                MessageBox.Show(Constants.MSG_SELECT_GENDER, Constants.MSG_NO_SELECTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(Constants.MSG_SELECT_MARITAL_STATUS, Constants.MSG_NO_SELECTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(Constants.MSG_SELECT_COUNTRY, Constants.MSG_NO_SELECTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCountry.Focus();
                cmbCountry.BackColor = Color.Silver;
                isValid = false;
                return isValid;
            }
            else
            {
                cmbCountry.BackColor = Color.White;
            }

            return isValid;
        }

        private void CheckedItems()
        {
            // Check Employee Gender
            if(rdbMale.Checked)
            {
                gender = Constants.GENDER_MALE;
            }
            else if(rdbFemale.Checked)
            {
                gender = Constants.GENDER_FEMALE;
            }            

            // Check Employee Marital Status
            if (rdbMarried.Checked)
            {
                maritalStatus = Constants.MARITAL_STATUS_MARRIED;
            }
            else if(rdbSingle.Checked)
            {
                maritalStatus = Constants.MARITAL_STATUS_SINGLE;
            }

            // Check if Employee is a Union Member
            if (chkIsMember.Checked)
            {
                isMember = true;
            }
            else if(chkIsMember.Checked == false)
            {
                isMember = false;
            }

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
            if (IsControlsDataValid())
            {
                CheckedItems();
                AddEmployee();
            }
        }

        private void AddEmployee()
        {
            // Fetch connection string
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;

            //Instantiate the sql connection object with connection string
            SqlConnection sqlConnection = new SqlConnection(cs);
            try
            {
                // Open connection
                sqlConnection.Open();

                // Prepare Insert Command
                string InsertCommand = "INSERT INTO tblEmployee(EmployeeID, FirstName," +
                    "LastName, Gender, NINumber, DateOfBirth, MaritalStatus, IsMember, Address, City, " +
                    "PostCode, Country, PhoneNumber, Email, Notes) VALUES (" + Convert.ToInt32(txtEmployeeID.Text)
                    + ", '" + txtFirstName.Text + "', '" + txtLastName.Text + "', '" + gender + "', '"
                    + txtNationalInsuranceNumber.Text + "','" + dtpDateOfBirth.Value.ToString("MM/dd/yyyy")
                    + "', '" + maritalStatus + "', '" + isMember + "', '" + txtAddress.Text + "', '" + txtCity.Text
                    + "', '" + txtPostCode.Text + "', '" + cmbCountry.SelectedItem.ToString() + "', '"
                    + txtPhoneNumber.Text + "', '" + txtEmailAddress.Text + "', '" + txtNotes.Text + "' )";

                // Instantiate sql command object with command string and sql connection object
                SqlCommand sqlCommand = new SqlCommand(InsertCommand, sqlConnection);

                // Execute the sql command object
                sqlCommand.ExecuteNonQuery();

                // Insert into data table
                this.tblEmployeeTableAdapter.Fill(this.payrollSystemDBDataSet.tblEmployee);

                // Display success message
                MessageBox.Show("EMPLOYEE WITH ID " + txtEmployeeID.Text + " HAS BEEN ADDED SUCCESSFULLY!!", Constants.MSG_EMPLOYEE_ADD_SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.MSG_ERROR + ex.Message, Constants.MSG_DATA_ENTRY_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close connection
                sqlConnection.Close();
                FormReset();
            }
        }

        private void UpdateEmployee()
        {
            // Fetch connection string
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;

            //Instantiate the sql connection object with connection string
            SqlConnection sqlConnection = new SqlConnection(cs);
            try
            {
                // Open connection
                sqlConnection.Open();

                // Prepare Insert Command
                string UpdateCommand = "UPDATE tblEmployee SET FirstName = '" + this.txtFirstName.Text 
                    + "', LastName = '" + this.txtLastName.Text + "', Gender = '" + this.gender + "', NINumber = '"
                    + this.txtNationalInsuranceNumber.Text + "', DateOfBirth = '" + this.dtpDateOfBirth.Value.ToString("MM/dd/yyyy")
                    + "', MaritalStatus = '" + this.maritalStatus + "', IsMember = '" + this.isMember + "', Address = '" + this.txtAddress.Text 
                    + "', City = '" + this.txtCity.Text + "', PostCode = '" + this.txtPostCode.Text 
                    + "', Country = '" + this.cmbCountry.SelectedItem.ToString() + "', PhoneNumber = '"+ this.txtPhoneNumber.Text 
                    + "', Email = '" + this.txtEmailAddress.Text + "', Notes = '" + this.txtNotes.Text 
                    + "' WHERE EmployeeID = " + Convert.ToInt32(this.txtEmployeeID.Text) + "";

                // Instantiate sql command object with command string and sql connection object
                SqlCommand sqlCommand = new SqlCommand(UpdateCommand, sqlConnection);

                // Execute the sql command object
                sqlCommand.ExecuteNonQuery();

                // Insert into data table
                this.tblEmployeeTableAdapter.Fill(this.payrollSystemDBDataSet.tblEmployee);

                // Display success message
                MessageBox.Show("EMPLOYEE WITH ID " + txtEmployeeID.Text + " HAS BEEN UPDATED SUCCESSFULLY!!", Constants.MSG_EMPLOYEE_UPDATE_SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.MSG_ERROR + ex.Message, Constants.MSG_DATA_ENTRY_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close connection
                sqlConnection.Close();
                FormReset();
            }
        }
        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            if (IsControlsDataValid())
            {
                CheckedItems();
                UpdateEmployee();
            }
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
            CheckedItems();
            string Country;
            if (cmbCountry.SelectedIndex == Constants.INDEX_ZERO || cmbCountry.SelectedIndex == Constants.INDEX_MINUS_ONE_OR_DEFAULT_INDEX)
            {
                Country = String.Empty;
            }
            else
            {
                Country = cmbCountry.SelectedItem.ToString();
            }
            PreviewForm previewForm = new PreviewForm();
            previewForm.PreviewEmployeeData(txtEmployeeID.Text, txtFirstName.Text, txtLastName.Text, gender,
                txtNationalInsuranceNumber.Text, dtpDateOfBirth.Text, maritalStatus, isMember, txtAddress.Text,
                txtCity.Text, txtPostCode.Text, Country,
                txtPhoneNumber.Text, txtEmailAddress.Text, txtNotes.Text);

            // To Display the form
            previewForm.ShowDialog();
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

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payrollSystemDBDataSet.tblEmployee' table. You can move, or remove it, as needed.
            this.tblEmployeeTableAdapter.Fill(this.payrollSystemDBDataSet.tblEmployee);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Reset any previous values first
            FormReset();

            // Populating the form by selecting row in data grid
            txtEmployeeID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            txtFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();

            gender = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            if (gender == Constants.GENDER_MALE)
                rdbMale.Checked = true;
            else if (gender == Constants.GENDER_FEMALE)
                rdbFemale.Checked = true;

            txtNationalInsuranceNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            dtpDateOfBirth.Text = dataGridView1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();

            maritalStatus = dataGridView1.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
            if (maritalStatus == Constants.MARITAL_STATUS_MARRIED)
                rdbMarried.Checked = true;
            else if (maritalStatus == Constants.MARITAL_STATUS_SINGLE)
                rdbSingle.Checked = true;

            isMember = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[7].FormattedValue.ToString());
            if (isMember)
                chkIsMember.Checked = true;

            txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
            txtCity.Text = dataGridView1.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();
            txtPostCode.Text = dataGridView1.Rows[e.RowIndex].Cells[10].FormattedValue.ToString();
            cmbCountry.Text = dataGridView1.Rows[e.RowIndex].Cells[11].FormattedValue.ToString();
            txtPhoneNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[12].FormattedValue.ToString();
            txtEmailAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[13].FormattedValue.ToString();
            txtNotes.Text = dataGridView1.Rows[e.RowIndex].Cells[14].FormattedValue.ToString();
        }
    }
}
