using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PayrollApplication.Enums;

namespace PayrollApplication
{
    public partial class Register : Form
    {
        #region Global Variables
        CustomValidationsFunctions cvf = new CustomValidationsFunctions();
        Constants constants = new Constants();
        Colors colors = new Colors();
        Users user;
        #endregion

        #region User Defined Functions

        private void ClearControls()
        {
            SetFieldsToEmptyString();
            SetFieldsBackColorToNormal();

            if (txtPassword.Enabled == false || txtConfirmPassword.Enabled == false)
            {
                EnablePasswordFields();
            }
            // Deselect the datagridview
            dataGridView1.ClearSelection();

            // Reset the user object data
            user = null;
        }

        private void EnablePasswordFields()
        {
            // Enable the password field
            txtPassword.Enabled = true;
            txtPassword.BackColor = colors.NORMAL_COLOR;
            txtConfirmPassword.Enabled = true;
            txtConfirmPassword.BackColor = colors.NORMAL_COLOR;
        }
        private void DisablePasswordFields()
        {
            // Disable the password field
            txtPassword.Enabled = false;
            txtPassword.BackColor = colors.CONTROL_DISABLED;
            txtConfirmPassword.Enabled = false;
            txtConfirmPassword.BackColor = colors.CONTROL_DISABLED;
        }

        private void SetFieldsToEmptyString()
        {
            txtUserName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtConfirmPassword.Text = String.Empty;
            txtRole.Text = String.Empty;
            txtRoleDescription.Text = String.Empty;
        }
        private void SetFieldsBackColorToNormal()
        {
            txtUserName.BackColor = colors.NORMAL_COLOR; 
            txtPassword.BackColor = colors.NORMAL_COLOR;
            txtConfirmPassword.BackColor = colors.NORMAL_COLOR;
            txtRole.BackColor = colors.NORMAL_COLOR;
            txtRoleDescription.BackColor = colors.NORMAL_COLOR;
        }

        private int CheckNumeric(string text)
        {
            int numOfDigits = 0;
            foreach (char ch in text)
            {
                if (char.IsDigit(ch))
                {
                    numOfDigits++;
                }
            }
            return numOfDigits;
        }

        private int CheckLowerCase(string text)
        {
            int numOfLowerCaseChar = 0;
            foreach (char ch in text)
            {
                if (char.IsLower(ch))
                {
                    numOfLowerCaseChar++;
                }
            }
            return numOfLowerCaseChar;
        }

