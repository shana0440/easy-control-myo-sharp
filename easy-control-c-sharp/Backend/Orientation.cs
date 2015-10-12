using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easy_control_c_sharp.backend
{
    public class Orientation
    {
        private int _circleMax = 36;
        private int _bufferSize = 5;
        private Dictionary<string, List<int>> _buffer;
        private string _strRoll = "roll";
        private string _strPitch = "pitch";
        private string _strYaw = "yaw";

        public Orientation()
        {
            _buffer = new Dictionary<string, List<int>>();
            _buffer.Add(_strRoll, new List<int>());
            _buffer.Add(_strPitch, new List<int>());
            _buffer.Add(_strYaw, new List<int>());
        }

        public void PushQuat(double roll, double pitch, double yaw)
        {
            int[] quat = GetCircleQuat(roll, pitch, yaw);
            _buffer[_strRoll].Add(quat[0]);
            _buffer[_strPitch].Add(quat[1]);
            _buffer[_strYaw].Add(quat[2]);
        }

        private int[] GetCircleQuat(double roll, double pitch, double yaw)
        {
            const float PI = (float)System.Math.PI;
            // convert the values to a 0-n scale (for easier digestion/understanding)
            int intRoll = (int)((roll + PI) / (PI * 2.0f) * _circleMax);
            int intPitch = (int)((pitch + PI) / (PI * 2.0f) * _circleMax);
            int intYaw = (int)((yaw + PI) / (PI * 2.0f) * _circleMax);
            return new int[3] { intRoll, intPitch, intYaw };
        }

        public string GetArmDirection()
        {
            string dir = "";
            int[] quitOffset = GetQuatOffset();
            // 第一個if用來確定整buffer內，哪個資料的偏移量最大
            // 偏移量最大的則當作當下的動作
            if (quitOffset[0] > quitOffset[1] && quitOffset[0] > quitOffset[2])
            {
                if (_buffer[_strRoll][_bufferSize - 1] > _buffer[_strRoll][0])
                    dir = "rollUp";
                else
                    dir = "rollDown";
            }
            else if (quitOffset[1] > quitOffset[0] && quitOffset[1] > quitOffset[2])
            {
                if (_buffer[_strPitch][_bufferSize - 1] > _buffer[_strPitch][0])
                    dir = "pitchUp";
                else
                    dir = "pitchDown";
            }
            else if (quitOffset[2] > quitOffset[0] && quitOffset[2] > quitOffset[1])
            {
                if (_buffer[_strYaw][_bufferSize - 1] > _buffer[_strYaw][0])
                    dir = "yawUp";
                else
                    dir = "yawDown";
            }
            return dir;
        }

        private int[] GetQuatOffset()
        {
            int maxRoll = _buffer[_strRoll].Max();
            int maxPitch = _buffer[_strPitch].Max();
            int maxYaw = _buffer[_strYaw].Max();

            int minRoll = _buffer[_strRoll].Min();
            int minPitch = _buffer[_strPitch].Min();
            int minYaw = _buffer[_strYaw].Min();

            int rollOffset = maxRoll - minRoll;
            int pitchOffset = maxPitch - minPitch;
            int yawOffset = maxYaw - minYaw;
            return new int[3] { rollOffset, pitchOffset, yawOffset };
        }

        public void ClearBuffer()
        {
            _buffer[_strRoll].Clear();
            _buffer[_strPitch].Clear();
            _buffer[_strYaw].Clear();
        }

        public bool BufferFull
        {
            get { return _bufferSize == _buffer[_strRoll].Count; }
        }
    }
}
