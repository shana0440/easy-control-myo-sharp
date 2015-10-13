using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using easy_control_c_sharp.common;

namespace easy_control_c_sharp
{
    public partial class PoseCombinationSelect : Form
    {
        PoseCombination _poseCombination = new PoseCombination();
        PresentationModel _presentationModel;
        Dictionary<Rectangle, Pose> _poseBoard = new Dictionary<Rectangle, Pose>();
        Dictionary<Rectangle, Key> _keyBoard = new Dictionary<Rectangle, Key>();
        Mode _mode;
        bool _isEdit;
        int _editIndex;
        //新增模式
        public PoseCombinationSelect(PresentationModel model, Mode mode)
        {
            _presentationModel = model;
            _mode = mode;
            _isEdit = false;
            InitializeComponent();
            InitailizePoseboard();
            InitailizeKeyboard();
        }

        //編輯模式
        public PoseCombinationSelect(PresentationModel model, Mode mode, int editIndex)
        {
            _presentationModel = model;
            _mode = mode;
            _isEdit = true;
            _editIndex = editIndex;
            InitializeComponent();
            InitailizePoseCombination(mode.GetPoseCombination(editIndex));
            InitailizePoseboard();
            InitailizeKeyboard();
            CheckIsContinue();
            _posePictureBox.Invalidate();
            _keyPictureBox.Invalidate();
        }

        //初始化PoseCombination
        public void InitailizePoseCombination(PoseCombination poseCombination)
        {
            _presentationModel.ProcessInitailizePoseCombination(_poseCombination, poseCombination);
        }

        //初始化所有手勢按鍵參數
        private void InitailizePoseboard()
        {
            //起始手勢
            _poseBoard.Add(new Rectangle(10, 35, 75, 75), new Pose("fingersSpread", _presentationModel.GetImage("fingersSpread", 75, 75)));
            _poseBoard.Add(new Rectangle(105, 35, 75, 75), new Pose("waveOut", _presentationModel.GetImage("waveOut", 75, 75)));
            _poseBoard.Add(new Rectangle(200, 35, 75, 75), new Pose("waveIn", _presentationModel.GetImage("waveIn", 75, 75)));
            _poseBoard.Add(new Rectangle(295, 35, 75, 75), new Pose("fist", _presentationModel.GetImage("fist", 75, 75)));
            //手臂運動
            _poseBoard.Add(new Rectangle(10, 150, 75, 75), new Pose("rollUp", _presentationModel.GetImage("rollUp", 75, 75)));
            _poseBoard.Add(new Rectangle(95, 150, 75, 75), new Pose("rollDown", _presentationModel.GetImage("rollDown", 75, 75)));
            _poseBoard.Add(new Rectangle(180, 150, 75, 75), new Pose("pitchUp", _presentationModel.GetImage("pitchUp", 75, 75)));
            _poseBoard.Add(new Rectangle(265, 150, 75, 75), new Pose("pitchDown", _presentationModel.GetImage("pitchDown", 75, 75)));
            _poseBoard.Add(new Rectangle(350, 150, 75, 75), new Pose("yawUp", _presentationModel.GetImage("yawUp", 75, 75)));
            _poseBoard.Add(new Rectangle(435, 150, 75, 75), new Pose("yawDown", _presentationModel.GetImage("yawDown", 75, 75)));
        }

