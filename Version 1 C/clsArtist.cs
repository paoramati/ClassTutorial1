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

        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;

        private static frmArtist _ArtistDialog = new frmArtist();

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        public string Speciality
        {
            get
            {
                return _Speciality;
            }

            set
            {
                _Speciality = value;
            }
        }

        public string Phone
        {
            get
            {
                return _Phone;
            }

            set
            {
                _Phone = value;
            }
        }

        public decimal TotalValue
        {
            get
            {
                return _TotalValue;
            }

            //set
            //{
            //    _TotalValue = value;
            //}
        }

        public clsWorksList WorksList
        {
            get
            {
                return _WorksList;
            }

            //set
            //{
            //    _WorksList = value;
            //}
        }

        public clsArtistList ArtistList
        {
            get
            {
                return _ArtistList;
            }

            //set
            //{
            //    _ArtistList = value;
            //}
        }

        /* 
         * CHECK:What does Otto mean by member variables? Should that include the artistDialog 
         * and thus paintingDialog, etc. declarations into _paintingDialog, etc.?
         */

        //moved _SortOrder to clsWorksList

        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            EditDetails();
        }

        public void EditDetails()
        {
            _ArtistDialog.SetDetails(this);
            if (_ArtistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                _TotalValue = WorksList.GetTotalValue();
            }
        }

        //public void EditDetails()
        //{
        //    _ArtistDialog.SetDetails(Name, Speciality, Phone, WorksList, ArtistList);
        //    if (_ArtistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        _ArtistDialog.GetDetails(ref Name, ref Speciality, ref Phone);
        //        TotalValue = WorksList.GetTotalValue();
        //    }
        //}

        //Methods refactored by using Property calls instead
        //public string GetKey()
        //{
        //    return Name;
        //}

        //public decimal GetWorksValue()
        //{
        //    return TotalValue;
        //}
    }
}
