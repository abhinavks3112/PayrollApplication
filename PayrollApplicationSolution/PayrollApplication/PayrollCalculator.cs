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
using System.Diagnostics;
using static PayrollApplication.Enums;

namespace PayrollApplication
{
    public partial class PayrollCalculator : Form
    {
        #region Global Variables
        CustomValidationsFunctions cvf = new CustomValidationsFunctions();

        string fullName = String.Empty;

        // Variable for each day of the week
        double[] monday = new double[4] { 0.0, 0.0, 0.0, 0.0 };
        double[] tuesday = new double[4] { 0.0, 0.0, 0.0, 0.0 };
        double[] wednesday = new double[4] { 0.0, 0.0, 0.0, 0.0 };
        double[] thursday = new double[4] { 0.0, 0.0, 0.0, 0.0 };
        double[] friday = new double[4] { 0.0, 0.0, 0.0, 0.0 };
        double[] saturday = new double[4] { 0.0, 0.0, 0.0, 0.0 };
        double[] sunday = new double[4] { 0.0, 0.0, 0.0, 0.0 };

        // Variables for hours
        double[] totalHoursWeek = new double[4];
        double[] contractualHoursWeek = new double[4];
        double[] overtimeHoursWeek = new double[4];
        double totalContractualHours, totalOvertimeHours, totalHoursWorked;

        // Variables for amount
        double[] contractualAmountWeek = new double[4];
        double[] overtimeAmountWeek = new double[4];
        double totalContractualAmount, totalOvertimeAmount, totalAmountEarned;

        // Variable for mandatory deduction
        double tax, NIContribution, taxRate, NIRate, SLC, totalDeductions;

        // Varibale for voluntary deductions
        const double Union = Constants.VOLUNTARY_DEDUCTION_UNION;
        const double SLCRate = Constants.VOLUNTARY_DEDUCTION_SLC_RATE; // Student loan rate

        // Varibale for pay rates
        double hourlySalaryRate, overtimeSalaryRate;

        // Variable for net pay
        double netPay;


        #endregion

        public PayrollCalculator()
        {
            InitializeComponent();
        }

        #region User Defined Functions

        private void ListOfMonths()
        {
            // String Array
            string[] months = {Constants.SELECT_A_MONTH, Constants.JANUARY, Constants.FEBRUARY, Constants.MARCH, Constants.APRIL, Constants.MAY,
                               Constants.JUNE, Constants.JULY, Constants.AUGUST, Constants.SEPTEMBER, Constants.OCTOBER, Constants.NOVEMBER, Constants.DECEMBER};

            // Iterate over months array and populate the comboboxes
            foreach (var month in months)
            {
                cmbPayMonth.Items.Add(month);
                cmbSearchPayMonth.Items.Add(month);
            }

            // Making first element default
            cmbPayMonth.SelectedIndex = 0;
            cmbSearchPayMonth.SelectedIndex = 0;
        }

        private void ComputeNetPayment()
        {
            try
            {
                #region Total working hour per week calculation

                CalculateWorkingHoursPerWeek();

                #endregion

                #region Salary for the month based on contractual hour and overtime hours calculation

                CalculateMonthlyWorkingAmountWithoutDeductions();

                #endregion

                #region Deductions Computation

                CalculateMonthlyDeductions();

                #endregion

                // Net payment after deductions
                netPay = totalAmountEarned - totalDeductions;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(Constants.MSG_ERROR + ex.Message, Constants.MSG_INVALID_DATA_FORMAT_ERROR);
            }
            catch(Exception ex)
            {
                MessageBox.Show(Constants.MSG_ERROR + ex.Message, Constants.MSG_INVALID_DATA_FORMAT_ERROR);
            }
        }

