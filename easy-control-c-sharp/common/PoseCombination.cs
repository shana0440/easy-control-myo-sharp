using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // SendKey
using WindowsInput;

namespace easy_control_c_sharp
{
    public class PoseCombination
    {
        private List<string> _poseCombination = new List<string>();
        private List<Key> _keys = new List<Key>();
        private bool _isComplete = false;
        private bool _enable = true;
        private bool _isContiue = false;
        private int _index = 0;
        private Bitmap _image;
        public enum States { Press, Hold, Release }
        private string[] _startPose = new string[] { "fingersSpread", "waveOut", "waveIn", "fist" };

        /**
         * 加入手勢
         */
        public void TogglePose(string pose)
        {
            if (IsPoseExist(pose))
            {
                RemovePose(pose);
            }
            else
            {
                AddPose(pose);
            }
        }

        public void AddPose(string pose)
        {
            if (_startPose.Contains(pose))
                _poseCombination.Insert(StartPoseLastIndex(), pose);
            else
                _poseCombination.Add(pose);
        }

        //取得_poses裡手勢(不包含手臂)最後的位置
        private int StartPoseLastIndex()
        {
            for (int i = 0; i < _poseCombination.Count; i++)
            {
                if (!_startPose.Contains(_poseCombination[i]))
                    return i;
                if (i == _poseCombination.Count - 1)
                    return _poseCombination.Count;
            }
            return 0;
        }

        public void RemovePose(string pose)
        {
            _poseCombination.Remove(pose);
        }

        public void RemovePose(int index)
        {
            _poseCombination.RemoveAt(index);
        }

        public bool IsPoseExist(string pose)
        {
            return _poseCombination.Exists(item => item == pose);
        }

        /**
         * 加入按鍵
         */
        public void ToggleKey(Key key)
        {
            if (IsKeyExist(key))
            {
                RemoveKey(key);
            }
            else
            {
                AddKey(key);
            }
        }

        public void AddKey(VirtualKeyCode key, KeyStates state)
        {
            _keys.Add(new Key(key, state));
        }

        public void AddKey(Key key)
        {
            _keys.Add(key);
        }

        public void RemoveKey(Key key)
        {
            for (int i = 0; i < _keys.Count; i++)
            {
                if (_keys[i].Code == key.Code)
                    _keys.RemoveAt(i);
            }
        }

        public bool IsKeyExist(Key key)
        {
            return _keys.Exists(item => item.Code == key.Code);
        }

        /**
         * 取得手勢配對圖片
         */
        public Bitmap GetImage
        {
            get { return _image; }
            set { _image = value; }
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
        public bool IsContinue
        {
            get { return _isContiue; }
            set { _isContiue = value; }
        }

        /**
         * 是否啟動此手勢配對
         */
        public bool IsEnable
        {
            get { return _enable; }
            set { _enable = value; }
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
                // 判斷手勢是否完成
                // 避免持續性手勢在已完成的情況下沒有判斷到
                _isComplete = CheckIsCompleted();
            }
            else if (IsReadyContiuePose())
            {
                // 連貫性的手勢，可能是最後一個手勢尚未符合或已經符合
                // 符合以上條件就須留在filter中
                // 將_index固定在最後一個手勢，針對最後一個手勢做判斷
                _index = _poseCombination.Count - 1;
                if (IsNewPose(pose))
                {
                    _index++;
                    _isComplete = CheckIsCompleted();
                }
                accord = true;
            }
            else if (accord = IsNewPose(pose))
            {
                _index++; // start with 0
                _isComplete = CheckIsCompleted();
            }
            else
            {
                
            }
            return accord;
        }

        private bool CheckIsCompleted()
        {
            return _index >= _poseCombination.Count;
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
                if (pose.ToLower() == _poseCombination[_index].ToLower())
                {
                    return true;
                }
                // 沒有符合的手勢
                else
                {
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
                    case KeyStates.Hold:
                        InputSimulator.SimulateKeyDown(code);
                        Console.WriteLine("Hold {0} key", code.ToString());
                        break;
                    default:
                        break;
                }
            }

            foreach (Key key in _keys)
            {
                KeyStates state = key.State;
                VirtualKeyCode code = key.Code;
                switch (state)
                {
                    case KeyStates.Press:
                    case KeyStates.Release:
                        InputSimulator.SimulateKeyUp(code);
                        Console.WriteLine("Release {0} key", code.ToString());
                        break;
                    default:
                        break;
                }
            }
        }

        //取得手勢
        public string GetPose(int index)
        {
            return _poseCombination[index];
        }

        //取得手勢
        public List<string> GetPoseList()
        {
            return _poseCombination;
        }

        //取得功能鍵
        public Key GetKey(int index)
        {
            return _keys[index];
        }

        //取得手勢數量
        public int GetPoseLength()
        {
            return _poseCombination.Count;
        }

        //取得功能鍵數量
        public int GetKeyLength()
        {
            return _keys.Count;
        }

        //檢查是否有手勢資料
        public bool CheckPose()
        {
            for (int i = 0; i < _poseCombination.Count; i++)
            {
                if (_startPose.Contains(_poseCombination[i]))
                    return true;
            }
            return false;
        }

        //檢查是否有按鍵資料
        public bool CheckKey()
        {
            if (_keys.Count > 0)
                return true;
            else
                return false;
        }

        public void Reset()
        {
            _isComplete = false;
            _index = 0;
        }
    }
}
