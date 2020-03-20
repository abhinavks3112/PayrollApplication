using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PayrollApplication
{
    public partial class PayrollMDI : Form
    {
        #region Global Variables

        // Initialize Form Instances to null
        EmployeeForm employeeForm = null;
        PayrollCalculator payroll = null;
        AboutPayrollSystem aboutPayroll = null;
        AllEmployeeDetails allEmployee = null;
        AllPayments allPayments = null;
        CurrentMonthPayments monthPayments = null;
        Register register = null;
        #endregion
        public PayrollMDI()
        {
            InitializeComponent();
        }

        #region User Defined Functions

        private void ShowEmployeeForm()
        {
            // If instance is null then create new form instance
            if (employeeForm == null)
            {
                employeeForm = new EmployeeForm();
                employeeForm.MdiParent = this;
                employeeForm.FormClosed += EmployeeForm_FormClosed; // Call this method on form close event
                employeeForm.Show(); // Method 1 to Invoke form
            }
            else
            {
                // If instance is already present, activate it and give it focus
                employeeForm.Activate();
            }
        }

        // Set form instance to null on form close
        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            employeeForm = null;
        }

        private void ShowPayrollCalculatorForm()
        {
            // Generate new instance if its not present already otherwise activate the already present instance so as to avoid generating multiple instances
            if (payroll == null)
            {
                payroll = new PayrollCalculator();
                payroll.MdiParent = this;
                payroll.FormClosed += Payroll_FormClosed; // If not specified, then form instance does not become null
                payroll.Visible = true;// Method 2 to Invoke form
            }
            else
            {
                // If instance is already present, activate it and give it focus
                payroll.Activate();
            }
        }

        // Set form instance to null on form close
        private void Payroll_FormClosed(object sender, FormClosedEventArgs e)
        {
            payroll = null;
        }

        private void ShowAboutPayrollForm()
        {
            if (aboutPayroll == null)
            {
                aboutPayroll = new AboutPayrollSystem();
                aboutPayroll.FormClosed += AboutPayroll_FormClosed;// Call this method after form is closed
                aboutPayroll.MdiParent = this;
                aboutPayroll.Show();
            }
            else
            {
                // If instance is already present, activate it and give it focus
                aboutPayroll.Activate();
            }
        }

        // Set form instance to null on form close
        private void AboutPayroll_FormClosed(object sender, FormClosedEventArgs e)
        {
            aboutPayroll = null;
        }

        private void ShowReportAllEmployee()
        {
            if (allEmployee == null)
            {
                allEmployee = new AllEmployeeDetails();
                allEmployee.MdiParent = this;
                allEmployee.FormClosed += AllEmployee_FormClosed;
                allEmployee.Show();
            }
            else
            {
                allEmployee.Activate();
            }
        }
        // Set form instance to null on form close
        private void AllEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            allEmployee = null;
        }
        private void ShowReportAllPayments()
        {
            if (allPayments == null)
            {
                allPayments = new AllPayments();
                allPayments.MdiParent = this;
                allPayments.FormClosed += AllPayments_FormClosed;
                allPayments.Show();
            }
            else
            {
                allPayments.Activate();
            }
        }

        // Set form instance to null on form close
        private void AllPayments_FormClosed(object sender, FormClosedEventArgs e)
        {
            allPayments = null;
        }

        private void ShowReportAllCurrentMonthPayments()
        {
            if (monthPayments == null)
            {
                monthPayments = new CurrentMonthPayments();
                monthPayments.MdiParent = this;
                monthPayments.FormClosed += MonthPayments_FormClosed;
                monthPayments.Show();
            }
            else
            {
                monthPayments.Activate();
            }
        }

        // Set form instance to null on form close
        private void MonthPayments_FormClosed(object sender, FormClosedEventArgs e)
        {
            monthPayments = null;
        }

        private void RegisterUser()
        {
            if (register == null)
            {
                register = new Register();
                register.MdiParent = this;
                register.FormClosed += Register_FormClosed;
                register.Show();
            }
            else
            {
                monthPayments.Activate();
            }
        }
        // Set form instance to null on form close
        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            register = null;
        }

        #endregion

        private void manageEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEmployeeForm();
        }

        private void payrollCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPayrollCalculatorForm();
        }

        private void aboutPayrollApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutPayrollForm();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void manageEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEmployeeForm();
        }

        private void payrollCalculatorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowPayrollCalculatorForm();
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Setting Layout
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Setting Layout
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Setting Layout
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Setting Layout
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void PayrollMDI_Load(object sender, EventArgs e)
        {
            // Set the background color of mdi client
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.MediumAquamarine;
        }

        private void allEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReportAllEmployee();
        }

        private void allCurrentMonthPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReportAllCurrentMonthPayments();
        }

        private void allPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReportAllPayments();
        }

        private void registerUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }

        private void PayrollMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(Constants.MSG_APPLICATION_EXIT_CONFIRM_QUESTION, Constants.MSG_FORM_CLOSING, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (result == DialogResult.Yes)
            {
                e.Cancel = false;
                LogIn logIn = new LogIn();
                logIn.Show();
            }
        }
    }
}
