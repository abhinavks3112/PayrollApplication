using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
    }
}
