using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PayrollApplication.Enums;

namespace PayrollApplication
{
    public class CustomValidationsFunctions
    {
        readonly Colors color = new Colors();

        /// <summary>
        /// Shows messagebox and highlight control in case of validation error
        /// </summary>
        /// <param name="control"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        private void HighlightDataEntryErrorValidation(Control control, bool ShowError, string ErrorMessageBody, string ErrorMessageHeading)
        {
            if (ShowError)
            {
                MessageBox.Show(ErrorMessageBody, ErrorMessageHeading, MessageBoxButtons.OK, MessageBoxIcon.Error);
                control.Focus();
                control.BackColor = color.VALIDATION_ERROR;             
            }
            else
            {
                control.BackColor = color.NORMAL_COLOR;
            }            
        }

        /// <summary>
        /// Validate conditionally for text or number in specified control
        /// </summary>
        /// <param name="ControlsList"></param>
        /// <returns></returns>
        public bool IsFormControlNullOrEmptyValidation(Dictionary<Control, TextBoxEntryCheck> ControlsList)
        {
            Control control;
            bool areAllControlsValid = true;
            bool isControlValid;

            foreach (var FormControl in ControlsList)
            {
                control = (Control)FormControl.Key;
                switch (FormControl.Value)
                {
                    case TextBoxEntryCheck.CHECK_IF_ANY_TEXT_ENTERED:
                        if (string.IsNullOrEmpty(control.Text))
                            isControlValid = false;
                        else
                            isControlValid = true;
                        break;

                    case TextBoxEntryCheck.CHECK_IF_ANY_NUMBER_ENTERED:
                        if (Convert.ToInt32(control.Text.Length) < 1)
                        {
                            isControlValid = false;
                        }
                        else
                            isControlValid = true;
                        break;

                    default: return true;
                }
                
                // Highlight control with validation error, if any
                HighlightDataEntryErrorValidation(control, !isControlValid, Constants.MSG_PLEASE_ENTER + control.AccessibleName, Constants.MSG_EMPTY_FIELD_ERROR);

                // Form Validity
                areAllControlsValid = areAllControlsValid && isControlValid;

                if (areAllControlsValid == false)
                    return false;
                
            }
            return areAllControlsValid;
        }
        
        /// <summary>
        /// Validate form control so that it only accepts numbers or backspace
        /// </summary>
        /// <param name="control"></param>
        /// <param name="e"></param>
        public void IsNumberOrBackspaceValidation(Control control, KeyPressEventArgs e)
        {            
            // Check for either a number or backspace. Backspace checked using its ASCII value  
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                HighlightDataEntryErrorValidation(control, true, Constants.MSG_ENTER_NUMBERS_ONLY, Constants.MSG_INVALID_CHARACTERS_ERROR);
                
                e.Handled = true;
                return;
            }
            HighlightDataEntryErrorValidation(control, false, String.Empty, String.Empty);
        }
    
        /// <summary>
        /// Check employee form details against specific regular expression or patterns
        /// </summary>
        /// <param name="ControlsList"></param>
        /// <returns></returns>
        public bool IsEmployeeDetailValid(Dictionary<Control, FieldsToValidateForRegex> ControlsList)
        {
            Regex regex;
            Control control;
            bool areAllControlsValid = true;
            bool isControlValid;

            foreach (var FormControl in ControlsList)
            {
                control = (Control)FormControl.Key;
                switch (FormControl.Value)
                {
                    case FieldsToValidateForRegex.EMPLOYEE_ID:
                        regex = new Regex(Constants.REGEX_PATTERN_EMPLOYEE_ID);                        
                        break;

                    case FieldsToValidateForRegex.EMPLOYEE_FIRST_LAST_NAME:
                        regex = new Regex(Constants.REGEX_PATTERN_EMPLOYEE_FIRST_LAST_NAME);
                        break;

                    case FieldsToValidateForRegex.EMPLOYEE_NINO:
                        regex = new Regex(Constants.REGEX_PATTERN_EMPLOYEE_NINO);
                        break;

                    case FieldsToValidateForRegex.EMPLOYEE_EMAIL_ADDRESS:
                        regex = new Regex(Constants.REGEX_PATTERN_EMPLOYEE_EMAIL_ADDRESS);
                        try
                        {
                            MailAddress objMail = new MailAddress(control.Text);
                        }
                        catch (Exception ex)
                        {
                            isControlValid = false;
                            // Highlight control with validation error, if any
                            HighlightDataEntryErrorValidation(control, !isControlValid, Constants.MSG_ERROR + ex.Message, Constants.MSG_INVALID_DATA_FORMAT_ERROR);
                            return false;
                        }
                        break;

                    default: return true;
                }

                if (!regex.IsMatch(control.Text))
                    isControlValid = false;
                else
                    isControlValid = true;

                // Highlight control with validation error, if any
                HighlightDataEntryErrorValidation(control, !isControlValid, Constants.MSG_PLEASE_ENTER_VALID + control.AccessibleName, Constants.MSG_INVALID_DATA_FORMAT_ERROR);

                // Form Validity
                areAllControlsValid = areAllControlsValid && isControlValid;

                if (areAllControlsValid == false)
                    return false;

            }
            return areAllControlsValid;
        }
    
    }
}
