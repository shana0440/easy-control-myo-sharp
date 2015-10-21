using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace easy_control_c_sharp
{
    public class Window
    {
        private BindingList<PoseCombination> _poseCollection = new BindingList<PoseCombination>();
        private List<PoseCombination> _poseCollectionList = new List<PoseCombination>();
        private string _name;
        private bool _enable = true;
        private bool _open = false;
        private string _imagePath;

        public Window(string name)
        {
            _name = name;
        }

        public void AddPoseCombination(PoseCombination poseCombination)
        {
            _poseCollection.Add(poseCombination);
        }

        public void InsertPoseCombination(int index, PoseCombination poseCombination)
        {
            _poseCollection.Insert(index, poseCombination);
        }

        public void RemovePoseCombination(PoseCombination poseCombination)
        {
            _poseCollection.Remove(poseCombination);
        }

        public void RemovePoseCombinationByIndex(int index)
        {
            _poseCollection.RemoveAt(index);
        }

        public bool IsExistPoseCombination(PoseCombination poseCombination)
        {
            foreach (PoseCombination poses in _poseCollection)
            {
                if (poses.GetPoseList().SequenceEqual(poseCombination.GetPoseList()))
                    return true;
            }
            return false;
        }

        public bool IsExistPoseCombinationEdit(PoseCombination poseCombination, int editIndex)
        {
            PoseCombination editPoseCombination = _poseCollection[editIndex];
            _poseCollection.RemoveAt(editIndex);
            foreach (PoseCombination poses in _poseCollection)
            {
                if (poses.GetPoseList().SequenceEqual(poseCombination.GetPoseList()))
                {
                    _poseCollection.Insert(editIndex, editPoseCombination);
                    return true;
                }
            }
            _poseCollection.Insert(editIndex, editPoseCombination);
            return false;
        }

        public PoseCombination GetPoseCombination(int index)
        {
            PoseCombination response = null;
            if (index < _poseCollection.Count)
            {
                response = _poseCollection[index];
            }
            return response;
        }

        public BindingList<PoseCombination> GetPoseCollection()
        {
            return _poseCollection;
        }
        
        public List<PoseCombination> GetPoseCollectionList()
        {
            _poseCollectionList.Clear();
            foreach (PoseCombination poseCombination in _poseCollection)
            {
                if (poseCombination.IsEnable)
                    _poseCollectionList.Add(poseCombination);
            }
            return _poseCollectionList;
        }

        // image property
        public void SetImage(string path)
        {
            _imagePath = path;
        }

        // image property
        public string GetImagePath()
        {
            return _imagePath;
        }

        public void RemoveImage()
        {   
            if (File.Exists(_imagePath) && _imagePath != "Image/Myo.png")
            {
                File.Delete(_imagePath);
            }
        }

        // let binding source can read this property
        public Bitmap GetImage
        {
            get
            {
                Bitmap UIBitmap;
                // make sure image resource just in this scope
                // when using over, then image resource while be release
                using (Image image = Image.FromFile(_imagePath))
                {
                    UIBitmap = new Bitmap(image, 50, 50);
                }
                return UIBitmap;
            }
        }

        // Name property
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        // Enable property
        public bool IsEnable
        {
            set { _enable = value; }
            get { return _enable; }
        }

        // Open property
        public bool IsOpen
        {
            set { _open = value; }
            get { return _open; }
        }
    }
}