        private void DisplaySalaryAndDeductions()
        {
            // Hours
            txtContractualHours.Text = Convert.ToString(totalContractualHours);            
            txtOvertimeHours.Text = Convert.ToString(totalOvertimeHours);
            txtOvertimeRate.Text = Convert.ToString(Constants.OVERTIME_RATE_MULTIPLIER);
            txtTotalHoursWorked.Text = Convert.ToString(totalHoursWorked);

            // Earnings
            txtContractualEarnings.Text = Convert.ToString(totalContractualAmount);
            txtOvertimeEarnings.Text = Convert.ToString(totalOvertimeAmount);
            txtTotalEarnings.Text = Convert.ToString(totalAmountEarned);

            //Deductions
            txtTaxCode.Text = Constants.TAX_CODE_2019_20;
            txtTaxAmount.Text = Convert.ToString(tax);
            txtNIContribution.Text = Convert.ToString(NIContribution);
            txtUnion.Text = Convert.ToString(Union);
            txtSLC.Text = Convert.ToString(SLC);
            txtTotalDeductions.Text = Convert.ToString(totalDeductions);

            // Net Pay
            txtNetPay.Text = Convert.ToString(netPay);

        }

        private void CalculateMonthlyWorkingAmountWithoutDeductions()
        {
            // Retrieve Hourly Rate, Overtime rate, contractual hour rate
            hourlySalaryRate = double.Parse(nudHourlyRate.Value.ToString());
            overtimeSalaryRate = hourlySalaryRate * Constants.OVERTIME_RATE_MULTIPLIER;

            for (int i = 0; i < Constants.WEEKS_IN_CONSIDERATION; i++)
            {
                // Total Hours worked in a week, without overtime
                if (totalHoursWeek[i] <= Constants.WEEKLY_CONTRACTUAL_HOURS)
                {
                    contractualHoursWeek[i] = totalHoursWeek[i];
                    contractualAmountWeek[i] = hourlySalaryRate * contractualHoursWeek[i];
                    overtimeHoursWeek[i] = Constants.ZERO_DOUBLE_DECIMAL;
                    overtimeAmountWeek[i] = Constants.ZERO_DOUBLE_DECIMAL;
                }
                // Total Hours worked in a week, with overtime
                else if (totalHoursWeek[i] > Constants.WEEKLY_CONTRACTUAL_HOURS)
                {
                    contractualHoursWeek[i] = Constants.WEEKLY_CONTRACTUAL_HOURS;
                    contractualAmountWeek[i] = hourlySalaryRate * contractualHoursWeek[i];
                    overtimeHoursWeek[i] = totalHoursWeek[i] - contractualHoursWeek[i];
                    overtimeAmountWeek[i] = overtimeSalaryRate * overtimeHoursWeek[i];
                }

                // Total Contractual hours, Overtime Hours and respective Amount for the month
                totalContractualHours += contractualHoursWeek[i];
                totalOvertimeHours += overtimeHoursWeek[i];
                totalContractualAmount += contractualAmountWeek[i];
                totalOvertimeAmount += overtimeAmountWeek[i];
            }

            // Total Hours worked in month and respective amount
            totalHoursWorked = totalContractualHours + totalOvertimeHours;
            totalAmountEarned = totalContractualAmount + totalOvertimeAmount;
        }

