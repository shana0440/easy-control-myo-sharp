using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easy_control_c_sharp
{
    public class CutImageMethod
    {
        //切圖片，傳想切的圖片(sourceImage)，和想切的區塊(section)，回傳切割圖片
        public Bitmap CutImage(Bitmap sourceImage, Rectangle section)
        {
            Bitmap cutImage = new Bitmap(section.Width, section.Height);
            Graphics graphics = Graphics.FromImage(cutImage);
            graphics.DrawImage(sourceImage, 0, 0, section, GraphicsUnit.Pixel);
            return cutImage;
        }
    }
}
