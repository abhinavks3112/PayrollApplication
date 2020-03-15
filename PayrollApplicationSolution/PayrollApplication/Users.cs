using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PayrollApplication
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string RoleDescription { get; set; }

        public void AddUser()
        {
            string cs = ConfigurationManager.ConnectionStrings[Constants.CONNECTION_STRING].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spInsertUser", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Role", Role);
            cmd.Parameters.AddWithValue("@RoleDescription", RoleDescription);
            try
            {
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(Constants.MSG_USER_ADD_SUCCESS, Constants.MSG_ADD_SUCCESS_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(Constants.MSG_ERROR + ex.Message, Constants.MSG_DATA_ENTRY_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateUser()
        {
            string cs = ConfigurationManager.ConnectionStrings[Constants.CONNECTION_STRING].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateUser", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Role", Role);
            cmd.Parameters.AddWithValue("@RoleDescription", RoleDescription);
            try
            {
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(Constants.MSG_USER_UPDATE_SUCCESS, Constants.MSG_ADD_UPDATE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.MSG_ERROR + ex.Message, Constants.MSG_DATA_UPDATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void DeleteUser()
        {

        }

        public bool AuthorizeUser()
        {
            return true;
        }
    }
}