        private int CheckUpperCase(string text)
        {
            int numOfUpperCaseChar = 0;
            foreach (char ch in text)
            {
                if (char.IsUpper(ch))
                {
                    numOfUpperCaseChar++;
                }
            }
            return numOfUpperCaseChar;
        }
        private bool AreRegisterControlsValid(DataOperationMode mode)
        {
            Dictionary<Control, TextBoxEntryCheck> ControlsList = new Dictionary<Control, TextBoxEntryCheck>();
            
            ControlsList.Add(txtUserName, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);

            // Check if username is not null or empty
            if (cvf.IsFormControlNullOrEmptyValidation(ControlsList) == false)
            {
                ControlsList.Remove(txtUserName);
                return false;
            }

           
            if (mode == DataOperationMode.INSERT)
            {
                ControlsList.Add(txtPassword, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);
                ControlsList.Add(txtConfirmPassword, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);
                
                // Check if password is not null or empty
                if (cvf.IsFormControlNullOrEmptyValidation(ControlsList) == false)
                {
                    ControlsList.Remove(txtPassword);
                    ControlsList.Remove(txtConfirmPassword);
                    return false;
                }
                // If password is not null or empty then check and compare password and confirm password field
                else
                {
                    #region Password pattern requirement
                    // The password must be a minimum of 8 characters long
                    // The password must contain atleast 1 uppercase letter
                    // The password must be a minimum of 1 lowercase letter
                    // The password must contain atleast 1 numeric
                    #endregion
                    if (txtPassword.Text.Length < Constants.USER_PASSWORD_MIN_CHARACTERS_CONSTRAINT
                        || CheckUpperCase(txtPassword.Text) < Constants.USER_PASSWORD_MIN_UPPERCASE_CHARACTERS_CONSTRAINT
                        || CheckLowerCase(txtPassword.Text) < Constants.USER_PASSWORD_MIN_LOWERCASE_CHARACTERS_CONSTRAINT
                        || CheckNumeric(txtPassword.Text) < Constants.USER_PASSWORD_MIN_DIGIT_CHARACTERS_CONSTRAINT
                        )
                    {
                        MessageBox.Show(Constants.MSG_PLEASE_ENTER_VALID_PASSWORD + "\n\n HINT: \n\t"
                            + constants.USER_PASSWORD_MIN_CHARACTERS_MSG + "\n\t"
                            + constants.USER_PASSWORD_MIN_UPPERCASE_CHARACTERS_MSG + "\n\t"
                            + constants.USER_PASSWORD_MIN_LOWERCASE_CHARACTERS_MSG + "\n\t"
                            + constants.USER_PASSWORD_MIN_DIGIT_CHARACTERS_MSG
                            , Constants.MSG_DATA_ENTRY_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtConfirmPassword.Focus();
                        return false;
                    }

                    // Password and Confirm password are not empty, then compare them
                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        MessageBox.Show(Constants.MSG_PASSWORD_MATCH_ERROR, Constants.MSG_DATA_ENTRY_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtConfirmPassword.Focus();
                        return false;
                    }
                }
            }
            
            ControlsList.Add(txtRole, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);

            if (cvf.IsFormControlNullOrEmptyValidation(ControlsList) == false)
            {
                ControlsList.Remove(txtRole);
                return false;
            }

            ControlsList.Clear();
            return true;
        }
        
        private void UserData(DataOperationMode mode)
        {
            
            if (mode == DataOperationMode.INSERT)
            {
                user.Password = txtPassword.Text;
            }
            if(mode == DataOperationMode.UPDATE || mode == DataOperationMode.DELETE)
            {
                // User Id only in case of update and we get it from selected row/cell in datagridview
                user.UserId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            if (mode == DataOperationMode.INSERT || mode == DataOperationMode.UPDATE)
            {
                user.UserName = txtUserName.Text;
                user.Role = txtRole.Text;
                user.RoleDescription = txtRoleDescription.Text;
            }
        }

        private void OnUserSelect()
        {
            DisablePasswordFields();

            // Fill the textboxes with the current selected row's values
            DataGridViewCellCollection cells = dataGridView1.CurrentRow.Cells;
            txtUserName.Text = cells[1].Value.ToString();
            txtRole.Text = cells[2].Value.ToString();
            txtRoleDescription.Text = cells[3].Value.ToString();

            if (user == null)
            {
                user = new Users();
                // Updates user object data
                UserData(DataOperationMode.UPDATE);
            }
        }

        #endregion

        public Register()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (user == null)
                {
                    user = new Users();
                }

                // Fill user object with form fields data
                UserData(DataOperationMode.INSERT);

                // If user already present and trying to register then give error or if password field is disabled, which is in case of selecting an already registered user from data grid then also give error
                if (user.UserId > Constants.INDEX_ZERO || txtPassword.Enabled == false)
                {
                    MessageBox.Show(Constants.MSG_USER_ALREADY_EXISTS_ERROR, Constants.MSG_REGISTRATION_FAILED_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // If new user then validate user information
                else if (AreRegisterControlsValid(DataOperationMode.INSERT))
                {  
                    user.AddUser();
                    ClearControls();
                }
                this.tblUsersTableAdapter.Fill(this.usersDataSet.tblUsers);
                // Deselect the datagridview
                dataGridView1.ClearSelection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(Constants.MSG_ERROR + ex.Message, Constants.MSG_DATA_ENTRY_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'usersDataSet.tblUsers' table. You can move, or remove it, as needed.
            this.tblUsersTableAdapter.Fill(this.usersDataSet.tblUsers);

            ClearControls();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (user == null)
                {
                    user = new Users();
                }
                // If no user has been selected then give error
                if (user.UserId <= Constants.INDEX_ZERO)
                {
                    MessageBox.Show(Constants.MSG_USER_NOT_SELECTED_ERROR, Constants.MSG_UPDATION_FAILED_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearControls();
                    return;
                }
                if (AreRegisterControlsValid(DataOperationMode.UPDATE))
                {
                    UserData(DataOperationMode.UPDATE);
                    user.UpdateUser();
                }
                this.tblUsersTableAdapter.Fill(this.usersDataSet.tblUsers);
                ClearControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.MSG_ERROR + ex.Message, Constants.MSG_DATA_ENTRY_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (user == null)
                {
                    user = new Users();
                }
               
                // If no user has been selected then give error
                if (user.UserId <= Constants.INDEX_ZERO)
                {
                    MessageBox.Show(Constants.MSG_USER_NOT_SELECTED_ERROR, Constants.MSG_DELETION_FAILED_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearControls();
                    return;
                }
                else 
                {
                    dataGridView1_CellMouseClick(sender, e as DataGridViewCellMouseEventArgs);
                    UserData(DataOperationMode.DELETE);
                    DialogResult result = MessageBox.Show(String.Format(Constants.MSG_USER_DELETE_CONFIRM_QUESTION,user.UserId), Constants.MSG_CONFIRM_USER_DELETION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        user.DeleteUser();
                    }
                }
                this.tblUsersTableAdapter.Fill(this.usersDataSet.tblUsers);
                ClearControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.MSG_ERROR + ex.Message, Constants.MSG_DATA_ENTRY_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OnUserSelect();
        }
    }
}
