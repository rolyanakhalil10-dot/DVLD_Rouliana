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
    public partial class frmShowInternationalLicenseInfo: Form
    {
        private int _InternationalLicenseID;

        public frmShowInternationalLicenseInfo(int InternationalLIcenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLIcenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverInternationalLicenseInfo1.LoadInfo(_InternationalLicenseID);
        }
    }
}
