using System;
//using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }

        private clsWorksList _WorksList;
        private clsArtist _Artist;

        private void UpdateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (_WorksList.SortOrder == 0)
            {
                _WorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _WorksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _WorksList;
            lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());
        }

        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            UpdateForm();
            UpdateDisplay();
            ShowDialog();
        }
        
        private void UpdateForm()
        {
            txtName.Text = _Artist.Name;
            txtPhone.Text = _Artist.Phone;
            txtSpeciality.Text = _Artist.Speciality;
            _WorksList = _Artist.WorksList;
        }

        private void PushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Phone = txtPhone.Text;
            _Artist.Speciality = txtSpeciality.Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _WorksList.DeleteWork(lstWorks.SelectedIndex);
            UpdateDisplay();
        }   

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _WorksList.AddWork();
            UpdateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                PushData();
                DialogResult = DialogResult.OK;
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_Artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0)
            {
                _WorksList.EditWork(lcIndex);
                UpdateDisplay();
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

    }
}