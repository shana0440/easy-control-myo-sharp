using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using WindowsInput;
using System.IO;

namespace easy_control_c_sharp
{
    public partial class PresentationModel
    {
        Model _model;
        private Dictionary<string, Image> _imageList = new Dictionary<string, Image>();
        private Dictionary<string, VirtualKeyCode> _keyMap = new Dictionary<string, VirtualKeyCode>();
        private Dictionary<Rectangle, string> _poseBoard = new Dictionary<Rectangle, string>();
        private Dictionary<Rectangle, Key> _keyBoard = new Dictionary<Rectangle, Key>();
        private CutImageMethod cutImageMethod = new CutImageMethod();

        public PresentationModel(Model model)
        {
            InitializePoseKeyDictionary();
            _model = model;
            List<Tuple<string, string>> imageList = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("fingersSpread", "Image/fingersSpread.png"),
                new Tuple<string, string>("waveOut", "Image/waveOut.png"),
                new Tuple<string, string>("waveIn", "Image/waveIn.png"),
                new Tuple<string, string>("fist", "Image/fist.png"),
                new Tuple<string, string>("keyboard", "Image/keyboard.png"),
            };

            foreach (Tuple<string, string> item in imageList)
            {
                AddImage(item.Item1, Image.FromFile(item.Item2));
            }

            Bitmap source = new Bitmap("Image/arm-device.png");
            List<Tuple<string, Rectangle>> sectionList = new List<Tuple<string, Rectangle>>
            {
                new Tuple<string, Rectangle>("rollUp", new Rectangle(0, 0, 230, 230)),
                new Tuple<string, Rectangle>("rollDown", new Rectangle(182, 0, 230, 230)),
                new Tuple<string, Rectangle>("pitchUp", new Rectangle(0, 182, 230, 230)),
                new Tuple<string, Rectangle>("pitchDown", new Rectangle(180, 180, 230, 230)),
                new Tuple<string, Rectangle>("yawUp", new Rectangle(0, 360, 230, 230)),
                new Tuple<string, Rectangle>("yawDown", new Rectangle(182, 360, 230, 230)),
            };

            foreach (Tuple<string, Rectangle> item in sectionList)
            {
                CutImage(item.Item1, source, item.Item2);
            }
        }