        private void CalculateWorkingHoursPerWeek()
        {
            // Week 1
            monday[0] = double.Parse(nudMon1.Value.ToString());
            tuesday[0] = double.Parse(nudTues1.Value.ToString());
            wednesday[0] = double.Parse(nudWed1.Value.ToString());
            thursday[0] = double.Parse(nudThurs1.Value.ToString());
            friday[0] = double.Parse(nudFri1.Value.ToString());
            saturday[0] = double.Parse(nudSat1.Value.ToString());
            sunday[0] = double.Parse(nudSun1.Value.ToString());

            totalHoursWeek[0] = monday[0] + tuesday[0] + wednesday[0] + thursday[0] + friday[0] + saturday[0] + sunday[0];

            // Week 2
            monday[1] = double.Parse(nudMon2.Value.ToString());
            tuesday[1] = double.Parse(nudTues2.Value.ToString());
            wednesday[1] = double.Parse(nudWed2.Value.ToString());
            thursday[1] = double.Parse(nudThurs2.Value.ToString());
            friday[1] = double.Parse(nudFri2.Value.ToString());
            saturday[1] = double.Parse(nudSat2.Value.ToString());
            sunday[1] = double.Parse(nudSun2.Value.ToString());

            totalHoursWeek[1] = monday[1] + tuesday[1] + wednesday[1] + thursday[1] + friday[1] + saturday[1] + sunday[1];

            // Week 3
            monday[2] = double.Parse(nudMon3.Value.ToString());
            tuesday[2] = double.Parse(nudTues3.Value.ToString());
            wednesday[2] = double.Parse(nudWed3.Value.ToString());
            thursday[2] = double.Parse(nudThurs3.Value.ToString());
            friday[2] = double.Parse(nudFri3.Value.ToString());
            saturday[2] = double.Parse(nudSat3.Value.ToString());
            sunday[2] = double.Parse(nudSun3.Value.ToString());

            totalHoursWeek[2] = monday[2] + tuesday[2] + wednesday[2] + thursday[2] + friday[2] + saturday[2] + sunday[2];

            // Week 4
            monday[3] = double.Parse(nudMon4.Value.ToString());
            tuesday[3] = double.Parse(nudTues4.Value.ToString());
            wednesday[3] = double.Parse(nudWed4.Value.ToString());
            thursday[3] = double.Parse(nudThurs4.Value.ToString());
            friday[3] = double.Parse(nudFri4.Value.ToString());
            saturday[3] = double.Parse(nudSat4.Value.ToString());
            sunday[3] = double.Parse(nudSun4.Value.ToString());

            totalHoursWeek[3] = monday[3] + tuesday[3] + wednesday[3] + thursday[3] + friday[3] + saturday[3] + sunday[3];
        }

        private void CalculateMonthlyDeductions()
        {
            #region Income Tax Deductions Computation

            // Compute for income tax
            if (totalAmountEarned <= Constants.TAX_FREE_MONTHLY_INCOME_UPPER_LIMIT)
            {
                // Tax Free rate
                taxRate = Constants.ZERO_DOUBLE_DECIMAL;

                // Income tax
                tax = totalAmountEarned * taxRate;
            }
            else if (totalAmountEarned > Constants.TAX_FREE_MONTHLY_INCOME_UPPER_LIMIT && totalAmountEarned <= Constants.TAX_BASIC_MONTHLY_INCOME_UPPER_LIMIT)
            {
                // Basic Tax rate
                taxRate = Constants.TAX_RATE_BASIC_MONTHLY_INCOME_UPPER_LIMIT;

                // Income tax
                tax = (totalAmountEarned - Constants.TAX_FREE_MONTHLY_INCOME_UPPER_LIMIT) * taxRate;
            }
            else if (totalAmountEarned > Constants.TAX_BASIC_MONTHLY_INCOME_UPPER_LIMIT && totalAmountEarned <= Constants.TAX_HIGHER_MONTHLY_INCOME_UPPER_LIMIT)
            {
                // Higher Tax rate
                taxRate = Constants.TAX_RATE_HIGHER_MONTHLY_INCOME_UPPER_LIMIT;

                // Income tax
                tax = ((Constants.TAX_BASIC_MONTHLY_INCOME_UPPER_LIMIT - Constants.TAX_FREE_MONTHLY_INCOME_UPPER_LIMIT) * Constants.TAX_RATE_BASIC_MONTHLY_INCOME_UPPER_LIMIT)
                    + ((totalAmountEarned - Constants.TAX_BASIC_MONTHLY_INCOME_UPPER_LIMIT) * taxRate);
            }
            else if (totalAmountEarned > Constants.TAX_HIGHER_MONTHLY_INCOME_UPPER_LIMIT)
            {
                // Additional Tax rate
                taxRate = Constants.TAX_RATE_ADDITIONAL_INCOME_UPPER_LIMIT;

                // Income tax
                tax = ((Constants.TAX_BASIC_MONTHLY_INCOME_UPPER_LIMIT - Constants.TAX_FREE_MONTHLY_INCOME_UPPER_LIMIT) * Constants.TAX_RATE_BASIC_MONTHLY_INCOME_UPPER_LIMIT)
                   + ((Constants.TAX_HIGHER_MONTHLY_INCOME_UPPER_LIMIT - Constants.TAX_BASIC_MONTHLY_INCOME_UPPER_LIMIT) * Constants.TAX_RATE_HIGHER_MONTHLY_INCOME_UPPER_LIMIT)
                   + ((totalAmountEarned - Constants.TAX_HIGHER_MONTHLY_INCOME_UPPER_LIMIT) * taxRate);
            }
            #endregion

            #region NIContribution Computation
            if (totalAmountEarned <= Constants.NIC_PRIMARY_THRESHOLD)
            {
                // Lower Income Limit(LEL) or Primary Threshold
                NIRate = Constants.ZERO_DOUBLE_DECIMAL;
            }
            else if (totalAmountEarned > Constants.NIC_PRIMARY_THRESHOLD && totalAmountEarned <= Constants.NIC_PRIMARY_UPPER_EARNING_LIMIT)
            {
                // Primary - Upper Earning Limit(UEL)
                NIRate = Constants.NI_RATE_AFTER_PRIMARY_THRESHOLD;
            }
            else if (totalAmountEarned > Constants.NIC_PRIMARY_UPPER_EARNING_LIMIT)
            {
                // Secondary - Upper Earning Limit(UEL)
                NIRate = Constants.NI_RATE_AFTER_PRIMARY_UPPER_EARNING_LIMIT;
            }

            #endregion

            NIContribution = totalAmountEarned * NIRate;
            SLC = totalAmountEarned * SLCRate;

            // Total Amount deductable
            totalDeductions = tax + NIContribution + SLC + Union;
        }

