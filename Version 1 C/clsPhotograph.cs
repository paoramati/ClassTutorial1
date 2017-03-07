using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsPhotograph : clsWork
    {
        private float _Width;
        private float _Height;
        private string _Type;

        //edit details of photograph

        [NonSerialized()]
        private static frmSculpture sculptureDialog;

        public override void EditDetails()
        {
            if (sculptureDialog == null)
            {
                sculptureDialog = new frmSculpture();
            }
            sculptureDialog.SetDetails(_Name, theDate, theValue, _Width, _Height, _Type);
            if (sculptureDialog.ShowDialog() == DialogResult.OK)
            {
                sculptureDialog.GetDetails(ref _Name, ref theDate, ref theValue, ref _Width, ref _Height, ref _Type);
            }
        }
    }
}
