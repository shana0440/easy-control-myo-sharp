using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easy_control_c_sharp.Backend
{
    public class PoseManager
    {
        private Dictionary<string, List<PoseCombination>> _poseMap = new Dictionary<string, List<PoseCombination>>();
        private List<PoseCombination> _filter = new List<PoseCombination>();
        private string _globalPoseString = "globalPose";
        private string _onSystemString = "onSystem";
        private string _focusWindow;

        public void AddPoseCombination(string window, PoseCombination poseCombination)
        {
            if (_poseMap.ContainsKey(window))
            {
                // this window is exists
                _poseMap[window].Add(poseCombination);
            }
            else
            {
                // add new window
                _poseMap.Add(window, new List<PoseCombination>());
                _poseMap[window].Add(poseCombination);
            }
        }

        public void SetFocussWindow(string window)
        {
            _focusWindow = window;
        }

        public void FilterPose(string pose)
        {
            List<PoseCombination> poseCollection = GetFilterPoseCollection(_focusWindow);
            List<PoseCombination> afterFilterPoseCollection = new List<PoseCombination>();
            bool hasCompleted = false;
            foreach (PoseCombination item in poseCollection)
            {
                // make sure filter just have one completed pose combination
                if (item.ConformPose(pose) || (item.IsCompleted && !hasCompleted))
                {
                    if (item.IsCompleted && item.IsContiue)
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
            _filter.Clear();
        }

        private List<PoseCombination> GetPoseCollection(string window)
        {
            int index = -1;
            // auto load global pose
            List<PoseCombination> returnCollection;
            if (_poseMap.ContainsKey(_globalPoseString))
            {
                returnCollection = _poseMap[_globalPoseString];
            }
            else
            {
                returnCollection = new List<PoseCombination>();
            }
            foreach (KeyValuePair<string, List<PoseCombination>> collection in _poseMap)
            {
                index = window.IndexOf(collection.Key);
                if (index != -1)
                {
                    returnCollection.InsertRange(returnCollection.Count, collection.Value);
                    break;
                }
            }

            // 如果焦點視窗沒有在清單上，則假設他在系統上(執行系統上的手勢)
            if (index == -1)
            {
                if (_poseMap.ContainsKey(_onSystemString))
                {
                    returnCollection.InsertRange(returnCollection.Count, _poseMap[_onSystemString]);
                }
            }

            return returnCollection;
        }

        private List<PoseCombination> GetFilterPoseCollection(string window)
        {
            List<PoseCombination> poseCollection;
            if (_filter.Count > 0)
            {
                poseCollection = _filter;
            }
            else
            {
                poseCollection = GetPoseCollection(_focusWindow);
            }

            return poseCollection;
        }
    }
}
