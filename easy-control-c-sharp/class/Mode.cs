using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace easy_control_UI
{
    public class Mode
    {
        private string _name;
        private bool _enable = true;
        private bool _open = false;
        private string _imagePath;
        BindingList<PoseCombination> _poseCombinationList = new BindingList<PoseCombination>();
        
        public Mode(string name)
        {
            _name = name;
        }

        // PoseCombinationList method
        public void AddPoseCombination(PoseCombination poseCombination)
        {
            _poseCombinationList.Add(poseCombination);
        }

        public void RemovePoseCombinationByIndex(int index)
        {
            _poseCombinationList.RemoveAt(index);
        }

        public void InsertPoseCombination(int index, PoseCombination poseCombination)
        {
            _poseCombinationList.Insert(index, poseCombination);
        }

        public BindingList<PoseCombination> GetPoseCombinationList()
        {
            return _poseCombinationList;
        }

        public PoseCombination GetPoseCombination(int index)
        {
            PoseCombination response = null;
            if (index < _poseCombinationList.Count)
            {
                response = _poseCombinationList[index];
            }
            return response;
        }

        // image property
        public void SetImage(string path)
        {
            _imagePath = path;
        }

        // PoseCombinationList property
        public int GetPoseCombinationListLength()
        {
            return _poseCombinationList.Count;
        }

        // Image property
        public Bitmap GetImage
        {
            get
            {
                Bitmap UIBitmap = new Bitmap(Image.FromFile(_imagePath), 50, 50);
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
