using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace easy_control_c_sharp
{
    public partial class PresentationModel
    {
        public void ProcessPoseCombinationGridViewCell(Window window, int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0)
            {
                PoseCombinationSelect poseCombinationForm = new PoseCombinationSelect(this, window, rowIndex);
                switch (columnIndex)
                {
                    // this is delete button, we add delete columns first, then format binding columns
                    // so delete button columns index while be 0, even we setting displayIndex is 1
                    case 0:
                        window.RemovePoseCombinationByIndex(rowIndex);
                        break;

                    case 4:
                        window.GetPoseCombination(rowIndex).IsEnable = !window.GetPoseCombination(rowIndex).IsEnable;
                        break;

                    default:
                        poseCombinationForm.ShowDialog();
                        break;
                }
            }
        }

        public void ProcessPoseCombinationGridViewCellFormatting(int columnIndex, DataGridView poseCombinationGridView)
        {
            string columnName = poseCombinationGridView.Columns[columnIndex].Name;
            switch (columnName)
            {
                //case "IsCompleted":
                //    poseCombinationGridView.Columns[columnIndex].Visible = false;
                //    break;
                //case "IsContinue":
                //    poseCombinationGridView.Columns[columnIndex].Visible = false;
                //    break;
                case "IsEnable":
                    poseCombinationGridView.Columns[columnIndex].Width = 50;
                    break;
                case "deleteBtn":
                    poseCombinationGridView.Columns[columnIndex].Width = 50;
                    break;
                default:
                    break;
            }
        }
    }
}
