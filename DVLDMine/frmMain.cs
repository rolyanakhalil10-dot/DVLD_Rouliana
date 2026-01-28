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
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;

        public frmMain(frmLogin Login)
        {
            InitializeComponent();
            _frmLogin = Login;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManagePeople();
            frm.ShowDialog();

        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        //Edit here
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUsers();
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCurrentUserInfo frm = new frmCurrentUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
            

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }

        private void drivingLicenceServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDLA AddUpdate = new frmAddUpdateLocalDLA();
            AddUpdate.Show();

        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDLA List = new frmListLocalDLA();
            List.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.Refresh();

        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddInternationalLicense Internatioanl = new frmAddInternationalLicense();
            Internatioanl.Show();
        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageIntLicense ManageInt = new frmManageIntLicense();
            ManageInt.Show();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicenseApplication frm = new frmRenewLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication frm = new frmReplaceLostOrDamagedLicenseApplication();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetianReleaseL DR = new frmDetianReleaseL();
            DR.Show();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense RL = new frmReleaseLicense();
            RL.Show();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses LDL = new frmListDetainedLicenses();
            LDL.Show();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense RL = new frmReleaseLicense();
            RL.Show();

        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDLA LL = new frmListLocalDLA();
            LL.Show();
        }

        private void manageApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localDrivingLicenseApplicaitonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDLA LL = new frmListLocalDLA();
            LL.Show();

        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrivers dri = new frmDrivers();
            dri.Show();
        }

        private void internationalLiceseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageIntLicense frm = new frmManageIntLicense();
            frm.ShowDialog();

        }
    }
}