        //初始化所有鍵盤按鍵參數
        private void InitailizeKeyboard()
        {
            //鍵盤第一列
            _keyBoard.Add(new Rectangle(0, 3, 37, 32), new Key("Esc", 0x1B));
            _keyBoard.Add(new Rectangle(37, 3, 37, 32), new Key("`", 0xC0));
            _keyBoard.Add(new Rectangle(74, 3, 37, 32), new Key("1", 0x31));
            _keyBoard.Add(new Rectangle(111, 3, 37, 32), new Key("2", 0x32));
            _keyBoard.Add(new Rectangle(148, 3, 37, 32), new Key("3", 0x33));
            _keyBoard.Add(new Rectangle(185, 3, 37, 32), new Key("4", 0x34));
            _keyBoard.Add(new Rectangle(222, 3, 37, 32), new Key("5", 0x35));
            _keyBoard.Add(new Rectangle(259, 3, 37, 32), new Key("6", 0x36));
            _keyBoard.Add(new Rectangle(296, 3, 37, 32), new Key("7", 0x37));
            _keyBoard.Add(new Rectangle(333, 3, 37, 32), new Key("8", 0x38));
            _keyBoard.Add(new Rectangle(370, 3, 37, 32), new Key("9", 0x39));
            _keyBoard.Add(new Rectangle(407, 3, 37, 32), new Key("0", 0x30));
            _keyBoard.Add(new Rectangle(444, 3, 37, 32), new Key("-", 0xBD));
            _keyBoard.Add(new Rectangle(481, 3, 37, 32), new Key("=", 0xBB));
            _keyBoard.Add(new Rectangle(518, 3, 57, 32), new Key("backspace", 0x08));
            _keyBoard.Add(new Rectangle(575, 3, 67, 32), new Key("Home", 0x24));
            //鍵盤第二列
            _keyBoard.Add(new Rectangle(0, 35, 55, 35), new Key("Tab", 0x09));
            _keyBoard.Add(new Rectangle(55, 35, 37, 35), new Key("Q", 0x51));
            _keyBoard.Add(new Rectangle(92, 35, 37, 35), new Key("W", 0x57));
            _keyBoard.Add(new Rectangle(129, 35, 37, 35), new Key("E", 0x45));
            _keyBoard.Add(new Rectangle(166, 35, 37, 35), new Key("R", 0x52));
            _keyBoard.Add(new Rectangle(203, 35, 37, 35), new Key("T", 0x54));
            _keyBoard.Add(new Rectangle(240, 35, 37, 35), new Key("Y", 0x59));
            _keyBoard.Add(new Rectangle(277, 35, 37, 35), new Key("U", 0x55));
            _keyBoard.Add(new Rectangle(314, 35, 37, 35), new Key("I", 0x49));
            _keyBoard.Add(new Rectangle(351, 35, 37, 35), new Key("O", 0x4F));
            _keyBoard.Add(new Rectangle(388, 35, 37, 35), new Key("P", 0x50));
            _keyBoard.Add(new Rectangle(425, 35, 37, 35), new Key("[", 0xDB));
            _keyBoard.Add(new Rectangle(462, 35, 37, 35), new Key("]", 0xDD));
            _keyBoard.Add(new Rectangle(499, 35, 37, 35), new Key("\\", 0xDC));
            _keyBoard.Add(new Rectangle(536, 35, 37, 35), new Key("Del", 0x2E));
            _keyBoard.Add(new Rectangle(575, 35, 67, 35), new Key("End", 0x23));
            //鍵盤第三列
            _keyBoard.Add(new Rectangle(0, 70, 74, 35), new Key("Caps", 0x14));
            _keyBoard.Add(new Rectangle(74, 70, 37, 35), new Key("A", 0x41));
            _keyBoard.Add(new Rectangle(111, 70, 37, 35), new Key("S", 0x53));
            _keyBoard.Add(new Rectangle(148, 70, 37, 35), new Key("D", 0x44));
            _keyBoard.Add(new Rectangle(185, 70, 37, 35), new Key("F", 0x46));
            _keyBoard.Add(new Rectangle(221, 70, 37, 35), new Key("G", 0x47));
            _keyBoard.Add(new Rectangle(259, 70, 37, 35), new Key("H", 0x48));
            _keyBoard.Add(new Rectangle(296, 70, 37, 35), new Key("J", 0x4A));
            _keyBoard.Add(new Rectangle(333, 70, 37, 35), new Key("K", 0x4B));
            _keyBoard.Add(new Rectangle(370, 70, 37, 35), new Key("L", 0x4C));
            _keyBoard.Add(new Rectangle(407, 70, 37, 35), new Key(";", 0xBA));
            _keyBoard.Add(new Rectangle(444, 70, 37, 35), new Key("'", 0xDE));
            _keyBoard.Add(new Rectangle(481, 70, 94, 35), new Key("Enter", 0x0D));
            _keyBoard.Add(new Rectangle(575, 70, 67, 35), new Key("PgUp", 0x21));
            //鍵盤第四列
            _keyBoard.Add(new Rectangle(0, 104, 92, 35), new Key("Left Shift", 0xA0));
            _keyBoard.Add(new Rectangle(92, 104, 37, 35), new Key("Z", 0x5A));
            _keyBoard.Add(new Rectangle(129, 104, 37, 35), new Key("X", 0x58));
            _keyBoard.Add(new Rectangle(166, 104, 37, 35), new Key("C", 0x43));
            _keyBoard.Add(new Rectangle(203, 104, 37, 35), new Key("V", 0x56));
            _keyBoard.Add(new Rectangle(240, 104, 37, 35), new Key("B", 0x42));
            _keyBoard.Add(new Rectangle(277, 104, 37, 35), new Key("N", 0x4E));
            _keyBoard.Add(new Rectangle(314, 104, 37, 35), new Key("M", 0x4D));
            _keyBoard.Add(new Rectangle(351, 104, 37, 35), new Key(",", 0xBC));
            _keyBoard.Add(new Rectangle(388, 104, 37, 35), new Key(".", 0xBE));
            _keyBoard.Add(new Rectangle(425, 104, 37, 35), new Key("/", 0xBF));
            _keyBoard.Add(new Rectangle(462, 104, 37, 35), new Key("Up", 0x26));
            _keyBoard.Add(new Rectangle(500, 104, 75, 35), new Key("Right Shift", 0xA1));
            _keyBoard.Add(new Rectangle(575, 104, 67, 35), new Key("PgDn", 0x22));
            //鍵盤第五列
            _keyBoard.Add(new Rectangle(0, 138, 37, 35), new Key("Fn", 0)); //待補(不知是哪種byte)
            _keyBoard.Add(new Rectangle(37, 138, 37, 35), new Key("Left Ctrl", 0xA2));
            _keyBoard.Add(new Rectangle(74, 138, 37, 35), new Key("Windows", 0x5B));
            _keyBoard.Add(new Rectangle(111, 138, 37, 35), new Key("Left Alt", 0xA4));
            _keyBoard.Add(new Rectangle(148, 138, 204, 35), new Key("Space", 0x20));
            _keyBoard.Add(new Rectangle(352, 138, 37, 35), new Key("Right Alt", 0xA5));
            _keyBoard.Add(new Rectangle(389, 138, 37, 35), new Key("Right Ctrl", 0xA3));
            _keyBoard.Add(new Rectangle(426, 138, 37, 35), new Key("Left", 0x25));
            _keyBoard.Add(new Rectangle(463, 138, 37, 35), new Key("Down", 0x28));
            _keyBoard.Add(new Rectangle(500, 138, 37, 35), new Key("Right", 0x27));
            _keyBoard.Add(new Rectangle(537, 138, 37, 35), new Key("Menu", 0)); //待補(不知是哪種byte)
        }

