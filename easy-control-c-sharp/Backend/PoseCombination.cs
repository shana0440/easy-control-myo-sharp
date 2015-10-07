using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // SendKey
using WindowsInput;

namespace easy_control_c_sharp.Backend
{
    public class PoseCombination
    {
        private List<string> _poseCombination = new List<string>();
        private List<Tuple<VirtualKeyCode, PoseCombination.States>> _keys = new List<Tuple<VirtualKeyCode, PoseCombination.States>>();
        private bool _isComplete = false;
        private bool _isContiue = false;
        private int _index = 0;
        public enum States { Press, Hold, Release }

        public void AddPose(string pose)
        {
            _poseCombination.Add(pose);
        }

        public void AddKey(VirtualKeyCode key, string state)
        {
            _keys.Add(new Tuple<VirtualKeyCode, PoseCombination.States>(key, state));
        }

        public bool IsCompleted
        {
            get { return _isComplete; }
            set { _isComplete = value; }
        }

        public bool IsContiue
        {
            get { return _isContiue; }
            set { _isContiue = value; }
        }

        public bool ConformPose(string pose)
        {
            bool accord = false;
            if (IsPreviousPose(pose))
            {
                accord = true;
            }
            else if (IsReadyContiuePose())
            {
                // 連貫性的手勢，可能是最後一個手勢尚未符合或已經符合
                // 符合以上條件就須留在filter中
                _index = _poseCombination.Count - 1;
                accord = true;
            }
            else
            {
                accord = IsNewPose(pose);
            }
            
            return accord;
        }

        private bool IsPreviousPose(string pose)
        {
            if (_index > 0)
            {
                // 跟上個手勢相同，可能傳入兩個相同手勢
                if (pose == _poseCombination[_index - 1])
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsNewPose(string pose)
        {
            // index在範圍內
            if (_index >= 0 && _index < _poseCombination.Count)
            {
                // 為新的手勢
                if (pose == _poseCombination[_index])
                {
                    _index++; // start with 0
                    if (_index >= _poseCombination.Count)
                    {
                        _isComplete = true;
                    }
                    return true;
                }
                // 沒有符合的手勢
                else
                {
                    //_index = 0;
                    return false;
                }
            }
            return false;
        }

        private bool IsReadyContiuePose()
        {
            // 連貫性的手勢，可能是最後一個手勢尚未符合或已經符合，符合以上條件就須留在filter中
            return _isContiue && _index >= _poseCombination.Count - 1;
        }

        public void DoAction()
        {
            foreach (Tuple<VirtualKeyCode, PoseCombination.States> item in _keys)
            {
                PoseCombination.States state = item.Item2;
                VirtualKeyCode key = item.Item1;
                switch (state)
                {
                    case States.Press:
                        InputSimulator.SimulateKeyPress(key);
                        break;
                    case States.Hold:
                        InputSimulator.SimulateKeyDown(key);
                        break;
                    case States.Release:
                        InputSimulator.SimulateKeyUp(key);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
