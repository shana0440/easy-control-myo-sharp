using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // SendKey
using WindowsInput;

namespace easy_control_c_sharp.common
{
    public class PoseCombination
    {
        private List<string> _poseCombination = new List<string>();
        private List<Key> _keys = new List<Key>();
        private bool _isComplete = false;
        private bool _isContiue = false;
        private int _index = 0;
        public enum States { Press, Hold, Release }

        /**
         * 加入手勢
         */
        public void AddPose(string pose)
        {
            _poseCombination.Add(pose);
        }

        public void RemovePose(string pose)
        {
            _poseCombination.Remove(pose);
        }

        /**
         * 加入按鍵
         */
        public void AddKey(VirtualKeyCode key, KeyStates state)
        {
            _keys.Add(new Key(key, state));
        }

        public void RemoveKey(Key key)
        {
            _keys.Remove(key);
        }

        /**
         * 確認所有手勢是否都已經符合，代表使用者可能想執行這個動作
         */
        public bool IsCompleted
        {
            get { return _isComplete; }
            set { _isComplete = value; }
        }

        /**
         * 這個手勢是否為持續性的功能
         */
        public bool IsContiue
        {
            get { return _isContiue; }
            set { _isContiue = value; }
        }

        /**
         * 確認這個手勢組合是否有符合傳入的手勢
         */
        public bool IsConformPose(string pose)
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
                IsNewPose(pose);
                accord = true;
            }
            else
            {
                accord = IsNewPose(pose);
            }
            
            return accord;
        }

        /**
         * 確認手勢跟上一個手勢相同，可能發生傳入兩個相同手勢的情況
         */
        private bool IsPreviousPose(string pose)
        {
            if (_index > 0)
            {
                if (pose == _poseCombination[_index - 1])
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * 確認傳入的手勢是否符合新的手勢
         */
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

        /**
         * 確認此手勢組合是否要一直執行功能，且已完成除了最後一個手勢以外的所有手勢，或全部都完成了
         */
        private bool IsReadyContiuePose()
        {
            // 連貫性的手勢，可能是最後一個手勢尚未符合或已經符合，符合以上條件就須留在filter中
            return _isContiue && _index >= _poseCombination.Count - 1;
        }

        /**
         * 執行功能
         */
        public void DoAction()
        {
            foreach (Key key in _keys)
            { 
                KeyStates state = key.State;
                VirtualKeyCode code = key.Code;
                switch (state)
                {
                    case KeyStates.Press:
                        InputSimulator.SimulateKeyPress(code);
                        break;
                    case KeyStates.Hold:
                        InputSimulator.SimulateKeyDown(code);
                        break;
                    case KeyStates.Release:
                        InputSimulator.SimulateKeyUp(code);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
