using System;
using System.Windows.Forms;

namespace PayrollApplication
{
    public partial class CurrentMonthPayments : Form
    {
        public CurrentMonthPayments()
        {
            InitializeComponent();
        }

        private void CurrentMonthPayments_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PayrollSystemDBDataSet1.tblPayRecords' table. You can move, or remove it, as needed.
            this.tblPayRecordsTableAdapter.Fill(this.PayrollSystemDBDataSet1.tblPayRecords);

            this.reportViewer1.RefreshReport();
        }
    }
}
