using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace easy_control_UI
{
    public class Model
    {
        private BindingList<Mode> _modeList = new BindingList<Mode>();

        // create a new mode, and adding mode list
        public Mode AddMode(string name)
        {
            Mode mode = new Mode(name);
            _modeList.Add(mode);
            return mode;
        }

        //回傳所有已加入的軟體
        public BindingList<Mode> GetModeList()
        {
            return _modeList;
        }
        
        //回傳軟體數量
        public int GetModeLength()
        {
            return _modeList.Count;
        }
        
        //刪除操縱軟體
        public void RemoveMode(Mode mode)
        {
            _modeList.Remove(mode);
        }

        public int GetModeIndex(Mode mode)
        {
            int index = -1;
            for (index = 0; index < _modeList.Count; index++)
            {
                if (_modeList[index] == mode)
                {
                    break;
                }
            }
            return index;
        }

        public Mode GetModeByIndex(int index)
        {
            return _modeList[index];
        }
    }
}
