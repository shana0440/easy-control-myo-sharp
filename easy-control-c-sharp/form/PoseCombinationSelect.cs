using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsInput;

namespace easy_control_c_sharp
{
    public partial class PoseCombinationSelect : Form
    {
        PoseCombination _poseCombination = new PoseCombination();
        PresentationModel _presentationModel;
        Window _window;
        bool _isEdit;
        int _editIndex;
        //新增模式
        public PoseCombinationSelect(PresentationModel model, Window window)
        {
            _presentationModel = model;
            _window = window;
            _isEdit = false;
            InitializeComponent();
        }

        //編輯模式
        public PoseCombinationSelect(PresentationModel model, Window window, int editIndex)
        {
            _presentationModel = model;
            _window = window;
            _isEdit = true;
            _editIndex = editIndex;
            InitializeComponent();
            InitailizePoseCombination(window.GetPoseCombination(editIndex));
            CheckIsContinue();
            _posePictureBox.Invalidate();
            _keyPictureBox.Invalidate();
        }

        //初始化PoseCombination
        public void InitailizePoseCombination(PoseCombination poseCombination)
        {
            _presentationModel.ProcessInitailizePoseCombination(_poseCombination, poseCombination);
        }

        //手勢選擇PictureBox重畫
        private void PosePictureBoxOnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawString("◈ 起始手勢", new Font("微軟正黑體", 15), Brushes.Black, 5, 3);
            graphics.DrawImage(_presentationModel.GetImage("fingersSpread", 75, 75), 30, 35);
            graphics.DrawImage(_presentationModel.GetImage("waveOut", 75, 75), 125, 35);
            graphics.DrawImage(_presentationModel.GetImage("waveIn", 75, 75), 220, 35);
            graphics.DrawImage(_presentationModel.GetImage("fist", 75, 75), 315, 35);
            graphics.DrawString("◈ 手臂運動", new Font("微軟正黑體", 15), Brushes.Black, 5, 114);
            graphics.DrawImage(_presentationModel.GetImage("rollUp", 75, 75), 30, 150);
            graphics.DrawImage(_presentationModel.GetImage("rollDown", 75, 75), 115, 150);
            graphics.DrawImage(_presentationModel.GetImage("pitchUp", 75, 75), 200, 150);
            graphics.DrawImage(_presentationModel.GetImage("pitchDown", 75, 75), 285, 150);
            graphics.DrawImage(_presentationModel.GetImage("yawUp", 75, 75), 370, 150);
            graphics.DrawImage(_presentationModel.GetImage("yawDown", 75, 75), 455, 150);
            graphics.DrawString("◈ 手勢組合", new Font("微軟正黑體", 15), Brushes.Black, 5, 225);
            _presentationModel.ProcessPosePictureBoxPaint(graphics, _poseCombination);
            graphics.DrawString("◈ 持續觸發功能", new Font("微軟正黑體", 15), Brushes.Black, 5, 340);
            CheckPoseKey();
            CheckIsContinue();
        }

        //按鍵選擇PictureBox重畫
        private void KeyPictureBoxOnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(_presentationModel.GetImage("keyboard", _keyPictureBox.Width, _keyPictureBox.Height), 0, 0);
            _presentationModel.ProcessKeyPictureBoxPaint(graphics, _poseCombination);
            CheckPoseKey();
        }

        //手勢選擇圖片點擊事件，判斷選擇的區域，並新增手勢
        private void ClickPosePictureBox(object sender, MouseEventArgs e)
        {
            _presentationModel.ProcessClickPosePictureBox(e.X, e.Y, _poseCombination);
            _posePictureBox.Invalidate();
        }

        //按鍵選擇圖片點擊事件，判斷選擇的區域，並新增功能鍵
        private void ClickKeyPictureBox(object sender, MouseEventArgs e)
        {
            _presentationModel.ProcessClickKeyPictureBox(e.X, e.Y, _poseCombination);
            _keyPictureBox.Invalidate();
        }

        //檢查是否可以設定為持續性手勢
        private void CheckIsContinue()
        {
            _continueCheckBox.Enabled = true;
            _continueCheckBox.Checked = _poseCombination.IsContinue;
        }

        //檢查是否有存在的手勢和按鍵，任何一種沒選到，確定鍵就不能按
        private void CheckPoseKey()
        {
            _okButton.Enabled = _presentationModel.CheckPoseKeyExist(_poseCombination);
        }

        //設定手勢組合是否為持續性
        private void ClickContinueCheckBox(object sender, EventArgs e)
        {
            if (_poseCombination.IsContinue)
                _poseCombination.IsContinue = false;
            else
                _poseCombination.IsContinue = true;
        }

        //按鈕事件(確認按鈕)
        private void ClickOkButton(object sender, EventArgs e)
        {
            _poseCombination.GetImage = _presentationModel.GetPoseCombinationImage(_poseCombination, _keyPictureBox.Width, _keyPictureBox.Height);
            _presentationModel.AddPoseCombination(_window, _poseCombination, _isEdit, _editIndex);
            Close();
        }

        //按鈕事件(取消按鈕)
        private void ClickCancelButton(object sender, EventArgs e)
        {
            Close();
        }

        private void MoveMouseInPosePictureBox(object sender, MouseEventArgs e)
        {
            _presentationModel.ChangeMouseInPictureBox(_poseCombination, e.X, e.Y);
        }

        private void MoveMouseInKeyPictureBox(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
