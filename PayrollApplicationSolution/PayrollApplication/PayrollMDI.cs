using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollApplication
{
    public partial class PayrollMDI : Form
    {
        // Initialize Form Instances to null
        EmployeeForm employeeForm = null;
        PayrollCalculator payroll = null;
        AboutPayrollSystem aboutPayroll = null;
        public PayrollMDI()
        {
            InitializeComponent();
        }

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
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void PayrollMDI_Load(object sender, EventArgs e)
        {
            // Set the background color of mdi client
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.MediumAquamarine;
        }
    }
}
