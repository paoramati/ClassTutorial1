using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtist
    {
        private string _Name;
        private string _Speciality;
        private string _Phone;
        
        private decimal _TotalValue;
        /* 
         * CHECK:What does Otto mean by member variables? Should that include the artistDialog 
         * and thus paintingDialog, etc. declarations into _paintingDialog, etc.?
         * CHECK: Update - as mentioned in the task, changing these values will stuff up with what is in the XML file gallery.xml
         * (where the data is being permanently stored), so the private and protected fields, like all in this class file, are being
         * kept to how they were, and not updated like the description.
         * Is that what Matthius wanted in the end?
         */
        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;
        
        private static frmArtist _ArtistDialog = new frmArtist();

        //moved _SortOrder to clsWorksList

        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            editDetails();
        }
        
        public void editDetails()
        {
            _ArtistDialog.SetDetails(_Name, _Speciality, _Phone, _WorksList, _ArtistList);
            if (_ArtistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _ArtistDialog.GetDetails(ref _Name, ref _Speciality, ref _Phone);
                _TotalValue = _WorksList.GetTotalValue();
            }
        }

        public string GetKey()
        {
            return _Name;
        }

        public decimal GetWorksValue()
        {
            return _TotalValue;
        }
    }
}
