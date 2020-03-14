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
        Users user;
        #endregion

        #region User Defined Functions

        private void ClearControls()
        {
            txtUserName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtConfirmPassword.Text = String.Empty;
            txtRole.Text = String.Empty;
            txtRoleDescription.Text = String.Empty;
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
        private bool AreRegisterControlsValid()
        {
            Dictionary<Control, TextBoxEntryCheck> ControlsList = new Dictionary<Control, TextBoxEntryCheck>();
            ControlsList.Add(txtUserName, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);
            ControlsList.Add(txtPassword, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);
            ControlsList.Add(txtConfirmPassword, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);
            ControlsList.Add(txtRole, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);

            if (cvf.IsFormControlNullOrEmptyValidation(ControlsList) == false)
            {
                return false;
            }
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
                if(txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show(Constants.MSG_PASSWORD_MATCH_ERROR, Constants.MSG_DATA_ENTRY_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmPassword.Focus();
                    return false;
                }
            }
            return true;
        }
        
        private void UserData()
        {
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.Role = txtRole.Text;
            user.RoleDescription = txtRoleDescription.Text;
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
                if (AreRegisterControlsValid())
                {
                    UserData();
                    user.AddUser();
                }
                this.tblUsersTableAdapter.Fill(this.usersDataSet.tblUsers);
                ClearControls();
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
        }
    }
}