        //初始化所有Dictionary
        private void InitializePoseKeyDictionary()
        {
            //起始手勢
            _poseBoard.Add(new Rectangle(10, 35, 75, 75), "fingersSpread");
            _poseBoard.Add(new Rectangle(105, 35, 75, 75), "waveOut");
            _poseBoard.Add(new Rectangle(200, 35, 75, 75), "waveIn");
            _poseBoard.Add(new Rectangle(295, 35, 75, 75), "fist");
            //手臂運動
            _poseBoard.Add(new Rectangle(10, 150, 75, 75), "rollUp");
            _poseBoard.Add(new Rectangle(95, 150, 75, 75), "rollDown");
            _poseBoard.Add(new Rectangle(180, 150, 75, 75), "pitchUp");
            _poseBoard.Add(new Rectangle(265, 150, 75, 75), "pitchDown");
            _poseBoard.Add(new Rectangle(350, 150, 75, 75), "yawUp");
            _poseBoard.Add(new Rectangle(435, 150, 75, 75), "yawDown");
            //鍵盤第一列
            _keyMap.Add("Esc", VirtualKeyCode.ESCAPE);
            _keyMap.Add("`", VirtualKeyCode.OEM_3);
            _keyMap.Add("1", VirtualKeyCode.VK_1);
            _keyMap.Add("2", VirtualKeyCode.VK_2);
            _keyMap.Add("3", VirtualKeyCode.VK_3);
            _keyMap.Add("4", VirtualKeyCode.VK_4);
            _keyMap.Add("5", VirtualKeyCode.VK_5);
            _keyMap.Add("6", VirtualKeyCode.VK_6);
            _keyMap.Add("7", VirtualKeyCode.VK_7);
            _keyMap.Add("8", VirtualKeyCode.VK_8);
            _keyMap.Add("9", VirtualKeyCode.VK_9);
            _keyMap.Add("0", VirtualKeyCode.VK_0);
            _keyMap.Add("-", VirtualKeyCode.OEM_MINUS);
            _keyMap.Add("=", VirtualKeyCode.OEM_PLUS);
            _keyMap.Add("backspace", VirtualKeyCode.BACK);
            _keyMap.Add("Home", VirtualKeyCode.HOME);
            //鍵盤第二列
            _keyMap.Add("Tab", VirtualKeyCode.TAB);
            _keyMap.Add("Q", VirtualKeyCode.VK_Q);
            _keyMap.Add("W", VirtualKeyCode.VK_W);
            _keyMap.Add("E", VirtualKeyCode.VK_E);
            _keyMap.Add("R", VirtualKeyCode.VK_R);
            _keyMap.Add("T", VirtualKeyCode.VK_T);
            _keyMap.Add("Y", VirtualKeyCode.VK_Y);
            _keyMap.Add("U", VirtualKeyCode.VK_U);
            _keyMap.Add("I", VirtualKeyCode.VK_I);
            _keyMap.Add("O", VirtualKeyCode.VK_O);
            _keyMap.Add("P", VirtualKeyCode.VK_P);
            _keyMap.Add("[", VirtualKeyCode.OEM_4);
            _keyMap.Add("]", VirtualKeyCode.OEM_6);
            _keyMap.Add("\\", VirtualKeyCode.OEM_5);
            _keyMap.Add("Del", VirtualKeyCode.DELETE);
            _keyMap.Add("End", VirtualKeyCode.END);
            //鍵盤第三列
            _keyMap.Add("Caps", VirtualKeyCode.CAPITAL);
            _keyMap.Add("A", VirtualKeyCode.VK_A);
            _keyMap.Add("S", VirtualKeyCode.VK_S);
            _keyMap.Add("D", VirtualKeyCode.VK_D);
            _keyMap.Add("F", VirtualKeyCode.VK_F);
            _keyMap.Add("G", VirtualKeyCode.VK_G);
            _keyMap.Add("H", VirtualKeyCode.VK_H);
            _keyMap.Add("J", VirtualKeyCode.VK_J);
            _keyMap.Add("K", VirtualKeyCode.VK_K);
            _keyMap.Add("L", VirtualKeyCode.VK_L);
            _keyMap.Add(";", VirtualKeyCode.OEM_1);
            _keyMap.Add("'", VirtualKeyCode.OEM_7);
            _keyMap.Add("Enter", VirtualKeyCode.RETURN);
            _keyMap.Add("PgUp", VirtualKeyCode.PRIOR);
            //鍵盤第四列
            _keyMap.Add("Left Shift", VirtualKeyCode.LSHIFT);
            _keyMap.Add("Z", VirtualKeyCode.VK_Z);
            _keyMap.Add("X", VirtualKeyCode.VK_X);
            _keyMap.Add("C", VirtualKeyCode.VK_C);
            _keyMap.Add("V", VirtualKeyCode.VK_V);
            _keyMap.Add("B", VirtualKeyCode.VK_B);
            _keyMap.Add("N", VirtualKeyCode.VK_N);
            _keyMap.Add("M", VirtualKeyCode.VK_M);
            _keyMap.Add(",", VirtualKeyCode.OEM_COMMA);
            _keyMap.Add(".", VirtualKeyCode.OEM_PERIOD);
            _keyMap.Add("/", VirtualKeyCode.OEM_2);
            _keyMap.Add("Up", VirtualKeyCode.UP);
            _keyMap.Add("Right Shift", VirtualKeyCode.RSHIFT);
            _keyMap.Add("PgDn", VirtualKeyCode.NEXT);
            //鍵盤第五列
            _keyMap.Add("Fn", VirtualKeyCode.F5); //VirtualKeyCode隨便填，暫定F5
            _keyMap.Add("Left Ctrl", VirtualKeyCode.LCONTROL);
            _keyMap.Add("Windows", VirtualKeyCode.LWIN);
            _keyMap.Add("Left Alt", VirtualKeyCode.LMENU);
            _keyMap.Add("Space", VirtualKeyCode.SPACE);
            _keyMap.Add("Right Alt", VirtualKeyCode.RMENU);
            _keyMap.Add("Right Ctrl", VirtualKeyCode.RCONTROL);
            _keyMap.Add("Left", VirtualKeyCode.LEFT);
            _keyMap.Add("Down", VirtualKeyCode.DOWN);
            _keyMap.Add("Right", VirtualKeyCode.RIGHT);
            _keyMap.Add("Menu", VirtualKeyCode.MENU); //VirtualKeyCode不確定，先暫定MENU
            _keyMap.Add("Volumn Down", VirtualKeyCode.VOLUME_DOWN);
            _keyMap.Add("Volumn Up", VirtualKeyCode.VOLUME_UP);

            //鍵盤第一列
            _keyBoard.Add(new Rectangle(0, 3, 37, 32), new Key(VirtualKeyCode.ESCAPE, KeyStates.None));
            _keyBoard.Add(new Rectangle(37, 3, 37, 32), new Key(VirtualKeyCode.OEM_3, KeyStates.None));
            _keyBoard.Add(new Rectangle(74, 3, 37, 32), new Key(VirtualKeyCode.VK_1, KeyStates.None));
            _keyBoard.Add(new Rectangle(111, 3, 37, 32), new Key(VirtualKeyCode.VK_2, KeyStates.None));
            _keyBoard.Add(new Rectangle(148, 3, 37, 32), new Key(VirtualKeyCode.VK_3, KeyStates.None));
            _keyBoard.Add(new Rectangle(185, 3, 37, 32), new Key(VirtualKeyCode.VK_4, KeyStates.None));
            _keyBoard.Add(new Rectangle(222, 3, 37, 32), new Key(VirtualKeyCode.VK_5, KeyStates.None));
            _keyBoard.Add(new Rectangle(259, 3, 37, 32), new Key(VirtualKeyCode.VK_6, KeyStates.None));
            _keyBoard.Add(new Rectangle(296, 3, 37, 32), new Key(VirtualKeyCode.VK_7, KeyStates.None));
            _keyBoard.Add(new Rectangle(333, 3, 37, 32), new Key(VirtualKeyCode.VK_8, KeyStates.None));
            _keyBoard.Add(new Rectangle(370, 3, 37, 32), new Key(VirtualKeyCode.VK_9, KeyStates.None));
            _keyBoard.Add(new Rectangle(407, 3, 37, 32), new Key(VirtualKeyCode.VK_0, KeyStates.None));
            _keyBoard.Add(new Rectangle(444, 3, 37, 32), new Key(VirtualKeyCode.OEM_MINUS, KeyStates.None));
            _keyBoard.Add(new Rectangle(481, 3, 37, 32), new Key(VirtualKeyCode.OEM_PLUS, KeyStates.None));
            _keyBoard.Add(new Rectangle(518, 3, 57, 32), new Key(VirtualKeyCode.BACK, KeyStates.None));
            _keyBoard.Add(new Rectangle(575, 3, 67, 32), new Key(VirtualKeyCode.HOME, KeyStates.None));
            //鍵盤第二列
            _keyBoard.Add(new Rectangle(0, 35, 55, 35), new Key(VirtualKeyCode.TAB, KeyStates.None));
            _keyBoard.Add(new Rectangle(55, 35, 37, 35), new Key(VirtualKeyCode.VK_Q, KeyStates.None));
            _keyBoard.Add(new Rectangle(92, 35, 37, 35), new Key(VirtualKeyCode.VK_W, KeyStates.None));
            _keyBoard.Add(new Rectangle(129, 35, 37, 35), new Key(VirtualKeyCode.VK_E, KeyStates.None));
            _keyBoard.Add(new Rectangle(166, 35, 37, 35), new Key(VirtualKeyCode.VK_R, KeyStates.None));
            _keyBoard.Add(new Rectangle(203, 35, 37, 35), new Key(VirtualKeyCode.VK_T, KeyStates.None));
            _keyBoard.Add(new Rectangle(240, 35, 37, 35), new Key(VirtualKeyCode.VK_Y, KeyStates.None));
            _keyBoard.Add(new Rectangle(277, 35, 37, 35), new Key(VirtualKeyCode.VK_U, KeyStates.None));
            _keyBoard.Add(new Rectangle(314, 35, 37, 35), new Key(VirtualKeyCode.VK_I, KeyStates.None));
            _keyBoard.Add(new Rectangle(351, 35, 37, 35), new Key(VirtualKeyCode.VK_O, KeyStates.None));
            _keyBoard.Add(new Rectangle(388, 35, 37, 35), new Key(VirtualKeyCode.VK_P, KeyStates.None));
            _keyBoard.Add(new Rectangle(425, 35, 37, 35), new Key(VirtualKeyCode.OEM_4, KeyStates.None));
            _keyBoard.Add(new Rectangle(462, 35, 37, 35), new Key(VirtualKeyCode.OEM_6, KeyStates.None));
            _keyBoard.Add(new Rectangle(499, 35, 37, 35), new Key(VirtualKeyCode.OEM_5, KeyStates.None));
            _keyBoard.Add(new Rectangle(536, 35, 37, 35), new Key(VirtualKeyCode.DELETE, KeyStates.None));
            _keyBoard.Add(new Rectangle(575, 35, 67, 35), new Key(VirtualKeyCode.END, KeyStates.None));
            //鍵盤第三列
            _keyBoard.Add(new Rectangle(0, 70, 74, 35), new Key(VirtualKeyCode.CAPITAL, KeyStates.None));
            _keyBoard.Add(new Rectangle(74, 70, 37, 35), new Key(VirtualKeyCode.VK_A, KeyStates.None));
            _keyBoard.Add(new Rectangle(111, 70, 37, 35), new Key(VirtualKeyCode.VK_S, KeyStates.None));
            _keyBoard.Add(new Rectangle(148, 70, 37, 35), new Key(VirtualKeyCode.VK_D, KeyStates.None));
            _keyBoard.Add(new Rectangle(185, 70, 37, 35), new Key(VirtualKeyCode.VK_F, KeyStates.None));
            _keyBoard.Add(new Rectangle(221, 70, 37, 35), new Key(VirtualKeyCode.VK_G, KeyStates.None));
            _keyBoard.Add(new Rectangle(259, 70, 37, 35), new Key(VirtualKeyCode.VK_H, KeyStates.None));
            _keyBoard.Add(new Rectangle(296, 70, 37, 35), new Key(VirtualKeyCode.VK_J, KeyStates.None));
            _keyBoard.Add(new Rectangle(333, 70, 37, 35), new Key(VirtualKeyCode.VK_K, KeyStates.None));
            _keyBoard.Add(new Rectangle(370, 70, 37, 35), new Key(VirtualKeyCode.VK_L, KeyStates.None));
            _keyBoard.Add(new Rectangle(407, 70, 37, 35), new Key(VirtualKeyCode.OEM_1, KeyStates.None));
            _keyBoard.Add(new Rectangle(444, 70, 37, 35), new Key(VirtualKeyCode.OEM_7, KeyStates.None));
            _keyBoard.Add(new Rectangle(481, 70, 94, 35), new Key(VirtualKeyCode.RETURN, KeyStates.None));
            _keyBoard.Add(new Rectangle(575, 70, 67, 35), new Key(VirtualKeyCode.PRIOR, KeyStates.None));
            //鍵盤第四列
            _keyBoard.Add(new Rectangle(0, 104, 92, 35), new Key(VirtualKeyCode.LSHIFT, KeyStates.None));
            _keyBoard.Add(new Rectangle(92, 104, 37, 35), new Key(VirtualKeyCode.VK_Z, KeyStates.None));
            _keyBoard.Add(new Rectangle(129, 104, 37, 35), new Key(VirtualKeyCode.VK_X, KeyStates.None));
            _keyBoard.Add(new Rectangle(166, 104, 37, 35), new Key(VirtualKeyCode.VK_C, KeyStates.None));
            _keyBoard.Add(new Rectangle(203, 104, 37, 35), new Key(VirtualKeyCode.VK_V, KeyStates.None));
            _keyBoard.Add(new Rectangle(240, 104, 37, 35), new Key(VirtualKeyCode.VK_B, KeyStates.None));
            _keyBoard.Add(new Rectangle(277, 104, 37, 35), new Key(VirtualKeyCode.VK_N, KeyStates.None));
            _keyBoard.Add(new Rectangle(314, 104, 37, 35), new Key(VirtualKeyCode.VK_M, KeyStates.None));
            _keyBoard.Add(new Rectangle(351, 104, 37, 35), new Key(VirtualKeyCode.OEM_COMMA, KeyStates.None));
            _keyBoard.Add(new Rectangle(388, 104, 37, 35), new Key(VirtualKeyCode.OEM_PERIOD, KeyStates.None));
            _keyBoard.Add(new Rectangle(425, 104, 37, 35), new Key(VirtualKeyCode.OEM_2, KeyStates.None));
            _keyBoard.Add(new Rectangle(462, 104, 37, 35), new Key(VirtualKeyCode.UP, KeyStates.None));
            _keyBoard.Add(new Rectangle(500, 104, 75, 35), new Key(VirtualKeyCode.RSHIFT, KeyStates.None));
            _keyBoard.Add(new Rectangle(575, 104, 67, 35), new Key(VirtualKeyCode.NEXT, KeyStates.None));
            //鍵盤第五列
            _keyBoard.Add(new Rectangle(0, 138, 37, 35), new Key(VirtualKeyCode.F5, KeyStates.None)); //VirtualKeyCode隨便填，暫定F5
            _keyBoard.Add(new Rectangle(37, 138, 37, 35), new Key(VirtualKeyCode.LCONTROL, KeyStates.None));
            _keyBoard.Add(new Rectangle(74, 138, 37, 35), new Key(VirtualKeyCode.LWIN, KeyStates.None));
            _keyBoard.Add(new Rectangle(111, 138, 37, 35), new Key(VirtualKeyCode.LMENU, KeyStates.None));
            _keyBoard.Add(new Rectangle(148, 138, 204, 35), new Key(VirtualKeyCode.SPACE, KeyStates.None));
            _keyBoard.Add(new Rectangle(352, 138, 37, 35), new Key(VirtualKeyCode.RMENU, KeyStates.None));
            _keyBoard.Add(new Rectangle(389, 138, 37, 35), new Key(VirtualKeyCode.RCONTROL, KeyStates.None));
            _keyBoard.Add(new Rectangle(426, 138, 37, 35), new Key(VirtualKeyCode.LEFT, KeyStates.None));
            _keyBoard.Add(new Rectangle(463, 138, 37, 35), new Key(VirtualKeyCode.DOWN, KeyStates.None));
            _keyBoard.Add(new Rectangle(500, 138, 37, 35), new Key(VirtualKeyCode.RIGHT, KeyStates.None));
            _keyBoard.Add(new Rectangle(537, 138, 37, 35), new Key(VirtualKeyCode.MENU, KeyStates.None)); //VirtualKeyCode不確定，先暫定MENU
            _keyBoard.Add(new Rectangle(575, 138, 33, 35), new Key(VirtualKeyCode.VOLUME_DOWN, KeyStates.None));
            _keyBoard.Add(new Rectangle(609, 138, 33, 35), new Key(VirtualKeyCode.VOLUME_UP, KeyStates.None));
        }

