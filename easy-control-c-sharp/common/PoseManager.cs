using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace easy_control_c_sharp
{
    public class PoseManager
    {
        private BindingList<Window> _windowList = new BindingList<Window>();
        private List<PoseCombination> _filter = new List<PoseCombination>();
        private string _globalPoseString = "globalPose";
        private string _onSystemString = "onSystem";
        private Window _focusWindow;

        /**
         * 加入手勢組合
         */
        public void AddWindow(Window window)
        {
            _windowList.Add(window);
        }

        public void SetFocusWindow(string name)
        {
            _focusWindow = _windowList.FirstOrDefault(item => name.ToLower().IndexOf(item.Name.ToLower()) != -1);
        }

        /**
         * 將沒有符合的手勢組合清除，只留下有符合的手勢組合
         */
        public void FilterPose(string pose)
        {
            List<PoseCombination> poseCollection = GetFilterPoseCollection(_focusWindow);
            List<PoseCombination> afterFilterPoseCollection = new List<PoseCombination>();
            bool hasCompleted = false;
            foreach (PoseCombination item in poseCollection)
            {
                // make sure filter just have one completed pose combination
                if (item.IsConformPose(pose) || (item.IsCompleted && !hasCompleted))
                {
                    if (item.IsCompleted && item.IsContinue)
                    {
                        item.DoAction();
                        item.IsCompleted = false;
                    }
                    afterFilterPoseCollection.Add(item);
                }
                if (item.IsCompleted)
                {
                    hasCompleted = true;
                }
            }
            _filter = afterFilterPoseCollection;
        }

        /**
         * 接收結束時，執行已完成的手勢組合的功能
         */
        public void ReceiveOver()
        {
            bool actionDown = false;
            foreach (PoseCombination item in _filter)
            {
                if (item.IsCompleted)
                {
                    item.DoAction();
                    actionDown = true;
                    break;
                }
            }
            if (!actionDown)
            {
                Console.WriteLine("No pose combination conform!");
            }
            foreach (PoseCombination item in _filter)
            {
                item.Reset();
            }
            _filter.Clear();
        }
        
        /**
         * 取得篩選過後的手勢組合，如果清單中為空的，則取得該視窗下的所有手勢組合
         */
        private List<PoseCombination> GetFilterPoseCollection(Window window)
        {
            List<PoseCombination> poseCollection;
            if (_filter.Count > 0)
            {
                poseCollection = _filter;
            }
            else
            {
                try
                {
                    poseCollection = window.GetPoseCollectionList();
                }
                catch (Exception)
                {
                    poseCollection = new List<PoseCombination>();
                    //throw new Exception("this window is not defined on list");
                }
            }

            return poseCollection;
        }
    }
}
