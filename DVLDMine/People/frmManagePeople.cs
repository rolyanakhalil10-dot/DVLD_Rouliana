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
    public partial class frmManagePeople : Form
    {

        private static DataTable _dtAllPeople = clsPeople.GetAllPeople();

        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                         "FirstName", "SecondName", "ThirdName", "LastName",
                                                         "GendorCaption", "DateOfBirth", "CountryName",
                                                         "Phone", "Email");

        private void _RefreshPeoplList()
        {
            _dtAllPeople = clsPeople.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            DGVPeople.DataSource = _dtPeople;
            lblRecordsCount.Text = DGVPeople.Rows.Count.ToString();
        }

        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            DGVPeople.DataSource = _dtPeople;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = DGVPeople.Rows.Count.ToString();
            if (DGVPeople.Rows.Count > 0)
            {

                DGVPeople.Columns[0].HeaderText = "Person ID";
                DGVPeople.Columns[0].Width = 110;

                DGVPeople.Columns[1].HeaderText = "National No.";
                DGVPeople.Columns[1].Width = 120;


                DGVPeople.Columns[2].HeaderText = "First Name";
                DGVPeople.Columns[2].Width = 120;

                DGVPeople.Columns[3].HeaderText = "Second Name";
                DGVPeople.Columns[3].Width = 140;


                DGVPeople.Columns[4].HeaderText = "Third Name";
                DGVPeople.Columns[4].Width = 120;

                DGVPeople.Columns[5].HeaderText = "Last Name";
                DGVPeople.Columns[5].Width = 120;

                DGVPeople.Columns[6].HeaderText = "Gendor";
                DGVPeople.Columns[6].Width = 120;

                DGVPeople.Columns[7].HeaderText = "Date Of Birth";
                DGVPeople.Columns[7].Width = 140;

                DGVPeople.Columns[8].HeaderText = "Nationality";
                DGVPeople.Columns[8].Width = 120;


                DGVPeople.Columns[9].HeaderText = "Phone";
                DGVPeople.Columns[9].Width = 120;


                DGVPeople.Columns[10].HeaderText = "Email";
                DGVPeople.Columns[10].Width = 170;
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form frm1 = new AddEditPerson();
            frm1.ShowDialog();
            _RefreshPeoplList();

        }

        private void DGVPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new AddEditPerson();
            frm.ShowDialog();

            _RefreshPeoplList();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new AddEditPerson((int)DGVPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshPeoplList();
        }


        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = DGVPeople.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = DGVPeople.Rows.Count.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + DGVPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {
                if (clsPeople.DeletePerson((int)DGVPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeoplList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stay Tuned Hayatii...");
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stay Tuned يا معووووود...");

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)DGVPeople.CurrentRow.Cells[0].Value;
            Form frm = new frmShowDetails(PersonID);
            frm.ShowDialog();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
