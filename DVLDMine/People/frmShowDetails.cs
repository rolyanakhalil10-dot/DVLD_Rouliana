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
    public partial class frmShowDetails: Form
    {
        public delegate void ShowPersonDetailsHandler();
        public event ShowPersonDetailsHandler ShowDetials;


        public frmShowDetails(int PersonID)
        {
            InitializeComponent();
            personDetials1.LoadPersonInfo(PersonID);
        }
        public frmShowDetails(string NationalNo)
        {
            InitializeComponent();
            personDetials1.LoadPersonInfo(NationalNo);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmShowDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
