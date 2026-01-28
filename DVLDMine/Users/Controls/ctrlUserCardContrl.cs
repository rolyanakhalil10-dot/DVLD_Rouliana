using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Microsoft.VisualBasic.ApplicationServices;

namespace DVLDMine
{
    public partial class ctrlUserCardContrl: UserControl
    {
        private clsUsers _User;
        private int _UserID = -1;

        public int UserID
        {
            get { return _UserID; }
        }

        public ctrlUserCardContrl()
        {
            InitializeComponent();
        }

        private void ctrlUserCardContrl_Load(object sender, EventArgs e)
        {
        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUsers.FindByUserID(UserID);
            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

        private void _FillUserInfo()
        {

            personDetials1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();

            if (_User.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";

        }

        private void _ResetUserInfo()
        {

            personDetials1.ResetPersonInfo();
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblIsActive.Text = "[???]";
        }




    }
}
