using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace easy_control_c_sharp
{
    public partial class KeyState : Form
    {
        private KeyStates _keyState;
        public KeyState()
        {
            InitializeComponent();
            _keyState = KeyStates.None;
        }

        //點擊Press
        private void ClickPress(object sender, EventArgs e)
        {
            _press.Checked = true;
            _hold.Checked = false;
            _release.Checked = false;
            _keyState = KeyStates.Press;
        }

        //點擊Hold
        private void ClickHold(object sender, EventArgs e)
        {
            _press.Checked = false;
            _hold.Checked = true;
            _release.Checked = false;
            _keyState = KeyStates.Hold;
        }

        //點擊Release
        private void ClickRelease(object sender, EventArgs e)
        {
            _press.Checked = false;
            _hold.Checked = false;
            _release.Checked = true;
            _keyState = KeyStates.Release;
        }

        //按鈕事件(確認手勢配對按鈕)
        private void ClickOkButton(object sender, EventArgs e)
        {
            Close();
        }

        //回傳按鍵狀態
        public KeyStates GetKeyState()
        {
            return _keyState;
        }
    }
}