        // Image method
        private bool AddImage(string name, Image path)
        {
            if (!IsImageExist(name))
            {
                _imageList.Add(name, path);
            }
            return !IsImageExist(name);
        }

        // Cut Image method
        private bool CutImage(string name, Bitmap source, Rectangle section)
        {
            if (!IsImageExist(name))
            {
                _imageList.Add(name, cutImageMethod.CutImage(source, section));
            }
            return !IsImageExist(name);
        }

        //取得UI圖片，可重設大小
        public Bitmap GetImage(string imageName, int width, int height)
        {
            Bitmap UIBitmap = new Bitmap(_imageList[imageName], width, height);
            return UIBitmap;
        }

        //檢查是否有某圖片存在
        public bool IsImageExist(string name)
        {
            return _imageList.ContainsKey(name);
        }

        //存檔處理
        public void easyControlSave(string file)
        {
            if (_model.GetWindowLength() == 0)
                return;
            XmlDocument save = new XmlDocument();
            XmlElement easy_control = save.CreateElement("easy-control");
            save.AppendChild(easy_control);
            foreach (Window window in _model.GetWindowList())
            {
                XmlElement win = save.CreateElement("window");
                win.SetAttribute("windowName", window.Name);
                win.SetAttribute("imagePath", window.GetImagePath());
                win.SetAttribute("isEnable", window.IsEnable.ToString());
                easy_control.AppendChild(win);
                foreach (PoseCombination poseCombination in window.GetPoseCollection())
                {
                    XmlElement poseCom = save.CreateElement("poseCombination");
                    poseCom.SetAttribute("isContinue", poseCombination.IsContinue.ToString());
                    poseCom.SetAttribute("isEnable", poseCombination.IsEnable.ToString());
                    win.AppendChild(poseCom);
                    //手勢組合
                    string poses = poseCombination.GetPose(0);
                    for (int i = 1; i < poseCombination.GetPoseLength(); i++)
                    {
                        poses += "+" + poseCombination.GetPose(i);
                    }
                    XmlElement pose = save.CreateElement("pose");
                    pose.InnerText = poses;
                    poseCom.AppendChild(pose);
                    //功能鍵
                    string keys = _keyMap.FirstOrDefault(x => x.Value == poseCombination.GetKey(0).Code).Key;
                    for (int i = 1; i < poseCombination.GetKeyLength(); i++)
                    {
                        keys += "+" + _keyMap.FirstOrDefault(x => x.Value == poseCombination.GetKey(i).Code).Key;
                    }
                    XmlElement key = save.CreateElement("key");
                    key.InnerText = keys;
                    poseCom.AppendChild(key);
                    string keyStatus = poseCombination.GetKey(0).State.ToString();
                    for (int i = 1; i < poseCombination.GetKeyLength(); i++)
                    {
                        keyStatus += "+" + poseCombination.GetKey(i).State.ToString();
                    }
                    XmlElement keystate = save.CreateElement("keyState");
                    keystate.InnerText = keyStatus;
                    poseCom.AppendChild(keystate);
                }
            }
            save.Save(file);
        }

