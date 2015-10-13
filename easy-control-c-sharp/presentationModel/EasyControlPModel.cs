using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using easy_control_c_sharp.common;

namespace easy_control_c_sharp
{
    public partial class PresentationModel
    {
        // Mode method
        public BindingList<Mode> GetModeList()
        {
            return _model.GetModeList();
        }

        public Mode AddMode(string name)
        {
            return _model.AddMode(name);
        }

        public void RemoveMode(Mode mode)
        {
            _model.RemoveMode(mode);
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

        public void ProcessModeGridViewCell(int rowIndex, int columnIndex, PresentationModel presentationModel)
        {
            if (rowIndex >= 0)
            {
                Mode mode = presentationModel.GetModeByIndex(rowIndex);
                ModeDetail detailForm = new ModeDetail(presentationModel, mode);
                detailForm.Text = mode.Name;
                switch (columnIndex)
                {
                    // this is delete button, we add delete columns first, then format binding columns
                    // so delete button columns index while be 0, even we setting displayIndex is 2
                    case 0:
                        CloseModeDetailForm(mode);
                        RemoveMode(mode);
                        RemoveImage(mode.Name);
                        break;

                    case 3:
                        mode.IsEnable = !mode.IsEnable;
                        break;

                    default:
                        OpenModeDetailForm(mode, detailForm);
                        break;
                }
            }
        }

        private void OpenModeDetailForm(Mode mode, Form detailForm)
        {
            if (!mode.IsOpen)
            {
                OpenDetailForm(mode);
                detailForm.Show();
            }
            else
            {
                Form openedForm = ExistForm(mode);
                openedForm.Activate();
            }
        }

        // Detail Form method
        public Mode GetModeByIndex(int index)
        {
            return _model.GetModeByIndex(index);
        }

        public void OpenDetailForm(Mode mode)
        {
            mode.IsOpen = true;
        }

        private void CloseModeDetailForm(Mode mode)
        {
            Form openedForm = ExistForm(mode);
            if (openedForm != null)
                openedForm.Close();
        }

        private Form ExistForm(Mode mode)
        {
            FormCollection openForms = Application.OpenForms;
            foreach (Form form in openForms)
            {
                if (form.Text == mode.Name)
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
                Mode mode = AddMode(modeAddForm.GetModeName());
                mode.SetImage(ownImagePath);
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
