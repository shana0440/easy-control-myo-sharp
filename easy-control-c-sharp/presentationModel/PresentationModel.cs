using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace easy_control_c_sharp
{
    public partial class PresentationModel
    {
        Model _model;
        private Dictionary<string, Image> _imageList = new Dictionary<string, Image>();

        public PresentationModel(Model model)
        {
            _model = model;
            List<Tuple<string, string>> imageList = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("fingersSpread", "Image/fingersSpread.png"),
                new Tuple<string, string>("waveOut", "Image/waveOut.png"),
                new Tuple<string, string>("waveIn", "Image/waveIn.png"),
                new Tuple<string, string>("fist", "Image/fist.png"),
                new Tuple<string, string>("rightArrow", "Image/rightArrow.png"),
                new Tuple<string, string>("downArrow", "Image/downArrow.png"),
                new Tuple<string, string>("keyboard", "Image/keyboard.png"),
            };

            foreach (Tuple<string, string> item in imageList)
            {
                AddImage(item.Item1, Image.FromFile(item.Item2));
            }

            Bitmap source = new Bitmap("Image/arm-device.png");
            List<Tuple<string, Rectangle>> sectionList = new List<Tuple<string, Rectangle>>
            {
                new Tuple<string, Rectangle>("rollUp", new Rectangle(0, 0, 230, 230)),
                new Tuple<string, Rectangle>("rollDown", new Rectangle(182, 0, 230, 230)),
                new Tuple<string, Rectangle>("pitchUp", new Rectangle(0, 182, 230, 230)),
                new Tuple<string, Rectangle>("pitchDown", new Rectangle(180, 180, 230, 230)),
                new Tuple<string, Rectangle>("yawUp", new Rectangle(0, 360, 230, 230)),
                new Tuple<string, Rectangle>("yawDown", new Rectangle(182, 360, 230, 230)),
            };

            foreach (Tuple<string, Rectangle> item in sectionList)
            {
                CutImage(item.Item1, source, item.Item2);
            }
        }

        // Image method
        private bool AddImage(string name, Image path)
        {
            if (!IsImageExist(name))
            {
                _imageList.Add(name, path);
            }
            return !IsImageExist(name);
        }

        // Cut Image method
        private bool CutImage(string name, Bitmap source, Rectangle section)
        {
            if (!IsImageExist(name))
            {
                Bitmap bmp = new Bitmap(section.Width, section.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
                _imageList.Add(name, bmp);
            }
            return !IsImageExist(name);
        }

        //取得UI圖片，可重設大小
        public Bitmap GetImage(string imageName, int width, int height)
        {
            Bitmap UIBitmap = new Bitmap(_imageList[imageName], width, height);
            return UIBitmap;
        }

        public void RemoveImage(string name)
        {
            _imageList.Remove(name);
        }

        //檢查是否有某圖片存在
        public bool IsImageExist(string name)
        {
            return _imageList.ContainsKey(name);
        }
    }
}
