using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace easy_control_UI
{
    public partial class EasyControl : Form
    {
        PresentationModel _presentationModel;
        public EasyControl(PresentationModel model)
        {
            InitializeComponent();
            _presentationModel = model;
            BindingSource source = new BindingSource(_presentationModel.GetModeList(), null);
            _modeGridView.DataSource = source;

            // must be last line
            InitializeGridView();
        }

        //點選controlbox縮到最小之後，就會將Form隱藏，並將icon顯示於右下角
        private void ResizeForm(object sender, System.EventArgs e)
        {
            _presentationModel.ProcessResizeForm(WindowState);
        }

        //當點選windows桌面右下角的icon兩下，則Form會顯示
        private void ClickNotifyIcon(object sender, System.EventArgs e)
        {
            _presentationModel.ProcessShowForm();
        }

        //右下角圖示，開啟視窗
        private void ClickMenuStripOpen(object sender, EventArgs e)
        {
            _presentationModel.ProcessShowForm();
        }

        //右下角圖示，結束視窗
        private void ClickMenuStripClose(object sender, EventArgs e)
        {
            Close();
        }

        //初始化GridView
        private void InitializeGridView()
        {
            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            deleteBtn.Text = "X";
            deleteBtn.Name = "deleteBtn";
            deleteBtn.UseColumnTextForButtonValue = true;
            deleteBtn.HeaderText = "remove";
            deleteBtn.Width = 50;
            deleteBtn.DisplayIndex = 2;
            
            _modeGridView.Columns.Add(deleteBtn);
            _modeGridView.Columns["GetImage"].HeaderText = "icon";
            _modeGridView.Columns["IsEnable"].HeaderText = "enable";
            _modeGridView.Columns["Name"].HeaderText = "name";
            _modeGridView.Columns["IsOpen"].Visible = false;
        }

        //點擊軟體GridView事件
        private void ModeGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.ProcessModeGridViewCell(e.RowIndex, e.ColumnIndex, _presentationModel);
        }

        //新增軟體button click事件
        private void ClickAddButton(object sender, EventArgs e)
        {
            ModeAdd modeAddForm = new ModeAdd(_presentationModel);
            _presentationModel.ProcessAddForm(modeAddForm);
        }

        private void ModeGridViewCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            _presentationModel.ProcessModeGridViewCellFormatting(e.ColumnIndex, _modeGridView);
        }
    }
}
