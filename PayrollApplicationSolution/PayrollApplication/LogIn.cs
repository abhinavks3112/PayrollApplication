using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using static PayrollApplication.Enums;

namespace PayrollApplication
{
    public partial class LogIn : Form
    {
        #region Global Variables

        private Users user;
        CustomValidationsFunctions cvf = new CustomValidationsFunctions();
        Colors colors = new Colors();
        #endregion

        #region User Defined Functions

        private void UsersData()
        {
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.Role = cmbRoles.SelectedItem.ToString();
        }

        private bool ValidateFields()
        {
            // Validate field to check if  it filled or not
            Dictionary<Control, TextBoxEntryCheck> controlsToValidate = new Dictionary<Control, TextBoxEntryCheck>();
            controlsToValidate.Add(txtUserName, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);
            controlsToValidate.Add(txtPassword, TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED);
            if (cvf.IsFormControlNullOrEmptyValidation(controlsToValidate) == false)
            {
                return false;
            }

            // Country Validation
            if (cmbRoles.SelectedIndex == Constants.INDEX_MINUS_ONE_OR_DEFAULT_INDEX)
            {
                MessageBox.Show(Constants.MSG_PLEASE_SELECT_ROLE, Constants.MSG_NO_ROLE_SELECTED_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRoles.Focus();
                cmbRoles.BackColor = colors.VALIDATION_ERROR;
                return false;
            }
            else
            {
                cmbRoles.BackColor = colors.NORMAL_COLOR;
            }

            return true;
        }

        private void GetRoles()
        {
            string cs = ConfigurationManager.ConnectionStrings[Constants.CONNECTION_STRING].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spSelectAllUserRoles", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Populate role combobox
                    cmbRoles.Items.Add(reader[0]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.MSG_ERROR + ex.Message, Constants.MSG_DATA_FETCHING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        #endregion
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            GetRoles();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(user == null)
            {
                user = new Users();
            }
            try
            {
                if (ValidateFields())
                {
                    UsersData();
                    if (user.AuthenticateUser())
                    {
                        PayrollMDI mDI = new PayrollMDI();
                        this.Hide();
                        mDI.Show();
                    }
                    else
                    {
                        MessageBox.Show(Constants.MSG_UNAUTHORIZED_USER_ERROR, Constants.MSG_LOG_IN_FAILED_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.MSG_ERROR + ex.Message, Constants.MSG_DATA_ENTRY_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                user = null;
            }
        }
    }
}
