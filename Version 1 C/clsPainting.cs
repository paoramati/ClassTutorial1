using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsPainting : clsWork
    {
        //changed these variable names
        private float _Width;
        private float _Height;
        private string _Type;

        [NonSerialized()]
        private static frmPainting paintDialog;

        public override void EditDetails()
        {
            if (paintDialog == null)
            {
                paintDialog = new frmPainting();
            }
            paintDialog.SetDetails(_Name, theDate, theValue, _Width, _Height, _Type);
            if(paintDialog.ShowDialog() == DialogResult.OK)
            {
               paintDialog.GetDetails(ref _Name, ref theDate, ref theValue, ref _Width, ref _Height, ref _Type);
            }
        }
    }
}