        //手勢選擇PictureBox重畫
        private void PosePictureBoxOnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawString("起始手勢", new Font("Arial", 15), Brushes.DarkRed, 10, 8);
            graphics.DrawImage(_presentationModel.GetImage("fingersSpread", 75, 75), 10, 35);
            graphics.DrawImage(_presentationModel.GetImage("waveOut", 75, 75), 105, 35);
            graphics.DrawImage(_presentationModel.GetImage("waveIn", 75, 75), 200, 35);
            graphics.DrawImage(_presentationModel.GetImage("fist", 75, 75), 295, 35);
            graphics.DrawString("手臂運動", new Font("Arial", 15), Brushes.DarkRed, 10, 120);
            graphics.DrawImage(_presentationModel.GetImage("rollUp", 75, 75), 10, 150);
            graphics.DrawImage(_presentationModel.GetImage("rollDown", 75, 75), 95, 150);
            graphics.DrawImage(_presentationModel.GetImage("pitchUp", 75, 75), 180, 150);
            graphics.DrawImage(_presentationModel.GetImage("pitchDown", 75, 75), 265, 150);
            graphics.DrawImage(_presentationModel.GetImage("yawUp", 75, 75), 350, 150);
            graphics.DrawImage(_presentationModel.GetImage("yawDown", 75, 75), 435, 150);
            graphics.DrawString("手勢組合", new Font("Arial", 15), Brushes.DarkRed, 10, 230);
            _presentationModel.ProcessPosePictureBoxPaint(graphics, _poseCombination);
            graphics.DrawString("持續觸發功能", new Font("Arial", 15), Brushes.DarkRed, 10, 343);
            CheckPoseKey();
            CheckIsContinue();
        }

        //按鍵選擇PictureBox重畫
        private void KeyPictureBoxOnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(_presentationModel.GetImage("keyboard", _keyPictureBox.Width, _keyPictureBox.Height), 0, 0);
            _presentationModel.ProcessKeyPictureBoxPaint(graphics, _poseCombination, _keyBoard);
            CheckPoseKey();
        }

        //手勢選擇圖片點擊事件，判斷選擇的區域，並新增手勢
        private void ClickPosePictureBox(object sender, MouseEventArgs e)
        {
            _presentationModel.ProcessClickPosePictureBox(e.X, e.Y, _poseCombination, _poseBoard);
            _posePictureBox.Invalidate();
        }

        //按鍵選擇圖片點擊事件，判斷選擇的區域，並新增功能鍵
        private void ClickKeyPictureBox(object sender, MouseEventArgs e)
        {
            _presentationModel.ProcessClickKeyPictureBox(e.X, e.Y, _poseCombination, _keyBoard);
            _keyPictureBox.Invalidate();
        }

        //檢查是否可以設定為持續性手勢
        private void CheckIsContinue()
        {
            _continueCheckBox.Enabled = _presentationModel.CheckPosesIsContinue(_poseCombination);
            _continueCheckBox.Checked = _poseCombination.GetIsContinue();
        }

        //檢查是否有存在的手勢和按鍵，任何一種沒選到，確定鍵就不能按
        private void CheckPoseKey()
        {
            _okButton.Enabled = _presentationModel.CheckPoseKeyExist(_poseCombination);
        }

        //設定手勢組合是否為持續性
        private void ClickContinueCheckBox(object sender, EventArgs e)
        {
            _poseCombination.SetIsContinue();
        }

        //按鈕事件(確認按鈕)
        private void ClickOkButton(object sender, EventArgs e)
        {
            _presentationModel.AddPoseCombination(_mode, _poseCombination, _isEdit, _editIndex);
            Close();
        }

        //按鈕事件(取消按鈕)
        private void ClickCancelButton(object sender, EventArgs e)
        {
            Close();
        }
    }
}
