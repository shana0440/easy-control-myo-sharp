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
        private BindingList<Window> _windowList = new BindingList<Window>();
        private PoseManager _poseManager = new PoseManager();
        private MyoController _myoController;
        public Model()
        {
            _myoController = new MyoController(_poseManager);
        }

        // create a new mode, and adding mode list
        public Window AddWindow(string name)
        {
            Window window = new Window(name);
            _windowList.Add(window);
            _poseManager.AddWindow(window);
            return window;
        }

        //回傳所有已加入的軟體
        public BindingList<Window> GetWindowList()
        {
            return _windowList;
        }
        
        //回傳軟體數量
        public int GetWindowLength()
        {
            return _windowList.Count;
        }
        
        //刪除操縱軟體
        public void RemoveWindow(Window window)
        {
            _windowList.Remove(window);
        }

        public int GetWindowIndex(Window window)
        {
            int index = -1;
            for (index = 0; index < _windowList.Count; index++)
            {
                if (_windowList[index] == window)
                {
                    break;
                }
            }
            return index;
        }

        public Window GetWindowByIndex(int index)
        {
            return _windowList[index];
        }
    }
}
