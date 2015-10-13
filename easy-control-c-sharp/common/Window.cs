using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easy_control_c_sharp.common
{
    public class Window
    {
        private List<PoseCombination> _poseCollection = new List<PoseCombination>();
        private string _name;

        public Window(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void AddPoseCombination(PoseCombination poseCombination)
        {
            _poseCollection.Add(poseCombination);
        }

        public void RemovePoseCombination(PoseCombination poseCombination)
        {
            _poseCollection.Remove(poseCombination);
        }

        public List<PoseCombination> GetPoseCollection()
        {
            return _poseCollection;
        }

        public List<PoseCombination> GetEnablePoseCollection()
        {
            return _poseCollection.FindAll(item => item.IsEnable);
        }
    }
}
