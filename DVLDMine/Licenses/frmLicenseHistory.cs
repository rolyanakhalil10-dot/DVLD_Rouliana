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
    public partial class frmLicenseHistory: Form
    {
        private int _PersonID = -1;

        public frmLicenseHistory()
        {
            InitializeComponent();
        }
        public frmLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {

            if (_PersonID != -1)
            {
                ctrlPersonCardWithFilter221.LoadPersonInfo(_PersonID);
                ctrlPersonCardWithFilter221.FilterEnabled = false;
                ctrlDriverLicense1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ctrlPersonCardWithFilter221.Enabled = true;
                ctrlPersonCardWithFilter221.FilterFocus();
            }


        }

        private void ctrlPersonCardWithFilter221_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            if (_PersonID == -1)
            {
                ctrlDriverLicense1.Clear();
            }
            else
                ctrlDriverLicense1.LoadInfoByPersonID(_PersonID);

        }
    }
}
