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
        private static frmPainting _PaintingDialog;

        public float Width
        {
            get
            {
                return _Width;
            }

            set
            {
                _Width = value;
            }
        }

        public float Height
        {
            get
            {
                return _Height;
            }

            set
            {
                _Height = value;
            }
        }

        public string Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }

        public override void EditDetails()
        {
            //if (_PaintingDialog == null)
            //{
            //    _PaintingDialog = new frmPainting();
            //}
            //_PaintingDialog.SetDetails(_Name, _Date, _Value, _Width, _Height, _Type);
            //if (_PaintingDialog.ShowDialog() == DialogResult.OK)
            //{
            //    _PaintingDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Width, ref _Height, ref _Type);
            //}
        }
    }
}