        private bool ValidateControls()
        {
            // Validate Employee ID
            var textboxControl = new Dictionary<Control, Enums.TextBoxEntryCheck>();
            textboxControl.Add(txtEmployeeID, TextBoxEntryCheck.CHECK_IF_ANY_NUMBER_ENTERED);
            
            if (cvf.IsFormControlNullOrEmptyValidation(textboxControl) == false)
            {
                return false;
            }

            //  Validate Pay Period
            if(listBoxPayPeriod.SelectedIndex == 0)
            {
                MessageBox.Show(Constants.MSG_SELECT_PAY_PERIOD, Constants.MSG_NO_SELECTION_ERROR);
                listBoxPayPeriod.Focus();
                return false;
            }

            // Validate Pay Month
            if (cmbPayMonth.SelectedIndex == 0)
            {
                MessageBox.Show(Constants.MSG_SELECT_PAY_MONTH, Constants.MSG_NO_SELECTION_ERROR);
                cmbPayMonth.Focus();
                return false;
            }

            return true;
        }

        private void ResetControls()
        {
            #region Reset Employee Details Section

            txtEmployeeID.Text = String.Empty;
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtNINumber.Text = String.Empty;
            lblEmployeeFullName.Text = String.Empty;

            #endregion

            #region Reset Date Section

            listBoxPayPeriod.SelectedIndex = Constants.INDEX_ZERO;
            cmbPayMonth.SelectedIndex = Constants.INDEX_ZERO;

            #endregion

            #region Reset Timesheet Section

            nudMon1.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudTues1.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudWed1.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudThurs1.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudFri1.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudSat1.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudSun1.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;

            nudMon2.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudTues2.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudWed2.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudThurs2.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudFri2.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudSat2.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudSun2.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;

            nudMon3.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudTues3.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudWed3.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudThurs3.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudFri3.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudSat3.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudSun3.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;

            nudMon4.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudTues4.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudWed4.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudThurs4.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudFri4.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudSat4.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            nudSun4.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;

            nudHourlyRate.Text = Constants.HOURLY_RATE_INITIAL_VALUE_STRING_DOUBLE_DECIMAL;

            #endregion

            #region Reset Hours & Earnings Section

            #region Reset Hours Sub-Section

            txtContractualHours.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            txtOvertimeHours.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            txtOvertimeRate.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            txtTotalHoursWorked.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;

            #endregion

            #region Reset Earnings Sub-Section

            txtContractualEarnings.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            txtOvertimeEarnings.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            txtTotalEarnings.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;

            #endregion

            #endregion

            #region Reset Deductions Section

            txtTaxCode.Text = Constants.TAX_CODE_2019_20;
            txtTaxAmount.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            txtNIContribution.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            txtUnion.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            txtSLC.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            txtTotalDeductions.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;

            #endregion

            #region Reset Convert Time To Decimal Section

            txtHours.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            txtMinutes.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
            txtDecimalHours.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;

            #endregion

            #region Reset Search Payment Section

            ClearSearch();

            #endregion

            txtNetPay.Text = Constants.ZERO_STRING_DOUBLE_DECIMAL;
        }