        //讀檔處理
        public void easyControlLoad(string file)
        {
            if (!File.Exists(file))
                return;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            XmlNodeList windowNodeLists = xmlDoc.SelectNodes("easy-control/window");
            foreach (XmlNode windowNode in windowNodeLists)
            {
                string windowName = windowNode.Attributes["windowName"].Value;
                string imagePath = windowNode.Attributes["imagePath"].Value;
                string winIsEnable = windowNode.Attributes["isEnable"].Value;
                Window window = _model.AddWindow(windowName);
                window.SetImage(imagePath);
                if (winIsEnable == "True")
                    window.IsEnable = true;
                else
                    window.IsEnable = false;
                XmlNodeList poseCombinationNodeLists = windowNode.ChildNodes;
                foreach (XmlNode poseCombinationNode in poseCombinationNodeLists)
                {
                    PoseCombination poseCombination = new PoseCombination();

                    string poseCombinationIsContinue = poseCombinationNode.Attributes["isContinue"].Value;
                    string poseCombinationIsEnable = poseCombinationNode.Attributes["isEnable"].Value;
                    XmlNodeList poseKeyLists = poseCombinationNode.ChildNodes;
                    XmlNode poseNode = poseKeyLists.Item(0);
                    string poses = poseNode.InnerText;
                    XmlNode keyNode = poseKeyLists.Item(1);
                    string keys = keyNode.InnerText;
                    XmlNode keyStateNode = poseKeyLists.Item(2);
                    string keyStates = keyStateNode.InnerText;

                    if (poseCombinationIsContinue == "True")
                        poseCombination.IsContinue = true;
                    else
                        poseCombination.IsContinue = false;
                    if (poseCombinationIsEnable == "True")
                        poseCombination.IsEnable = true;
                    else
                        poseCombination.IsEnable = false;

                    string[] pose = poses.Split('+');
                    for (int i = 0; i < pose.Count(); i++)
                    {
                        poseCombination.AddPose(pose[i]);
                    }
                    string[] key = keys.Split('+');
                    string[] keyState = keyStates.Split('+');
                    for (int i = 0; i < key.Count(); i++)
                    {
                        switch (keyState[i])
                        {
                            case "Press":
                                poseCombination.AddKey(_keyMap[key[i]], KeyStates.Press);
                                break;
                            case "Hold":
                                poseCombination.AddKey(_keyMap[key[i]], KeyStates.Hold);
                                break;
                            case "Release":
                                poseCombination.AddKey(_keyMap[key[i]], KeyStates.Release);
                                break;
                            default:
                                break;

                        }
                    }
                    poseCombination.GetImage = GetPoseCombinationImage(poseCombination, 644, 172);
                    window.AddPoseCombination(poseCombination);
                }
            }
        }

        public void LockMyo()
        {
            _model.LockMyo();
        }
    }
}
