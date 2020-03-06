using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace PayrollApplication
{
    public partial class PayrollCalculator : Form
    {
        // Global Varibales
        string fullName = String.Empty; 

        public PayrollCalculator()
        {
            InitializeComponent();
        }

        private void btnComputePay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment Computed!!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSavePay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment Saved!!");
        }

        private void btnGeneratePayslip_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payslip Generated!!");
        }

        private void btnPrintPayslip_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payslip Printing Done!!");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Form Reset!!");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Search cleared!!");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Searching...");
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            // Fetch connection string
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;

            //Instantiate the sql connection object with connection string
            SqlConnection sqlConnection = new SqlConnection(cs);

            try
            {
                sqlConnection.Open();

                // Select Command
                string SelectCommand = "SELECT FirstName, LastName, NINumber FROM tblEmployee WHERE EmployeeID = "+ Convert.ToInt32(txtEmployeeID.Text) + "";


                SqlCommand sqlCommand = new SqlCommand(SelectCommand, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if(sqlDataReader.Read())
                {
                    txtFirstName.Text = sqlDataReader[0].ToString();
                    txtLastName.Text = sqlDataReader[1].ToString();
                    txtNINumber.Text = sqlDataReader[2].ToString();
                    fullName = txtLastName.Text + " , " + txtFirstName.Text;
                    lblEmployeeFullName.Text = fullName;
                }
                else
                {
                    MessageBox.Show(Constants.MSG_NO_RECORDS_FOUND_WITH_EMPLOYEEID_ERROR + txtEmployeeID.Text, Constants.MSG_NO_RECORDS_FOUND_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlDataReader.Close();
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
    }
}