        private void ClearSearch()
        {
            txtSearchPaymentID.Text = String.Empty;
            txtSearchEmployeeID.Text = String.Empty;
            txtSearchFullName.Text = String.Empty;
            txtSearchNINumber.Text = String.Empty;
            txtSearchPayDate.Text = String.Empty;
            cmbSearchPayMonth.SelectedIndex = Constants.INDEX_ZERO;
        }

        private void SavePayment()
        {
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(cs);

            string insertCommand = "INSERT INTO tblPayRecords" +
                "(EmployeeID, FullName, NINumber, PayDate, PayPeriod, PayMonth, HourlyRate, ContractualHours, OvertimeHours, TotalHours, ContractualEarnings, " +
                "OvertimeEarnings, TotalEarnings, TaxCode, TaxAmount, NIContribution, UnionFee, SLC, TotalDeductions, NetPay) " +
                "VALUES(@EmployeeID, @FullName, @NINumber," +
                "@PayDate, @PayPeriod, @PayMonth, @HourlyRate, @ContractualHours, @OvertimeHours, @TotalHours, @ContractualEarnings, " +
                "@OvertimeEarnings, @TotalEarnings, @TaxCode, @TaxAmount, @NIContribution, @UnionFee, @SLC, @TotalDeductions, @NetPay)";

            SqlCommand cmd = new SqlCommand(insertCommand, sqlConnection);
            cmd.Parameters.AddWithValue("@EmployeeID", Convert.ToInt32(txtEmployeeID.Text));
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@NINumber", txtNINumber.Text);
            cmd.Parameters.AddWithValue("@PayDate", dtpCurrentDate.Value.ToString("MM/dd/yyyy"));
            cmd.Parameters.AddWithValue("@PayPeriod", listBoxPayPeriod.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@PayMonth", cmbPayMonth.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@HourlyRate", nudHourlyRate.Value);
            cmd.Parameters.AddWithValue("@ContractualHours", totalContractualHours);
            cmd.Parameters.AddWithValue("@OvertimeHours", totalOvertimeHours);
            cmd.Parameters.AddWithValue("@TotalHours", totalHoursWorked);
            cmd.Parameters.AddWithValue("@ContractualEarnings", totalContractualAmount);
            cmd.Parameters.AddWithValue("@OvertimeEarnings", totalOvertimeAmount);
            cmd.Parameters.AddWithValue("@TotalEarnings", totalAmountEarned);
            cmd.Parameters.AddWithValue("@TaxCode", txtTaxCode.Text);
            cmd.Parameters.AddWithValue("@TaxAmount", tax);
            cmd.Parameters.AddWithValue("@NIContribution", NIContribution);
            cmd.Parameters.AddWithValue("@UnionFee", Union);
            cmd.Parameters.AddWithValue("@SLC", SLC);
            cmd.Parameters.AddWithValue("@TotalDeductions", totalDeductions);
            cmd.Parameters.AddWithValue("@NetPay", netPay);

            try
            {
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(Constants.MSG_EMPLOYEE_SALARY_ADD_SUCCESS, Constants.MSG_ADD_SUCCESS_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(Constants.MSG_ERROR + ex.Message, Constants.MSG_DATA_SAVING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
            ResetControls();
            // TODO: This line of code loads data into the 'payrollSystemDBDataSet1.tblPayRecords' table. You can move, or remove it, as needed.
            this.tblPayRecordsTableAdapter.Fill(this.payrollSystemDBDataSet1.tblPayRecords);
        }

        #endregion
        private void txtEmployeeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            cvf.IsNumberOrBackspaceValidation(txtEmployeeID, e);
        }

        private void btnTimeToDecimalConvertor_Click(object sender, EventArgs e)
        {            
            double result = Convert.ToDouble(txtHours.Text) + (Convert.ToDouble(txtMinutes.Text) / 60);
            txtDecimalHours.Text = String.Format("{0:0.00}", result);
        }

        private void txtHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            cvf.IsNumberOrBackspaceValidation(txtHours, e);
        }

        private void txtMinutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            cvf.IsNumberOrBackspaceValidation(txtMinutes, e);
        }

