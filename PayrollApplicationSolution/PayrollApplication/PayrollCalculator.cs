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
    public partial class PayrollCalculator : Form
    {
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
    }
}
