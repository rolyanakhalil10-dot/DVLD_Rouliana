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

namespace DVLDMine
{
    public partial class ctrlPersonCardWithFilter22: UserControl
    {       
        // Define a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }


        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }


        public ctrlPersonCardWithFilter22()
        {
            InitializeComponent();
        }
        private int _PersonID = -1;

        public int PersonID
        {
            get { return personDetials1.PersonID; }
        }

        public clsPeople SelectedPersonInfo
        {
            get { return personDetials1.SelectedPersonInfo; }
        }

        public void LoadPersonInfo(int PersonID)
        {

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            FindNow();

        }

        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    personDetials1.LoadPersonInfo(int.Parse(txtFilterValue.Text));

                    break;

                case "National No.":
                    personDetials1.LoadPersonInfo(txtFilterValue.Text);
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnPersonSelected(personDetials1.PersonID);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();

        }

        private void ctrlPersonCardWithFilter22_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();

        }

        private void txtFilterValue_Validated(object sender, EventArgs e)
        {

        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {

            //if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtFilterValue, "This field is required!");
            //}
            //else
            //{
            //    //e.Cancel = false;
            //    errorProvider1.SetError(txtFilterValue, null);
            //}

            // Only validate when the field has lost focus and it's not being filled yet
            if (string.IsNullOrWhiteSpace(txtFilterValue.Text))
            {
                errorProvider1.SetError(txtFilterValue, "This field is required!");
                // Only cancel if this field is required *right now*
                // You might want to set a flag like "isSubmitting"
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddEditPerson frm1 = new AddEditPerson();
            frm1.DataBack += DataBackEvent; // Subscribe to the event
            frm1.ShowDialog();

        }
        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            personDetials1.LoadPersonInfo(PersonID);
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //// Check if the pressed key is Enter (character code 13)
            //if (e.KeyChar == (char)13)
            //{

            //    btnFind.PerformClick();
            //}

            ////this will allow only digits if person id is selected
            //if (cbFilterBy.Text == "Person ID")
            //    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == (char)Keys.Enter)
            {
                btnFind.PerformClick();
            }
            else if (cbFilterBy.Text == "Person ID")
            {
                // Allow only digits and control keys (e.g., backspace)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

        }
    }
}
