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
    public partial class WindowAdd : Form
    {
        PresentationModel _presentationModel;
        Window _window;
        bool _isEdit;
        public WindowAdd(PresentationModel presentationModel)
        {
            InitializeComponent();
            _presentationModel = presentationModel;
            _isEdit = false;
        }

        public WindowAdd(PresentationModel presentationModel, Window window)
        {
            InitializeComponent();
            _presentationModel = presentationModel;
            _window = window;
            _nameTextBox.Text = _window.Name;
            _imageTextBox.Text = _window.GetImagePath();
            _isEdit = true;
        }

        //按下Save按鈕，視窗關閉
        private void ClickSaveButton(object sender, EventArgs e)
        {
            _presentationModel.ProcessClickSaveButton(_window, _isEdit, _nameTextBox.Text.ToString(), _imageTextBox.Text.ToString());
            Close();
        }

        //按下Cancel按鈕，關閉視窗
        private void ClickCancelButton(object sender, EventArgs e)
        {
            Close();
        }

        //按下link按鈕，選擇圖片
        private void ClickLinkButton(object sender, EventArgs e)
        {
            _imageTextBox.Text = _presentationModel.ProcessOpenFile();
            CheckSaveButton();
        }

        //改變nameTextBox的內容時觸發
        private void ChangeText(object sender, EventArgs e)
        {
            CheckSaveButton();
        }

        //取得軟體的名子
        public string GetWindowName()
        {
            return _nameTextBox.Text.ToString();
        }

        //取得軟體的圖片
        public string GetImageFile()
        {
            return _imageTextBox.Text.ToString();
        }

        //是否啟用SaveButton
        private void CheckSaveButton()
        {
            _saveButton.Enabled = _presentationModel.IsSaveButtonEnable(_nameTextBox);
        }
    }
}
