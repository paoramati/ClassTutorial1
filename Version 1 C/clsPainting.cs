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
        private static frmPainting _PaintDialog;

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
            //if (_PaintDialog == null)
            //{
            //    _PaintDialog = new frmPainting();
            //}
            //_PaintDialog.SetDetails(_Name, _Date, _Value, _Width, _Height, _Type);
            //if (_PaintDialog.ShowDialog() == DialogResult.OK)
            //{
            //    _PaintDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Width, ref _Height, ref _Type);
            //}
        }
    }
}
