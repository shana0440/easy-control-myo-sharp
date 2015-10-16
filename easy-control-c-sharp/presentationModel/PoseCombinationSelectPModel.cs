using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace easy_control_c_sharp
{
    public partial class PresentationModel
    {
        public void ProcessInitailizePoseCombination(PoseCombination poseCombination, PoseCombination editPoseCombination)
        {
            for (int i = 0; i < editPoseCombination.GetPoseLength(); i++)
            {
                poseCombination.AddPose(editPoseCombination.GetPose(i));
            }
            for (int i = 0; i < editPoseCombination.GetKeyLength(); i++)
            {
                poseCombination.AddKey(editPoseCombination.GetKey(i));
            }
            poseCombination.IsContinue = editPoseCombination.IsContinue;
        }

        public void ProcessPosePictureBoxPaint(Graphics graphics, PoseCombination poseCombination)
        {
            if (poseCombination.GetPoseLength() != 0)
                graphics.DrawImage(GetImage(poseCombination.GetPose(0), 75, 75), 30, 260);
            for (int i = 1; i < poseCombination.GetPoseLength(); i++)
            {
                graphics.DrawString("+", new Font("微軟正黑體", 30), Brushes.SkyBlue, 110 * i - 10, 265);
                graphics.DrawImage(GetImage(poseCombination.GetPose(i), 75, 75), 30 + 110 * i, 260);
            }
        }

        public void ProcessKeyPictureBoxPaint(Graphics graphics, PoseCombination poseCombination)
        {
            SolidBrush redBrush = new SolidBrush(Color.FromArgb(100, 255, 0, 0));
            SolidBrush greenBrush = new SolidBrush(Color.FromArgb(100, 0, 255, 0));
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 255));
            for (int i = 0; i < poseCombination.GetKeyLength(); i++)
            {
                Key key = poseCombination.GetKey(i);
                switch (key.State)
                {
                    //design by http://stackoverflow.com/questions/2444033/get-dictionary-key-by-value
                    case KeyStates.Press:
                        graphics.FillRectangle(redBrush, _keyBoard.FirstOrDefault(x => x.Value.Code == key.Code).Key);
                        break;
                    case KeyStates.Hold:
                        graphics.FillRectangle(greenBrush, _keyBoard.FirstOrDefault(x => x.Value.Code == key.Code).Key);
                        break;
                    case KeyStates.Release:
                        graphics.FillRectangle(blueBrush, _keyBoard.FirstOrDefault(x => x.Value.Code == key.Code).Key);
                        break;
                }
            }
        }

        public void ProcessClickPosePictureBox(int locationX, int locationY, PoseCombination poseCombination)
        {
            foreach (Rectangle poseRect in _poseBoard.Keys)
            {
                if (poseRect.Contains(locationX, locationY))
                {
                    poseCombination.TogglePose(_poseBoard[poseRect]);
                }
            }
            for (int i = 0; i < poseCombination.GetPoseLength(); i++)
            {
                Rectangle select = new Rectangle(10 + 110 * i, 260, 75, 75);
                if (select.Contains(locationX, locationY))
                    poseCombination.RemovePose(i);
            }
        }

        public void ProcessClickKeyPictureBox(int locationX, int locationY, PoseCombination poseCombination)
        {
            foreach (Rectangle keyRect in _keyBoard.Keys)
            {
                if (keyRect.Contains(locationX, locationY))
                {
                    OpenForm(_keyBoard[keyRect], poseCombination);
                }
            }
        }

        private void OpenForm(Key key, PoseCombination poseCombination)
        {
            if (poseCombination.IsKeyExist(key))
            {
                poseCombination.ToggleKey(key);
            }
            else
            {
                KeyState keyMode = new KeyState();
                DialogResult result = keyMode.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    key.State = keyMode.GetKeyMode();
                    poseCombination.ToggleKey(key);
                }
            }
        }

        public bool CheckPosesIsContinue(PoseCombination poseCombination)
        {
            if (poseCombination.IsContinue)
                return true;
            else
            {
                if (poseCombination.IsContinue)
                    poseCombination.IsContinue = false;
                return false;
            }
        }

        public bool CheckPoseKeyExist(PoseCombination poseCombination)
        {
            if (poseCombination.CheckPose() && poseCombination.CheckKey())
                return true;
            else
                return false;
        }

        public Bitmap GetPoseCombinationImage(PoseCombination poseCombination, int keyBoardWidth, int keyBoardHeight)
        {
            Bitmap canvas = new Bitmap(300, 50);
            Graphics graphics = Graphics.FromImage(canvas);
            graphics.Clear(SystemColors.Control);
            if (poseCombination.GetPoseLength() != 0)
                graphics.DrawImage(GetImage(poseCombination.GetPose(0), 50, 50), 0, 0);
            for (int i = 1; i < poseCombination.GetPoseLength(); i++)
                graphics.DrawImage(GetImage(poseCombination.GetPose(i), 50, 50), 52 * i, 0);
            graphics.DrawString("➜", new Font("Arial", 27), Brushes.Black, poseCombination.GetPoseLength() * 50, 5);
            for (int i = 0; i < poseCombination.GetKeyLength(); i++)
            {
                Rectangle section = _keyBoard.FirstOrDefault(x => x.Value.Code == poseCombination.GetKey(i).Code).Key;
                Bitmap cutImage = cutImageMethod.CutImage(GetImage("keyboard", keyBoardWidth, keyBoardHeight), section);
                graphics.DrawImage(cutImage, (poseCombination.GetPoseLength() + i + 1) * 50, 7);
            }
            return canvas;
        }

        public void AddPoseCombination(Window window, PoseCombination poseCombination, bool isEdit, int editIndex)
        {
            if (isEdit)
            {
                window.RemovePoseCombinationByIndex(editIndex);
                window.InsertPoseCombination(editIndex, poseCombination);
            }
            else
                window.AddPoseCombination(poseCombination);
        }
    }
}
