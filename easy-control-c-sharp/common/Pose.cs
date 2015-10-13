using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace easy_control_c_sharp.common
{
    public class Pose
    {
        private string _poseName;
        private Bitmap _poseImage;
        public Pose(string poseName, Bitmap poseImage)
        {
            _poseName = poseName;
            _poseImage = poseImage;
        }

        //回傳手勢名稱
        public string GetPoseName()
        {
            return _poseName;
        }

        //回傳手勢圖片
        public Bitmap GetPoseImage()
        {
            return _poseImage;
        }
    }
}
