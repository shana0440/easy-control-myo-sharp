using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace easy_control_c_sharp
{
    public partial class PresentationModel
    {
        public string ProcessOpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "讀取圖片";
            dialog.Filter = "Image files (*.*)|*.jpg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return "";
        }
    }
}
