using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace easy_control_c_sharp
{
    public partial class PresentationModel
    {
        public void ProcessClickSaveButton(Window window, bool isEdit, string windowName, string windowImage)
        {
            if (isEdit)
                window.Name = windowName;
            else
                window = AddWindow(windowName);
            if (windowImage == "")
                window.SetImage("Image/Myo.png");
            else
                window.SetImage(windowImage);
        }

        public string ProcessOpenFile(string imagePath)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "讀取圖片";
            dialog.Filter = "Image files (*.*)|*.jpg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string[] fileName = dialog.FileName.Split('\\');
                string ownImagePath = "Image/" + fileName[fileName.Length - 1];
                if (!File.Exists(ownImagePath))
                    File.Copy(dialog.FileName, ownImagePath);
                return ownImagePath;
            }
            return imagePath;
        }

        public bool IsSaveButtonEnable(TextBox nameTextBox)
        {
            if (nameTextBox.Text.ToString() != "")
                return true;
            else
                return false;
        }
    }
}
