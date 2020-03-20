using System;
using System.Windows.Forms;

namespace PayrollApplication
{
    public partial class AllEmployeeDetails : Form
    {
        public AllEmployeeDetails()
        {
            InitializeComponent();
        }

        private void AllEmployeeDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PayrollSystemDBDataSet.tblEmployee' table. You can move, or remove it, as needed.
            this.tblEmployeeTableAdapter.Fill(this.PayrollSystemDBDataSet.tblEmployee);

            this.reportViewer1.RefreshReport();
        }
    }
}
