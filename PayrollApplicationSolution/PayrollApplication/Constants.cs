using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication
{
    public class Constants
    {
        public const string MSG_DATA_ENTRY_ERROR = "DATA ENTRY ERROR!!";
        public const string MSG_INVALID_CHARACTERS_ERROR = "INVALID CHARACTERS ENTERED!!";
        public const string MSG_EMPTY_FIELD_ERROR = "FIELD IS EMPTY!!";
        public const string MSG_INVALID_DATA_FORMAT_ERROR = "INVALID DATA FORMAT!!";
        public const string MSG_NO_SELECTION_ERROR = "NO OPTION SELECTED!!";
        public const string MSG_ENTER_NUMBERS_ONLY = "PLEASE ENTER NUMBERS ONLY!!";
        public const string MSG_SELECT_GENDER = "PLEASE SELECT YOUR GENDER!!";
        public const string MSG_SELECT_MARITAL_STATUS = "PLEASE SELECT YOUR MARITAL STATUS!!";
        public const string MSG_SELECT_COUNTRY = "PLEASE SELECT YOUR COUNTRY FROM THE DROP DOWN LIST!!";
        public const string MSG_PLEASE_ENTER = "PLEASE ENTER ";
        public const string MSG_PLEASE_ENTER_VALID = "PLEASE ENTER VALID ";
        public const string MSG_ERROR = "ERROR: ";
        public const string MSG_EMPLOYEE_ADD_SUCCESS = "EMPLOYEE ADDED SUCCESSFULLY!!";
        public const string MSG_EMPLOYEE_UPDATE_SUCCESS = "EMPLOYEE UPDATED SUCCESSFULLY!!";

        public const int INDEX_ZERO = 0;
        public const int INDEX_MINUS_ONE_OR_DEFAULT_INDEX = -1;

        public const string GENDER_MALE = "Male";
        public const string GENDER_FEMALE = "Female";
        public const string MARITAL_STATUS_MARRIED = "Married";
        public const string MARITAL_STATUS_SINGLE = "Single";

        public const int NOTES_FIELD_SIZE_CONSTRAINT = 30;

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

    }
}
