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
    public partial class WindowDetail : Form
    {
        PresentationModel _presentationModel;
        Window _window;
        public WindowDetail(PresentationModel model, Window window)
        {
            InitializeComponent();
            _presentationModel = model;
            _window = window;
            _modePictureBox.Invalidate();
            BindingSource source = new BindingSource(window.GetPoseCollection(), null);
            _poseCombinationGridView.DataSource = source;
            InitializeGridView();
        }
        
        //初始化GridView
        private void InitializeGridView()
        {
            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            deleteBtn.Text = "X";
            deleteBtn.Name = "deleteBtn";
            deleteBtn.HeaderText = "remove";
            deleteBtn.UseColumnTextForButtonValue = true;
            deleteBtn.Width = 50;
            deleteBtn.DisplayIndex = 1;
            
            _poseCombinationGridView.Columns.Add(deleteBtn);
            _poseCombinationGridView.Columns["IsEnable"].HeaderText = "enable";
            _poseCombinationGridView.Columns["GetImage"].HeaderText = "icon";
            _poseCombinationGridView.Columns["IsCompleted"].Visible = false;
            _poseCombinationGridView.Columns["IsContinue"].Visible = false;
        }

        //modePictureBox重畫
        private void WindowPictureBoxOnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(_window.GetImage, 0, 0);
            e.Graphics.DrawString(_window.Name, new Font("微軟正黑體", 25), Brushes.Black, 60, 8);
        }

        //新增手勢配對button click事件
        private void ClickAddButton(object sender, EventArgs e)
        {
            PoseCombinationSelect PoseCombinationForm = new PoseCombinationSelect(_presentationModel, _window);
            PoseCombinationForm.ShowDialog();
        }

        //點擊手勢配對GridView事件
        private void PoseCombinationGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.ProcessPoseCombinationGridViewCell(_window, e.RowIndex, e.ColumnIndex);
        }

        //關閉視窗時，將此mode的開啟狀態設為false(避免同樣mode的ModeDetail視窗重覆開啟)
        private void WindowDetailFormClosed(object sender, FormClosedEventArgs e)
        {
            _window.IsOpen = false;
        }

        private void PoseCombinationGridViewCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            _presentationModel.ProcessPoseCombinationGridViewCellFormatting(e.ColumnIndex, _poseCombinationGridView);
        }
    }
}
