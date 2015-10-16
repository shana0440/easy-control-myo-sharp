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
        public BindingList<Window> GetWindowList()
        {
            return _model.GetWindowList();
        }

        public Window AddWindow(string name)
        {
            return _model.AddWindow(name);
        }

        public void RemoveWindow(Window window)
        {
            _model.RemoveWindow(window);
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

        public void ProcessWindowGridViewCell(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0)
            {
                Window window = GetWindowByIndex(rowIndex);
                WindowDetail detailForm = new WindowDetail(this, window);
                detailForm.Text = window.Name;
                Console.WriteLine(columnIndex);
                switch (columnIndex)
                {
                    // this is delete button, we add delete columns first, then format binding columns
                    // so delete button columns index while be 0, even we setting displayIndex is 2
                    case 0:
                        CloseWindowDetailForm(window);
                        RemoveWindow(window);
                        RemoveImage(window.Name);
                        break;

                    case 1:

                        break;

                    case 4:
                        window.IsEnable = !window.IsEnable;
                        break;

                    default:
                        OpenWindowDetailForm(window, detailForm);
                        break;
                }
            }
        }

        private void OpenWindowDetailForm(Window window, Form detailForm)
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
        public Window GetWindowByIndex(int index)
        {
            return _model.GetWindowByIndex(index);
        }

        public void OpenDetailForm(Window window)
        {
            window.IsOpen = true;
        }

        private void CloseWindowDetailForm(Window window)
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

        public void ProcessAddForm(WindowAdd windowAddForm)
        {
            DialogResult result = windowAddForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string windowName = windowAddForm.GetWindowName();
                string[] fileName = windowAddForm.GetImageFile().Split('\\');
                string ownImagePath = "Image/" + fileName[fileName.Length - 1];
                if (!File.Exists(ownImagePath))
                    File.Copy(windowAddForm.GetImageFile(), ownImagePath);
                // if mode is exist, must pop alert
                Window window = AddWindow(windowAddForm.GetWindowName());
                window.SetImage(ownImagePath);
            }
        }

        public void ProcessWindowGridViewCellFormatting(int columnIndex, DataGridView windowGridView)
        {
            string columnName = windowGridView.Columns[columnIndex].Name;
            switch (columnName)
            {
                case "IsOpen":
                    windowGridView.Columns[columnIndex].Visible = false;
                    break;
                case "IsEnable":
                    windowGridView.Columns[columnIndex].Width = 50;
                    break;
                case "GetImage":
                    windowGridView.Columns[columnIndex].Width = 50;
                    break;
                case "deleteBtn":
                    windowGridView.Columns[columnIndex].Width = 50;
                    break;
                case "editBtn":
                    windowGridView.Columns[columnIndex].Width = 50;
                    break;
                default:
                    break;
            }
        }
    }
}
