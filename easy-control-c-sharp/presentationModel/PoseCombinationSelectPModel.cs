using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using easy_control_c_sharp.common;

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
            if (editPoseCombination.GetIsContinue())
                poseCombination.SetIsContinue();
        }

        public void ProcessPosePictureBoxPaint(Graphics graphics, PoseCombination poseCombination)
        {
            if (poseCombination.GetPoseLength() != 0)
                graphics.DrawImage(poseCombination.GetPose(0).GetPoseImage(), 10, 260);
            for (int i = 1; i < poseCombination.GetPoseLength(); i++)
            {
                graphics.DrawString("+", new Font("Arial", 30), Brushes.SkyBlue, 110 * i - 25, 275);
                graphics.DrawImage(poseCombination.GetPose(i).GetPoseImage(), 10 + 110 * i, 260);
            }
        }

        public void ProcessKeyPictureBoxPaint(Graphics graphics, PoseCombination poseCombination, Dictionary<Rectangle, Key> keyBoard)
        {
            SolidBrush redBrush = new SolidBrush(Color.FromArgb(100, 255, 0, 0));
            SolidBrush greenBrush = new SolidBrush(Color.FromArgb(100, 0, 255, 0));
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 255));
            for (int i = 0; i < poseCombination.GetKeyLength(); i++)
            {
                Key key = poseCombination.GetKey(i);
                switch (key.GetKeyMode())
                {
                    //design by http://stackoverflow.com/questions/2444033/get-dictionary-key-by-value
                    case "press":
                        graphics.FillRectangle(redBrush, keyBoard.FirstOrDefault(x => x.Value.GetKeyName() == key.GetKeyName()).Key);
                        break;
                    case "hold":
                        graphics.FillRectangle(greenBrush, keyBoard.FirstOrDefault(x => x.Value.GetKeyName() == key.GetKeyName()).Key);
                        break;
                    case "release":
                        graphics.FillRectangle(blueBrush, keyBoard.FirstOrDefault(x => x.Value.GetKeyName() == key.GetKeyName()).Key);
                        break;
                }
            }
        }

        public void ProcessClickPosePictureBox(int locationX, int locationY, PoseCombination poseCombination, Dictionary<Rectangle, Pose> poseBoard)
        {
            foreach (Rectangle poseRect in poseBoard.Keys)
            {
                if (poseRect.Contains(locationX, locationY))
                {
                    poseCombination.TogglePose(poseBoard[poseRect]);
                }
            }
            for (int i = 0; i < poseCombination.GetPoseLength(); i++)
            {
                Rectangle select = new Rectangle(10 + 110 * i, 260, 75, 75);
                if (select.Contains(locationX, locationY))
                    poseCombination.RemovePoseByIndex(i);
            }
        }

        public void ProcessClickKeyPictureBox(int locationX, int locationY, PoseCombination poseCombination, Dictionary<Rectangle, Key> keyBoard)
        {
            foreach (Rectangle keyRect in keyBoard.Keys)
            {
                if (keyRect.Contains(locationX, locationY))
                {
                    OpenForm(keyBoard[keyRect], poseCombination);
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
                KeyMode keyMode = new KeyMode();
                DialogResult result = keyMode.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    key.SetKeyMode(keyMode.GetKeyMode());
                    poseCombination.ToggleKey(key);
                }
            }
        }

        public bool CheckPosesIsContinue(PoseCombination poseCombination)
        {
            if (poseCombination.CheckIsContinue())
                return true;
            else
            {
                if (poseCombination.GetIsContinue())
                    poseCombination.SetIsContinue();
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

        public void AddPoseCombination(Mode mode, PoseCombination poseCombination, bool isEdit, int editIndex)
        {
            if (isEdit)
            {
                mode.RemovePoseCombinationByIndex(editIndex);
                mode.InsertPoseCombination(editIndex, poseCombination);
            }
            else
                mode.AddPoseCombination(poseCombination);
        }
    }
}
