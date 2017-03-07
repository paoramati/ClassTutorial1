using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtist
    {
        private string name;
        private string speciality;
        private string phone;
        
        private decimal theTotalValue;
        /* 
         * CHECK:What does Otto mean by member variables? Should that include the artistDialog 
         * and thus paintingDialog, etc. declarations into _paintingDialog, etc.?
         * CHECK: Update - as mentioned in the task, changing these values will stuff up with what is in the XML file gallery.xml
         * (where the data is being permanently stored), so the private and protected fields, like all in this class file, are being
         * kept to how they were, and not updated like the description.
         * Is that what Matthius wanted in the end?
         */
        private clsWorksList theWorksList;
        private clsArtistList theArtistList;
        
        private static frmArtist artistDialog = new frmArtist();
        private byte sortOrder;

        public clsArtist(clsArtistList prArtistList)
        {
            theWorksList = new clsWorksList();
            theArtistList = prArtistList;
            EditDetails();
        }
        
        public void EditDetails()
        {
            artistDialog.SetDetails(name, speciality, phone, sortOrder, theWorksList, theArtistList);
            if (artistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                artistDialog.GetDetails(ref name, ref speciality, ref phone, ref sortOrder);
                theTotalValue = theWorksList.GetTotalValue();
            }
        }

        public string GetKey()
        {
            return name;
        }

        public decimal GetWorksValue()
        {
            return theTotalValue;
        }
    }
}
