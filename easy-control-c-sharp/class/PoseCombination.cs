using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace easy_control_UI
{
    public class PoseCombination
    {
        private List<Pose> _poses = new List<Pose>();
        private List<Key> _keys = new List<Key>();
        private bool _isContinue = false;
        private bool _enable = true;
        private string[] _startPose = new string[] { "fingersSpread", "waveOut", "waveIn", "fist" };

        //加入手勢，假如有同一種手勢重覆加入，則刪除(這邊寫超爛的~"~)
        public void TogglePose(Pose pose)
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

        public void AddPose(Pose pose)
        {
            if (_startPose.Contains(pose.GetPoseName()))
                _poses.Insert(StartPoseLastIndex(), pose);
            else
                _poses.Add(pose);
        }

        //取得_poses裡手勢(不包含手臂)最後的位置
        private int StartPoseLastIndex()
        {
            for (int i = 0; i < _poses.Count; i++)
            {
                if (!_startPose.Contains(_poses[i].GetPoseName()))
                    return i;
                if (i == _poses.Count - 1)
                    return _poses.Count;
            }
            return 0;
        }

        public void RemovePose(Pose pose)
        {
            for (int i = 0; i < _poses.Count; i++)
            {
                if (_poses[i].GetPoseName() == pose.GetPoseName())
                    _poses.RemoveAt(i);
            }
        }

        public void RemovePoseByIndex(int index)
        {
            _poses.RemoveAt(index);
        }

        public bool IsPoseExist(Pose pose)
        {
            return _poses.Exists(item => item.GetPoseName() == pose.GetPoseName());
        }

        //加入功能鍵，假如有同一種功能鍵重覆加入，則刪除(這邊寫超爛的~"~)
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

        public void AddKey(Key key)
        {
            _keys.Add(key);
        }

        //移除功能鍵
        public void RemoveKey(Key key)
        {
            for (int i = 0; i < _keys.Count; i++)
            {
                if (_keys[i].GetKeyName() == key.GetKeyName())
                    _keys.RemoveAt(i);
            }
        }

        public bool IsKeyExist(Key key)
        {
            return _keys.Exists(item => item.GetKeyName() == key.GetKeyName());
        }

        //設定是否為持續性手勢
        public void SetIsContinue()
        {
            _isContinue = !_isContinue;
        }

        //取得是否為持續性手勢
        public bool GetIsContinue()
        {
            return _isContinue;
        }

        //檢查是否可以設定為持續性手勢
        public bool CheckIsContinue()
        {
            if (StartPoseLastIndex() != 0)
                return true;
            else
                return false;
        }

        //取得手勢
        public Pose GetPose(int index)
        {
            return _poses[index];
        }

        //取得功能鍵
        public Key GetKey(int index)
        {
            return _keys[index];
        }

        //取得手勢數量
        public int GetPoseLength()
        {
            return _poses.Count;
        }

        //取得功能鍵數量
        public int GetKeyLength()
        {
            return _keys.Count;
        }

        //檢查是否有手勢資料
        public bool CheckPose()
        {
            for (int i = 0; i < _poses.Count; i++)
            {
                if (_startPose.Contains(_poses[i].GetPoseName()))
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

        //清除手勢配對資料
        public void ClearPose()
        {
            _poses.Clear();
        }

        //清除按鍵資料
        public void ClearKey()
        {
            _keys.Clear();
        }

        public Bitmap GetImage
        {
            get
            {
                Bitmap canvas = new Bitmap(450, 75);
                Graphics g = Graphics.FromImage(canvas);
                g.Clear(SystemColors.Control);
                for (int i = 0; i < _poses.Count; i++)
                {
                    g.DrawImage(_poses[i].GetPoseImage(), i * 75, 0);
                }
                string keyString = _keys[0].GetKeyName();
                for (int i = 1; i < _keys.Count; i++)
                {
                    keyString += "+" + _keys[i].GetKeyName();
                }
                g.DrawString("➜", new Font("Arial", 40), Brushes.Black, _poses.Count * 75, 10);
                g.DrawString(keyString, new Font("Arial", 40), Brushes.DarkRed, (_poses.Count + 1) * 75, 8);
                return new Bitmap(canvas, 300, 50);
            }
        }

        //是否啟動此手勢配對
        public bool IsEnable
        {
            get { return _enable; }
            set { _enable = value; }
        }
    }
}
