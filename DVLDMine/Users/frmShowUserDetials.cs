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
    public partial class frmShowUserDetials: Form
    {
        //Show Details
        public delegate void ShowUserDetailsHandler();
        public event ShowUserDetailsHandler ShowDetials;

  
        public frmShowUserDetials()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void personDetials1_Load(object sender, EventArgs e)
        {

        }
    }
}
