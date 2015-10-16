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
    public partial class EasyControl : Form
    {
        PresentationModel _presentationModel;
        public EasyControl(PresentationModel model)
        {
            InitializeComponent();
            _presentationModel = model;
            _presentationModel.easyControlLoad("Save.xml");
            BindingSource source = new BindingSource(_presentationModel.GetWindowList(), null);
            _windowGridView.DataSource = source;

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
            _presentationModel.easyControlSave("Save.xml");
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
            
            _windowGridView.Columns.Add(deleteBtn);
            DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
            editBtn.Text = "Edit";
            editBtn.Name = "editBtn";
            editBtn.UseColumnTextForButtonValue = true;
            editBtn.HeaderText = "edit";
            editBtn.Width = 50;
            editBtn.DisplayIndex = 3;

            _windowGridView.Columns.Add(editBtn);
            _windowGridView.Columns["GetImage"].HeaderText = "icon";
            _windowGridView.Columns["IsEnable"].HeaderText = "enable";
            _windowGridView.Columns["Name"].HeaderText = "name";
            _windowGridView.Columns["IsOpen"].Visible = false;
        }

        //點擊軟體GridView事件
        private void ClickWindowGridViewCell(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.ProcessWindowGridViewCell(e.RowIndex, e.ColumnIndex);
            _windowGridView.Refresh();
        }

        //新增軟體button click事件
        private void ClickAddButton(object sender, EventArgs e)
        {
            WindowAdd modeAddForm = new WindowAdd(_presentationModel);
            _presentationModel.ProcessAddForm(modeAddForm);
        }

        private void ModeGridViewCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            _presentationModel.ProcessWindowGridViewCellFormatting(e.ColumnIndex, _windowGridView);
        }

        private void CloseForm(object sender, FormClosedEventArgs e)
        {
            _presentationModel.easyControlSave("Save.xml");
            _presentationModel.LockMyo();
        }
    }
}
