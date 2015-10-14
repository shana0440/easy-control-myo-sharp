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
        Dictionary<Rectangle, string> _poseBoard = new Dictionary<Rectangle, string>();
        Dictionary<Rectangle, Key> _keyBoard = new Dictionary<Rectangle, Key>();
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
            InitailizePoseboard();
            InitailizeKeyboard();
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
            _poseBoard.Add(new Rectangle(10, 35, 75, 75), "fingersSpread");
            _poseBoard.Add(new Rectangle(105, 35, 75, 75), "waveOut");
            _poseBoard.Add(new Rectangle(200, 35, 75, 75), "waveIn");
            _poseBoard.Add(new Rectangle(295, 35, 75, 75), "fist");
            //手臂運動
            _poseBoard.Add(new Rectangle(10, 150, 75, 75), "rollUp");
            _poseBoard.Add(new Rectangle(95, 150, 75, 75), "rollDown");
            _poseBoard.Add(new Rectangle(180, 150, 75, 75), "pitchUp");
            _poseBoard.Add(new Rectangle(265, 150, 75, 75), "pitchDown");
            _poseBoard.Add(new Rectangle(350, 150, 75, 75), "yawUp");
            _poseBoard.Add(new Rectangle(435, 150, 75, 75), "yawDown");
        }

        //初始化所有鍵盤按鍵參數
        private void InitailizeKeyboard()
        {
            //鍵盤第一列
            _keyBoard.Add(new Rectangle(0, 3, 37, 32), new Key(VirtualKeyCode.ESCAPE, KeyStates.None));
            _keyBoard.Add(new Rectangle(37, 3, 37, 32), new Key(VirtualKeyCode.OEM_3, KeyStates.None));
            _keyBoard.Add(new Rectangle(74, 3, 37, 32), new Key(VirtualKeyCode.VK_1, KeyStates.None));
            _keyBoard.Add(new Rectangle(111, 3, 37, 32), new Key(VirtualKeyCode.VK_2, KeyStates.None));
            _keyBoard.Add(new Rectangle(148, 3, 37, 32), new Key(VirtualKeyCode.VK_3, KeyStates.None));
            _keyBoard.Add(new Rectangle(185, 3, 37, 32), new Key(VirtualKeyCode.VK_4, KeyStates.None));
            _keyBoard.Add(new Rectangle(222, 3, 37, 32), new Key(VirtualKeyCode.VK_5, KeyStates.None));
            _keyBoard.Add(new Rectangle(259, 3, 37, 32), new Key(VirtualKeyCode.VK_6, KeyStates.None));
            _keyBoard.Add(new Rectangle(296, 3, 37, 32), new Key(VirtualKeyCode.VK_7, KeyStates.None));
            _keyBoard.Add(new Rectangle(333, 3, 37, 32), new Key(VirtualKeyCode.VK_8, KeyStates.None));
            _keyBoard.Add(new Rectangle(370, 3, 37, 32), new Key(VirtualKeyCode.VK_9, KeyStates.None));
            _keyBoard.Add(new Rectangle(407, 3, 37, 32), new Key(VirtualKeyCode.VK_0, KeyStates.None));
            _keyBoard.Add(new Rectangle(444, 3, 37, 32), new Key(VirtualKeyCode.OEM_MINUS, KeyStates.None));
            _keyBoard.Add(new Rectangle(481, 3, 37, 32), new Key(VirtualKeyCode.OEM_PLUS, KeyStates.None));
            _keyBoard.Add(new Rectangle(518, 3, 57, 32), new Key(VirtualKeyCode.BACK, KeyStates.None));
            _keyBoard.Add(new Rectangle(575, 3, 67, 32), new Key(VirtualKeyCode.HOME, KeyStates.None));
            //鍵盤第二列
            _keyBoard.Add(new Rectangle(0, 35, 55, 35), new Key(VirtualKeyCode.TAB, KeyStates.None));
            _keyBoard.Add(new Rectangle(55, 35, 37, 35), new Key(VirtualKeyCode.VK_Q, KeyStates.None));
            _keyBoard.Add(new Rectangle(92, 35, 37, 35), new Key(VirtualKeyCode.VK_W, KeyStates.None));
            _keyBoard.Add(new Rectangle(129, 35, 37, 35), new Key(VirtualKeyCode.VK_E, KeyStates.None));
            _keyBoard.Add(new Rectangle(166, 35, 37, 35), new Key(VirtualKeyCode.VK_R, KeyStates.None));
            _keyBoard.Add(new Rectangle(203, 35, 37, 35), new Key(VirtualKeyCode.VK_T, KeyStates.None));
            _keyBoard.Add(new Rectangle(240, 35, 37, 35), new Key(VirtualKeyCode.VK_Y, KeyStates.None));
            _keyBoard.Add(new Rectangle(277, 35, 37, 35), new Key(VirtualKeyCode.VK_U, KeyStates.None));
            _keyBoard.Add(new Rectangle(314, 35, 37, 35), new Key(VirtualKeyCode.VK_I, KeyStates.None));
            _keyBoard.Add(new Rectangle(351, 35, 37, 35), new Key(VirtualKeyCode.VK_O, KeyStates.None));
            _keyBoard.Add(new Rectangle(388, 35, 37, 35), new Key(VirtualKeyCode.VK_P, KeyStates.None));
            _keyBoard.Add(new Rectangle(425, 35, 37, 35), new Key(VirtualKeyCode.OEM_4, KeyStates.None));
            _keyBoard.Add(new Rectangle(462, 35, 37, 35), new Key(VirtualKeyCode.OEM_6, KeyStates.None));
            _keyBoard.Add(new Rectangle(499, 35, 37, 35), new Key(VirtualKeyCode.OEM_5, KeyStates.None));
            _keyBoard.Add(new Rectangle(536, 35, 37, 35), new Key(VirtualKeyCode.DELETE, KeyStates.None));
            _keyBoard.Add(new Rectangle(575, 35, 67, 35), new Key(VirtualKeyCode.END, KeyStates.None));
            //鍵盤第三列
            _keyBoard.Add(new Rectangle(0, 70, 74, 35), new Key(VirtualKeyCode.CAPITAL, KeyStates.None));
            _keyBoard.Add(new Rectangle(74, 70, 37, 35), new Key(VirtualKeyCode.VK_A, KeyStates.None));
            _keyBoard.Add(new Rectangle(111, 70, 37, 35), new Key(VirtualKeyCode.VK_S, KeyStates.None));
            _keyBoard.Add(new Rectangle(148, 70, 37, 35), new Key(VirtualKeyCode.VK_D, KeyStates.None));
            _keyBoard.Add(new Rectangle(185, 70, 37, 35), new Key(VirtualKeyCode.VK_F, KeyStates.None));
            _keyBoard.Add(new Rectangle(221, 70, 37, 35), new Key(VirtualKeyCode.VK_G, KeyStates.None));
            _keyBoard.Add(new Rectangle(259, 70, 37, 35), new Key(VirtualKeyCode.VK_H, KeyStates.None));
            _keyBoard.Add(new Rectangle(296, 70, 37, 35), new Key(VirtualKeyCode.VK_J, KeyStates.None));
            _keyBoard.Add(new Rectangle(333, 70, 37, 35), new Key(VirtualKeyCode.VK_K, KeyStates.None));
            _keyBoard.Add(new Rectangle(370, 70, 37, 35), new Key(VirtualKeyCode.VK_L, KeyStates.None));
            _keyBoard.Add(new Rectangle(407, 70, 37, 35), new Key(VirtualKeyCode.OEM_1, KeyStates.None));
            _keyBoard.Add(new Rectangle(444, 70, 37, 35), new Key(VirtualKeyCode.OEM_7, KeyStates.None));
            _keyBoard.Add(new Rectangle(481, 70, 94, 35), new Key(VirtualKeyCode.RETURN, KeyStates.None));
            _keyBoard.Add(new Rectangle(575, 70, 67, 35), new Key(VirtualKeyCode.PRIOR, KeyStates.None));
            //鍵盤第四列
            _keyBoard.Add(new Rectangle(0, 104, 92, 35), new Key(VirtualKeyCode.LSHIFT, KeyStates.None));
            _keyBoard.Add(new Rectangle(92, 104, 37, 35), new Key(VirtualKeyCode.VK_Z, KeyStates.None));
            _keyBoard.Add(new Rectangle(129, 104, 37, 35), new Key(VirtualKeyCode.VK_X, KeyStates.None));
            _keyBoard.Add(new Rectangle(166, 104, 37, 35), new Key(VirtualKeyCode.VK_C, KeyStates.None));
            _keyBoard.Add(new Rectangle(203, 104, 37, 35), new Key(VirtualKeyCode.VK_V, KeyStates.None));
            _keyBoard.Add(new Rectangle(240, 104, 37, 35), new Key(VirtualKeyCode.VK_B, KeyStates.None));
            _keyBoard.Add(new Rectangle(277, 104, 37, 35), new Key(VirtualKeyCode.VK_N, KeyStates.None));
            _keyBoard.Add(new Rectangle(314, 104, 37, 35), new Key(VirtualKeyCode.VK_M, KeyStates.None));
            _keyBoard.Add(new Rectangle(351, 104, 37, 35), new Key(VirtualKeyCode.OEM_COMMA, KeyStates.None));
            _keyBoard.Add(new Rectangle(388, 104, 37, 35), new Key(VirtualKeyCode.OEM_PERIOD, KeyStates.None));
            _keyBoard.Add(new Rectangle(425, 104, 37, 35), new Key(VirtualKeyCode.OEM_2, KeyStates.None));
            _keyBoard.Add(new Rectangle(462, 104, 37, 35), new Key(VirtualKeyCode.UP, KeyStates.None));
            _keyBoard.Add(new Rectangle(500, 104, 75, 35), new Key(VirtualKeyCode.RSHIFT, KeyStates.None));
            _keyBoard.Add(new Rectangle(575, 104, 67, 35), new Key(VirtualKeyCode.NEXT, KeyStates.None));
            //鍵盤第五列
            _keyBoard.Add(new Rectangle(0, 138, 37, 35), new Key(VirtualKeyCode.F5, KeyStates.None)); //VirtualKeyCode隨便填，暫定F5
            _keyBoard.Add(new Rectangle(37, 138, 37, 35), new Key(VirtualKeyCode.LCONTROL, KeyStates.None));
            _keyBoard.Add(new Rectangle(74, 138, 37, 35), new Key(VirtualKeyCode.LWIN, KeyStates.None));
            _keyBoard.Add(new Rectangle(111, 138, 37, 35), new Key(VirtualKeyCode.LMENU, KeyStates.None));
            _keyBoard.Add(new Rectangle(148, 138, 204, 35), new Key(VirtualKeyCode.SPACE, KeyStates.None));
            _keyBoard.Add(new Rectangle(352, 138, 37, 35), new Key(VirtualKeyCode.RMENU, KeyStates.None));
            _keyBoard.Add(new Rectangle(389, 138, 37, 35), new Key(VirtualKeyCode.RCONTROL, KeyStates.None));
            _keyBoard.Add(new Rectangle(426, 138, 37, 35), new Key(VirtualKeyCode.LEFT, KeyStates.None));
            _keyBoard.Add(new Rectangle(463, 138, 37, 35), new Key(VirtualKeyCode.DOWN, KeyStates.None));
            _keyBoard.Add(new Rectangle(500, 138, 37, 35), new Key(VirtualKeyCode.RIGHT, KeyStates.None));
            _keyBoard.Add(new Rectangle(537, 138, 37, 35), new Key(VirtualKeyCode.MENU, KeyStates.None)); //VirtualKeyCode不確定，先暫定MENU
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
            _presentationModel.ProcessPosePictureBoxPaint(graphics, _poseCombination, _presentationModel);
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
            _poseCombination.GetImage = _presentationModel.GetPoseCombinationImage(_poseCombination, _presentationModel, _keyBoard, _keyPictureBox.Width, _keyPictureBox.Height);
            _presentationModel.AddPoseCombination(_window, _poseCombination, _isEdit, _editIndex);
            Close();
        }

        //按鈕事件(取消按鈕)
        private void ClickCancelButton(object sender, EventArgs e)
        {
            Close();
        }
    }
}
