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
    public partial class frmUsers: Form
    {
        private static DataTable _dtAllUsers;

        public frmUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUsers.GetAllUsers();
            DGVUsers.DataSource = _dtAllUsers;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = DGVUsers.Rows.Count.ToString();
            if (DGVUsers.Rows.Count > 0)
            {
                DGVUsers.Columns[0].HeaderText = "User ID";
                DGVUsers.Columns[0].Width = 110;

                DGVUsers.Columns[1].HeaderText = "Person ID";
                DGVUsers.Columns[1].Width = 120;

                DGVUsers.Columns[2].HeaderText = "Full Name";
                DGVUsers.Columns[2].Width = 350;

                DGVUsers.Columns[3].HeaderText = "UserName";
                DGVUsers.Columns[3].Width = 120;

                DGVUsers.Columns[4].HeaderText = "Is Active";
                DGVUsers.Columns[4].Width = 120;


            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)DGVUsers.CurrentRow.Cells[0].Value;
            if (clsUsers.DeleteUser(UserID))
            {
                MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Newmethod refreshing the dgv
                frmManageUsers_Load(null, null);
            }

            else
                MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCurrentUserInfo Frm1 = new frmCurrentUserInfo((int)DGVUsers.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmAddNewUser Frm1 = new frmAddNewUser((int)DGVUsers.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUser Frm1 = new frmAddNewUser((int)DGVUsers.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();
            frmManageUsers_Load(null, null);

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddNewUser Frm1 = new frmAddNewUser((int)DGVUsers.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();
            frmManageUsers_Load(null, null);

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)DGVUsers.CurrentRow.Cells[0].Value;
            frmChangePassword Frm1 = new frmChangePassword(UserID);
            Frm1.ShowDialog();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }

            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }


        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = DGVUsers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();

        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();


        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
