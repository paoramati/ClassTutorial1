using System;
using System.Collections;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsArtistList : SortedList
    {
        private const string _FileName = "gallery.xml";
        public void EditArtist(string prKey)
        {
            clsArtist lcArtist;
            lcArtist = (clsArtist)this[prKey];
            if (lcArtist != null)
                lcArtist.editDetails();
            else
                MessageBox.Show("Sorry no artist by this name");
        }
        
        public void NewArtist()
        {
            clsArtist lcArtist = new clsArtist(this);
            try
            {
                if (lcArtist.GetKey() != "")
                {
                    Add(lcArtist.GetKey(), lcArtist);
                    MessageBox.Show("Artist added!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Duplicate Key!");
            }
        }

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsArtist lcArtist in Values)
            {
                lcTotal += lcArtist.GetWorksValue();
            }
            return lcTotal;
        }

        //Moved methods Save and Retrieve from main()

        public void Save()
        {
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create);
                System.Runtime.Serialization.Formatters.Soap.SoapFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();

                lcFormatter.Serialize(lcFileStream, this);
                lcFileStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "File Save Error");
            }
        }

        public static clsArtistList Retrieve()
        {
            clsArtistList lcArtistList;
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open);
                System.Runtime.Serialization.Formatters.Soap.SoapFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();

                lcArtistList = (clsArtistList)lcFormatter.Deserialize(lcFileStream);
                //UpdateDisplay();      no longer calling cause have "Factory Method"???
                lcFileStream.Close();
            }

            catch (Exception e)
            {
                lcArtistList = new clsArtistList();
                MessageBox.Show(e.Message, "File Retrieve Error");
            }
            return lcArtistList;
        }
    }
}
