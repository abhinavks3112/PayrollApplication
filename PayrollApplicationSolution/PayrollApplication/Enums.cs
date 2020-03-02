using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication
{
    public class Enums
    {
        public enum TextBoxEntryCheck
        {
            CHECK_IF_ANY_TEXT_ENTERED = 0,
            CHECK_IF_ANY_NUMBER_ENTERED = 1
        }

        public enum FieldsToValidateForRegex
        {
            EMPLOYEE_ID = 0,
            EMPLOYEE_FIRST_LAST_NAME = 1,
            EMPLOYEE_NINO = 2,
            EMPLOYEE_EMAIL_ADDRESS
        }
    }
}
