namespace PayrollApplication
{
    public class Enums
    {
        public enum TextBoxEntryCheck
        {
            CHECK_IF_ANY_TEXT_ENTERED,
            CHECK_IF_ANY_NUMBER_ENTERED
        }

        public enum FieldsToValidateForRegex
        {
            EMPLOYEE_ID,
            EMPLOYEE_FIRST_LAST_NAME,
            EMPLOYEE_NINO,
            EMPLOYEE_EMAIL_ADDRESS
        }

        public enum DataOperationMode
        {
            INSERT,
            UPDATE,
            DELETE
        }
    }
}
