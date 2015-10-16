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
            _poseManager.AddWindow(window);
            return window;
        }

        //回傳所有已加入的軟體
        public BindingList<Window> GetWindowList()
        {
            return _poseManager.GetWindowList();
        }
        
        //回傳軟體數量
        public int GetWindowLength()
        {
            return _poseManager.GetWindowLength();
        }
        
        //刪除操縱軟體
        public void RemoveWindow(Window window)
        {
            _poseManager.RemoveWindow(window);
            window.RemoveImage();
        }

        public Window GetWindowByIndex(int index)
        {
            return _poseManager.GetWindowByIndex(index);
        }

        public void LockMyo()
        {
            _myoController.LockMyo();
        }
    }
}
