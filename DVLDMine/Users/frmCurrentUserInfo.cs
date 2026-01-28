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
    public partial class frmCurrentUserInfo: Form
    {
        private int _UserID;


        public frmCurrentUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void frmCurrentUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserCardContrl1.LoadUserInfo(_UserID);
        }

        private void btnClsoe_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
