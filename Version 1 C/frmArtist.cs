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

        private clsArtistList _ArtistList;
        private clsWorksList _WorksList;
        private byte _SortOrder; // 0 = Name, 1 = Date

        private void UpdateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            //previously if (sortOrder == 0)
            //CHECK: using _WorksList.SortOrder in place?
            //UPDATE: this did not work
            //UPDATE2: giving frmArtist it's own _SortOrder field has worked. Not sure where the clsWorkList.SortOrder property is being used now...
            if (_SortOrder == 0)
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

        public void SetDetails(string prName, string prSpeciality, string prPhone, 
                               clsWorksList prWorksList, clsArtistList prArtistList)
        {
            txtName.Text = prName;
            txtSpeciality.Text = prSpeciality;
            txtPhone.Text = prPhone;
            _ArtistList = prArtistList;
            _WorksList = prWorksList;
            //_SortOrder = prSortOrder;
            _SortOrder = _WorksList.SortOrder;      //private var _SortOrder is being set by clsWorksList Property SortOrder
            UpdateDisplay();
        }

        public void GetDetails(ref string prName, ref string prSpeciality, ref string prPhone)
        {
            prName = txtName.Text;
            prSpeciality = txtSpeciality.Text;
            prPhone = txtPhone.Text;
            //prSortOrder = sortOrder;
            _SortOrder = _WorksList.SortOrder;      //private var _SortOrder is being retrieved from clsWorksList Property SortOrder
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
                DialogResult = DialogResult.OK;
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_ArtistList.Contains(txtName.Text))
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
            _SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

    }
}