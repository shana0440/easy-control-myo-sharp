using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace easy_control_UI
{
    public partial class PresentationModel
    {
        public void ProcessPoseCombinationGridViewCell(Mode mode, int rowIndex, int columnIndex, PresentationModel presentationModel)
        {
            if (rowIndex >= 0)
            {
                PoseCombinationSelect poseCombinationForm = new PoseCombinationSelect(presentationModel, mode, rowIndex);
                switch (columnIndex)
                {
                    // this is delete button, we add delete columns first, then format binding columns
                    // so delete button columns index while be 0, even we setting displayIndex is 1
                    case 0:
                        mode.RemovePoseCombinationByIndex(rowIndex);
                        break;

                    case 2:
                        mode.GetPoseCombination(rowIndex).IsEnable = !mode.GetPoseCombination(rowIndex).IsEnable;
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
