using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication
{
    public class Constants
    {
        #region Error Messages and Captions

        public const string MSG_DATA_ENTRY_ERROR = "DATA ENTRY ERROR!!";
        public const string MSG_DATA_UPDATION_ERROR = "DATA UPDATION ERROR!!";
        public const string MSG_DATA_DELETION_ERROR = "DATA DELETION ERROR!!";
        public const string MSG_DATA_FETCHING_ERROR = "DATA FETCHING ERROR!! ";
        public const string MSG_DATA_SAVING_ERROR = "DATA SAVING ERROR!! ";
        public const string MSG_DATA_SEARCH_ERROR = "DATA SEARCH ERROR!! ";
        public const string MSG_INVALID_CHARACTERS_ERROR = "INVALID CHARACTERS ENTERED!!";
        public const string MSG_EMPTY_FIELD_ERROR = "FIELD IS EMPTY!!";
        public const string MSG_INVALID_DATA_FORMAT_ERROR = "INVALID DATA FORMAT!!";
        public const string MSG_NO_SELECTION_ERROR = "NO OPTION SELECTED!!";
        public const string MSG_NO_RECORDS_FOUND_ERROR = "NO RECORDS FOUND!! ";
        public const string MSG_NO_RECORDS_FOUND_WITH_EMPLOYEEID_ERROR = "NO RECORDS FOUND WITH EMPLOYEE ID: ";
        public const string MSG_PASSWORD_MATCH_ERROR = "PASSWORDS DO NOT MATCH!!";
        public const string MSG_REGISTRATION_FAILED_ERROR = "REGISTERATION FAILED!!";
        public const string MSG_USER_ALREADY_EXISTS_ERROR = "USER IS ALREADY REGISTERED WITH THIS ID, KINDLY TRY THE UPDATE USER OPTION";
        public const string MSG_ERROR = "ERROR: ";

        public const string MSG_ADD_SUCCESS_CAPTION = "ADD SUCCESS";
        public const string MSG_ADD_UPDATE_CAPTION = "UPDATE SUCCESS";
        public const string MSG_ADD_DELETE_CAPTION = "DELETE SUCCESS";

        public const string MSG_ENTER_NUMBERS_ONLY = "PLEASE ENTER NUMBERS ONLY!!";
        public const string MSG_SELECT_GENDER = "PLEASE SELECT YOUR GENDER!!";
        public const string MSG_SELECT_MARITAL_STATUS = "PLEASE SELECT YOUR MARITAL STATUS!!";
        public const string MSG_SELECT_PAY_PERIOD = "PLEASE SELECT PAY PERIOD!!";
        public const string MSG_SELECT_PAY_MONTH = "PLEASE SELECT PAY MONTH!!";
        public const string MSG_SELECT_COUNTRY = "PLEASE SELECT YOUR COUNTRY FROM THE DROP DOWN LIST!!";
        public const string MSG_PLEASE_ENTER = "PLEASE ENTER ";
        public const string MSG_PLEASE_ENTER_VALID = "PLEASE ENTER VALID ";
        public const string MSG_PLEASE_ENTER_VALID_PASSWORD = "PLEASE ENTER VALID PASSWORD";

        public const string MSG_EMPLOYEE_ADD_SUCCESS = "EMPLOYEE RECORD HAS BEEN ADDED SUCCESSFULLY!!";        
        public const string MSG_EMPLOYEE_UPDATE_SUCCESS = "EMPLOYEE RECORD HAS BEEN UPDATED SUCCESSFULLY!!";
        public const string MSG_EMPLOYEE_DELETE_SUCCESS = "EMPLOYEE RECORD HAS BEEN DELETED SUCCESSFULLY!!";
        public const string MSG_EMPLOYEE_DELETE_CONFIRM_QUESTION = "ARE YOU SURE YOU WANT TO PERMANENTLY DELETE THIS EMPLOYEE'S RECORD?";
        public const string MSG_CONFIRM_EMPLOYEE_DELETION = "CONFIRM EMPLOYEE DELETION";

        public const string MSG_USER_ADD_SUCCESS = "USER'S RECORD HAS BEEN ADDED SUCCESSFULLY!!";
        public const string MSG_USER_UPDATE_SUCCESS = "USER'S RECORD HAS BEEN UPDATED SUCCESSFULLY!!";
        public const string MSG_USER_DELETE_SUCCESS = "USER'S RECORD HAS BEEN DELETED SUCCESSFULLY!!";

        public const string MSG_EMPLOYEE_SALARY_ADD_SUCCESS = "EMPLOYEE'S SALARY RECORD HAS BEEN ADDED SUCCESSFULLY!!";

        #endregion

        #region Form Fields Values, constraints

        public const string TRIPLE_SPACE = "   ";

        public const int INDEX_ZERO = 0;
        public const int INDEX_MINUS_ONE_OR_DEFAULT_INDEX = -1;

        public const string GENDER_MALE = "Male";
        public const string GENDER_FEMALE = "Female";
        public const string MARITAL_STATUS_MARRIED = "Married";
        public const string MARITAL_STATUS_SINGLE = "Single";

        public const int NOTES_FIELD_SIZE_CONSTRAINT = 30;
        public const int USER_PASSWORD_MIN_CHARACTERS_CONSTRAINT = 8;
        public const int USER_PASSWORD_MIN_UPPERCASE_CHARACTERS_CONSTRAINT = 1;
        public const int USER_PASSWORD_MIN_LOWERCASE_CHARACTERS_CONSTRAINT = 1;
        public const int USER_PASSWORD_MIN_DIGIT_CHARACTERS_CONSTRAINT = 1;

        // Password Pattern Constraint Message
        public readonly string USER_PASSWORD_MIN_CHARACTERS_MSG= "PASSWORD MUST CONTAIN ATLEAST  " + USER_PASSWORD_MIN_CHARACTERS_CONSTRAINT + " CHARACTER(S)";
        public readonly string USER_PASSWORD_MIN_UPPERCASE_CHARACTERS_MSG = "PASSWORD MUST CONTAIN ATLEAST  " + USER_PASSWORD_MIN_UPPERCASE_CHARACTERS_CONSTRAINT + " UPPERCASE CHARACTER(S)";
        public readonly string USER_PASSWORD_MIN_LOWERCASE_CHARACTERS_MSG = "PASSWORD MUST CONTAIN ATLEAST  " + USER_PASSWORD_MIN_LOWERCASE_CHARACTERS_CONSTRAINT + " LOWERCASE CHARACTER(S)";
        public readonly string USER_PASSWORD_MIN_DIGIT_CHARACTERS_MSG = "PASSWORD MUST CONTAIN ATLEAST  " + USER_PASSWORD_MIN_DIGIT_CHARACTERS_CONSTRAINT + " NUMERIC DIGIT(S)";

        public const double ZERO_DOUBLE_DECIMAL = 0.00;
        public const string ZERO_STRING_DOUBLE_DECIMAL = "0.00";

        // Months
        public const string SELECT_A_MONTH = "Please select a month..";
        public const string JANUARY = "January";
        public const string FEBRUARY = "February";
        public const string MARCH = "March";
        public const string APRIL = "April";
        public const string MAY = "May";
        public const string JUNE = "June";
        public const string JULY = "July";
        public const string AUGUST = "August";
        public const string SEPTEMBER = "September";
        public const string OCTOBER = "October";
        public const string NOVEMBER = "November";
        public const string DECEMBER = "December";

        #endregion

        #region Payroll Calculations, Taxes and NIC

        public const int WEEKS_IN_CONSIDERATION = 4;

        public const string TAX_CODE_2019_20 = "1250L";

        // UK Tax slabs 2019-20
        /*
            Tax Rate(Band)      Taxable Income      Tax Rate
            Personal allowance  Up to £12,500	    0%
            Basic rate	        £12,501 to £50,000	20%
            Higher rate	        £50,001 to £150,000	40%
            Additional rate     Over £150,000	    45%
        */
        // UK Tax slabs 2019-20 Monthly Calculated Values 
        public const double TAX_FREE_MONTHLY_INCOME_UPPER_LIMIT = 1041.67;
        public const double TAX_BASIC_MONTHLY_INCOME_UPPER_LIMIT = 4166.67;
        public const double TAX_RATE_BASIC_MONTHLY_INCOME_UPPER_LIMIT = 0.20;
        public const double TAX_HIGHER_MONTHLY_INCOME_UPPER_LIMIT = 12500;
        public const double TAX_RATE_HIGHER_MONTHLY_INCOME_UPPER_LIMIT = 0.40;
        public const double TAX_RATE_ADDITIONAL_INCOME_UPPER_LIMIT = 0.45;

        // UK NIC 2019-20        
        /*£ per week	            2019 to 2020
        Primary Threshold(PT)       £166
        Upper Earnings Limit        £962
        */
        // UK NIC 2019-20 Monthly Calculated Values
        public const double NIC_PRIMARY_THRESHOLD = 664;
        public const double NI_RATE_AFTER_PRIMARY_THRESHOLD = 0.12;
        public const double NIC_PRIMARY_UPPER_EARNING_LIMIT = 4166.67;
        public const double NI_RATE_AFTER_PRIMARY_UPPER_EARNING_LIMIT = 0.02;
        public const double NIC_RATE = 0.20;

        // Hourly rate
        public const string HOURLY_RATE_INITIAL_VALUE_STRING_DOUBLE_DECIMAL = "10.00";

        // Rate for overtime
        public const double OVERTIME_RATE_MULTIPLIER = 1.5;
        public readonly string OVERTIME_RATE_VALUE_STRING_DOUBLE_DECIMAL = (OVERTIME_RATE_MULTIPLIER * Convert.ToDouble(HOURLY_RATE_INITIAL_VALUE_STRING_DOUBLE_DECIMAL)).ToString("0.00");

        // Specified Contractual weekly hours
        public const int WEEKLY_CONTRACTUAL_HOURS = 36;

        // Voluntary Deductions
        public const double VOLUNTARY_DEDUCTION_UNION = 10;
        public const double VOLUNTARY_DEDUCTION_SLC_RATE = .05;

        #endregion 

        #region Regex Pattern

        // EmployeeID: 
        // 0-9 any number and length should be between 3, 4 characters
        public const string REGEX_PATTERN_EMPLOYEE_ID = "^[0-9]{3,4}$";

        // Employee Name(First Name or Last Name): 
        // First Character has to be capital A-Z
        // Second or more characters can be small or capital
        public const string REGEX_PATTERN_EMPLOYEE_FIRST_LAST_NAME = "^[A-Z][a-zA-Z]*$";

        // UK NINO Format:
        // Must be 9 characters only
        // First 2 characters must be letters
        // Next 6 characters must be numeric digits
        // Final character can only be A, B, C, D or space (\s escape sequence)
        // First character set must not be D, F, I, Q, U or V
        // Second character must not be D, F, I, O, Q, U or V
        // Ex. NINO Format: SB123456C
        public const string REGEX_PATTERN_EMPLOYEE_NINO = @"^[A-CEGHJ-PR-TW-Z]{1}[A-CEGHJ-NPR-TW-Z]{1}[0-9]{6}[A-D\s]$";

        // Email Id
        // abc21@domain.com
        public const string REGEX_PATTERN_EMPLOYEE_EMAIL_ADDRESS= @"^[A-Za-z0-9]{1,30}@[A-Za-z0-9]{1,30}.[a-zA-Z]{2,3}$";

        // Password
        public const string REGEX_PATTERN_USER_PASSWORD = @"^[A-Z]{1}*";

        #endregion

        #region Payroll Print configurations

        // Title or Heading Config
        public const string COMPANY_TITLE = "Payroll Application Demo Inc.";
        public const string TITLE_FONT = "Arial";
        public const int TITLE_FONT_SIZE = 24;
        public readonly Brush TITLE_FONT_COLOUR = Brushes.LightBlue;
        public const FontStyle TITLE_FONT_STYLE = FontStyle.Bold;

        // Content Font color and Style
        public const string CONTENT_FONT = "Times New Roman";
        public const int CONTENT_FONT_SIZE = 12;
        public const int CONTENT_HEADINGS_FONT_SIZE = 14;
        public const FontStyle CONTENT_HEADINGS_FONT_STYLE = FontStyle.Bold;
        public readonly Brush CONTENT_FONT_COLOUR = Brushes.Black;

        // Pay date
        public const string PAY_DATE = "Pay Date: ";

        // Employee Details Section
        public const string EMPLOYEE_ID = "Employee ID: ";
        public const string EMPLOYEE_NAME = "Name: ";
        public const string EMPLOYEE_NINO = "NINO: ";

        // Salary Details Section
        public const string HEADING_EARNINGS = "EARNINGS";
        public const string HEADING_HOURS = "HOURS";
        public const string HEADING_RATES = "RATES";
        public const string HEADING_AMOUNTS = "AMOUNTS";
        public const string HEADING_DEDUCTIONS = "DEDUCTIONS";

        public const string SUB_HEADING_BASIC = "Basic";
        public const string SUB_HEADING_OVERTIME = "Overtime";
        public const string SUB_HEADING_TAX_CODE = "Tax(" + TAX_CODE_2019_20+ ")";
        public const string SUB_HEADING_NIC = "NIC";
        public const string SUB_HEADING_UNION = "Union";
        public const string SUB_HEADING_SLC = "SLC";
        public const string SUB_HEADING_TOTAL_EARNINGS = "TotalEarnings";
        public const string SUB_HEADING_TOTAL_DEDUCTIONS = "TotalDeductions";

        public const string HEADING_NETPAY = "NET PAY";
        #endregion

        public const string CONNECTION_STRING = "PayrollSystemDBConnectionString";
    }
}
