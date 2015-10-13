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
    public partial class ModeDetail : Form
    {
        PresentationModel _presentationModel;
        Mode _mode;
        public ModeDetail(PresentationModel model, Mode mode)
        {
            InitializeComponent();
            _presentationModel = model;
            _mode = mode;
            _modePictureBox.Invalidate();
            BindingSource source = new BindingSource(mode.GetPoseCombinationList(), null);
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
            
        }

        //modePictureBox重畫
        private void ModePictureBoxOnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(_mode.GetImage, 0, 0);
            e.Graphics.DrawString(_mode.Name, new Font("Arial", 25), Brushes.DarkRed, 60, 8);
        }

        //新增手勢配對button click事件
        private void ClickAddButton(object sender, EventArgs e)
        {
            PoseCombinationSelect PoseCombinationForm = new PoseCombinationSelect(_presentationModel, _mode);
            PoseCombinationForm.ShowDialog();
        }

        //點擊手勢配對GridView事件
        private void PoseCombinationGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.ProcessPoseCombinationGridViewCell(_mode, e.RowIndex, e.ColumnIndex, _presentationModel);
        }

        //關閉視窗時，將此mode的開啟狀態設為false(避免同樣mode的ModeDetail視窗重覆開啟)
        private void ModeDetailFormClosed(object sender, FormClosedEventArgs e)
        {
            _mode.IsOpen = false;
        }

        private void PoseCombinationGridViewCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            _presentationModel.ProcessPoseCombinationGridViewCellFormatting(e.ColumnIndex, _poseCombinationGridView);
        }
    }
}
