using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDMine
{
    public partial class frmManageApplicationTypes: Form
    {
        private DataTable _dtAllApplicationTypes;

        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationTypes.GetAllApplicationTypes();
            DGVApplications.DataSource = _dtAllApplicationTypes;
            lblRecordsCount.Text = DGVApplications.Rows.Count.ToString();

            if(DGVApplications.Rows.Count>0)
            {
                DGVApplications.Columns[0].HeaderText = "ID";
                DGVApplications.Columns[0].Width = 110;

                DGVApplications.Columns[1].HeaderText = "Title";
                DGVApplications.Columns[1].Width = 400;

                DGVApplications.Columns[2].HeaderText = "Fees";
                DGVApplications.Columns[2].Width = 100;


            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationFees frm = new frmEditApplicationFees((int)DGVApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageApplicationTypes_Load(null, null);


        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
