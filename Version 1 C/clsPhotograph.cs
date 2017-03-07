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
        private static frmPainting paintingDialog;

        public override void EditDetails()
        {
            if (paintingDialog == null)
            {
                paintingDialog = new frmPainting();
            }
            paintingDialog.SetDetails(_Name, theDate, theValue, _Width, _Height, _Type);
            if (paintingDialog.ShowDialog() == DialogResult.OK)
            {
                paintingDialog.GetDetails(ref _Name, ref theDate, ref theValue, ref _Width, ref _Height, ref _Type);
            }
        }
    }
}