        private void txtSearchPaymentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            cvf.IsNumberOrBackspaceValidation(txtSearchPaymentID, e);
        }

        private void txtSearchEmployeeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            cvf.IsNumberOrBackspaceValidation(txtSearchEmployeeID, e);
        }

        private void linkLabelWindowsCalculator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void PayrollTimer_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            btnTime.Text = dt.ToString("HH:mm:ss");
        }

        private void btnComputePay_Click(object sender, EventArgs e)
        {
            if(ValidateControls())
            {
                ComputeNetPayment();
                DisplaySalaryAndDeductions();
            }          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSavePay_Click(object sender, EventArgs e)
        {
            SavePayment();
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
            ResetControls();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder searchStatement = new StringBuilder();
                // Payment ID
                if(txtSearchPaymentID.Text.Length > 0)
                {
                    // Converting Int to String
                    searchStatement.Append("Convert(PaymentID, 'System.String') like '%" + txtSearchPaymentID.Text + "%'");
                }
                // Employee ID
                if (txtSearchEmployeeID.Text.Length > 0)
                {
                    if(searchStatement.Length > 0)
                    {
                        searchStatement.Append(" and ");
                    }
                    // Converting Int to String
                    searchStatement.Append("Convert(EmployeeID, 'System.String') like '%" + txtSearchEmployeeID.Text + "%'");
                }
                // Full Name
                if (txtSearchFullName.Text.Length > 0)
                {
                    if (searchStatement.Length > 0)
                    {
                        searchStatement.Append(" and ");
                    }
                    searchStatement.Append("FullName like '%" + txtSearchFullName.Text + "%'");
                }
                // NI Number
                if (txtSearchNINumber.Text.Length > 0)
                {
                    if (searchStatement.Length > 0)
                    {
                        searchStatement.Append(" and ");
                    }
                    searchStatement.Append("Convert(NINumber, 'System.String') like '%" + txtSearchNINumber.Text + "%'");
                }
                // Pay Date
                if (txtSearchPayDate.Text.Length > 0)
                {
                    if (searchStatement.Length > 0)
                    {
                        searchStatement.Append(" and ");
                    }
                    searchStatement.Append("Convert(PayDate, 'System.String') like '%" + txtSearchPayDate.Text + "%'");
                }
                // Pay Month
                if (cmbSearchPayMonth.SelectedIndex > 0)
                {
                    if (searchStatement.Length > 0)
                    {
                        searchStatement.Append(" and ");
                    }
                    searchStatement.Append("PayMonth like '%" + cmbSearchPayMonth.SelectedItem.ToString() + "%'");
                }
                // Filter the data grid
                tblPayRecordsBindingSource.Filter = searchStatement.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.MSG_ERROR + ex.Message, Constants.MSG_DATA_SEARCH_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void PayrollCalculator_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payrollSystemDBDataSet1.tblPayRecords' table. You can move, or remove it, as needed.
            this.tblPayRecordsTableAdapter.Fill(this.payrollSystemDBDataSet1.tblPayRecords);
            ListOfMonths();
            ResetControls();
            PayrollTimer.Start();
        }
    }
}
