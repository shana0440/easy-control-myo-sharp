using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace easy_control_c_sharp
{
    public partial class PresentationModel
    {
        // Mode method
        public BindingList<Window> GetModeList()
        {
            return _model.GetModeList();
        }

        public Window AddMode(string name)
        {
            return _model.AddMode(name);
        }

        public void RemoveMode(Window window)
        {
            _model.RemoveMode(window);
        }

        public void ProcessResizeForm(FormWindowState winState)
        {
            if (winState == FormWindowState.Minimized)
            {
                FormCollection openForms = Application.OpenForms;
                foreach (Form openForm in openForms)
                    openForm.Hide();
            }
        }

        public void ProcessShowForm()
        {
            FormCollection openForms = Application.OpenForms;
            foreach (Form openForm in openForms)
            {
                openForm.Visible = true;
                openForm.WindowState = FormWindowState.Normal;
            }
        }

        public void ProcessModeGridViewCell(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0)
            {
                Window window = GetModeByIndex(rowIndex);
                ModeDetail detailForm = new ModeDetail(this, window);
                detailForm.Text = window.Name;
                switch (columnIndex)
                {
                    // this is delete button, we add delete columns first, then format binding columns
                    // so delete button columns index while be 0, even we setting displayIndex is 2
                    case 0:
                        CloseModeDetailForm(window);
                        RemoveMode(window);
                        RemoveImage(window.Name);
                        break;

                    case 3:
                        window.IsEnable = !window.IsEnable;
                        break;

                    default:
                        OpenModeDetailForm(window, detailForm);
                        break;
                }
            }
        }

        private void OpenModeDetailForm(Window window, Form detailForm)
        {
            if (!window.IsOpen)
            {
                OpenDetailForm(window);
                detailForm.Show();
            }
            else
            {
                Form openedForm = ExistForm(window);
                openedForm.Activate();
            }
        }

        // Detail Form method
        public Window GetModeByIndex(int index)
        {
            return _model.GetModeByIndex(index);
        }

        public void OpenDetailForm(Window window)
        {
            window.IsOpen = true;
        }

        private void CloseModeDetailForm(Window window)
        {
            Form openedForm = ExistForm(window);
            if (openedForm != null)
                openedForm.Close();
        }

        private Form ExistForm(Window window)
        {
            FormCollection openForms = Application.OpenForms;
            foreach (Form form in openForms)
            {
                if (form.Text == window.Name)
                {
                    return form;
                }
            }
            return null;
        }

        public void ProcessAddForm(ModeAdd modeAddForm)
        {
            DialogResult result = modeAddForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string modeName = modeAddForm.GetModeName();
                string[] fileName = modeAddForm.GetImageFile().Split('\\');
                string ownImagePath = "Image/" + fileName[fileName.Length - 1];
                if (!File.Exists(ownImagePath))
                    File.Copy(modeAddForm.GetImageFile(), ownImagePath);
                // if mode is exist, must pop alert
                Window window = AddMode(modeAddForm.GetModeName());
                window.SetImage(ownImagePath);
            }
        }

        public void ProcessModeGridViewCellFormatting(int columnIndex, DataGridView modeGridView)
        {
            string columnName = modeGridView.Columns[columnIndex].Name;
            switch (columnName)
            {
                case "IsOpen":
                    modeGridView.Columns[columnIndex].Visible = false;
                    break;
                case "IsEnable":
                    modeGridView.Columns[columnIndex].Width = 50;
                    break;
                case "GetImage":
                    modeGridView.Columns[columnIndex].Width = 50;
                    break;
                case "deleteBtn":
                    modeGridView.Columns[columnIndex].Width = 50;
                    break;
                default:
                    break;
            }
        }
    }
}
