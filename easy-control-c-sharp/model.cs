using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace easy_control_c_sharp
{
    public class Model
    {
        private BindingList<Window> _modeList = new BindingList<Window>();
        private PoseManager _poseManager = new PoseManager();
        private MyoController _myoController;
        public Model()
        {
            _myoController = new MyoController(_poseManager);
        }

        // create a new mode, and adding mode list
        public Window AddMode(string name)
        {
            Window window = new Window(name);
            _modeList.Add(window);
            _poseManager.AddWindow(window);
            return window;
        }

        //回傳所有已加入的軟體
        public BindingList<Window> GetModeList()
        {
            return _modeList;
        }
        
        //回傳軟體數量
        public int GetModeLength()
        {
            return _modeList.Count;
        }
        
        //刪除操縱軟體
        public void RemoveMode(Window window)
        {
            _modeList.Remove(window);
        }

        public int GetModeIndex(Window window)
        {
            int index = -1;
            for (index = 0; index < _modeList.Count; index++)
            {
                if (_modeList[index] == window)
                {
                    break;
                }
            }
            return index;
        }

        public Window GetModeByIndex(int index)
        {
            return _modeList[index];
        }
    }
}
