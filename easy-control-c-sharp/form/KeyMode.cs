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
    public partial class KeyMode : Form
    {
        private string _keyMode;
        public KeyMode()
        {
            InitializeComponent();
            _keyMode = "";
        }

        //點擊Press
        private void ClickPress(object sender, EventArgs e)
        {
            _press.Checked = true;
            _hold.Checked = false;
            _release.Checked = false;
            _keyMode = "press";
        }

        //點擊Hold
        private void ClickHold(object sender, EventArgs e)
        {
            _press.Checked = false;
            _hold.Checked = true;
            _release.Checked = false;
            _keyMode = "hold";
        }

        //點擊Release
        private void ClickRelease(object sender, EventArgs e)
        {
            _press.Checked = false;
            _hold.Checked = false;
            _release.Checked = true;
            _keyMode = "release";
        }

        //按鈕事件(確認手勢配對按鈕)
        private void ClickOkButton(object sender, EventArgs e)
        {
            Close();
        }

        //回傳按鍵狀態
        public string GetKeyMode()
        {
            return _keyMode;
        }
    }
}
