using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyoSharp.Poses;
using MyoSharp.Communication;
using MyoSharp.Device;
using MyoSharp.Exceptions;
using System.Runtime.InteropServices; // use DllImport
using WindowsInput;
using easy_control_c_sharp.common;

namespace easy_control_c_sharp.backend
{
    public class MyoController
    {
        private IChannel _myoChannel;
        private IHub _myoHub;
        private bool _onReceive = false;
        //private bool _isLock = false;
        private PoseManager _poseManager;
        private Orientation _orientation = new Orientation();
        
        public MyoController(PoseManager poseManager)
        {
            _poseManager = poseManager;
            try
            {
                _myoChannel = Channel.Create(
                    ChannelDriver.Create(
                        ChannelBridge.Create(),
                        MyoErrorHandlerDriver.Create(
                            MyoErrorHandlerBridge.Create()
                        )
                    ));
                _myoHub = Hub.Create(_myoChannel);
                _myoHub.MyoConnected += new EventHandler<MyoEventArgs>(MyoConnected);
                _myoHub.MyoDisconnected += new EventHandler<MyoEventArgs>(MyoDisconnected);
                _myoChannel.StartListening();
            }
            catch (Exception)
            {
                throw new Exception("Unable to find a Myo!");
            }
            AddDefaultPose();
        }

        private void AddDefaultPose()
        {
            Window foobar2000 = new Window("youtube");
            PoseCombination pose1 = new PoseCombination();
            pose1.AddPose("FingersSpread");
            pose1.AddKey(VirtualKeyCode.SPACE, KeyStates.Press);

            PoseCombination pose2 = new PoseCombination();
            pose2.AddPose("fist");
            pose2.AddPose("pitchUp");
            pose2.IsContiue = true;
            pose2.AddKey(VirtualKeyCode.NEXT, KeyStates.Press);

            PoseCombination pose3 = new PoseCombination();
            pose3.AddPose("fist");
            pose3.AddPose("pitchDown");
            pose3.IsContiue = true;
            pose3.AddKey(VirtualKeyCode.PRIOR, KeyStates.Press);

            foobar2000.AddPoseCombination(pose1);
            foobar2000.AddPoseCombination(pose2);
            foobar2000.AddPoseCombination(pose3);
            _poseManager.AddWindow(foobar2000);
        }

        private void MyoConnected(object sender, MyoEventArgs e)
        {
            Console.WriteLine("Myo Connented!!");
            e.Myo.Unlock(UnlockType.Hold);
            e.Myo.PoseChanged += OnPose;
            e.Myo.OrientationDataAcquired += OnOrientationData;
            //e.Myo.Locked += OnLocked;
            //e.Myo.Unlocked += OnUnlocked;
            //e.Myo.EmgDataAcquired += OnEmgData;
            //e.Myo.SetEmgStreaming(true);
        }

        private void MyoDisconnected(object sender, MyoEventArgs e)
        {
            Console.WriteLine("Myo Disconnented!!");
            e.Myo.PoseChanged -= OnPose;
            e.Myo.OrientationDataAcquired -= OnOrientationData;
            //e.Myo.Locked -= OnLocked;
            //e.Myo.Unlocked -= OnUnlocked;
            //e.Myo.EmgDataAcquired -= OnEmgData;
            //e.Myo.SetEmgStreaming(false);
        }

        private void OnPose(object sender, PoseEventArgs e)
        {
            if (e.Myo.Pose == Pose.DoubleTap)
            {
                // use doubletap trigger myo lock
                e.Myo.Unlock(UnlockType.Hold);
            }
            else if (e.Myo.Pose == Pose.Rest)
            {
                ReceiveOver();
            }
            else
            {
                if (!_onReceive)
                {
                    ReceiveStart();
                }
                ReceivePose(e.Pose.ToString());
            }
        }

        private void OnOrientationData(object sender, OrientationDataEventArgs e)
        {
            const float PI = (float)System.Math.PI;

            // convert the values to a 0-9 scale (for easier digestion/understanding)
            var roll = (int)((e.Roll + PI) / (PI * 2.0f) * 10);
            var pitch = (int)((e.Pitch + PI) / (PI * 2.0f) * 10);
            var yaw = (int)((e.Yaw + PI) / (PI * 2.0f) * 10);
            
        }

        private void ReceivePose(string pose)
        {
            if (_onReceive)
            {
                _poseManager.FilterPose(pose);
                Console.WriteLine("Detected {0} pose!", pose);
            }
        }

        public void ReceiveStart()
        {
            _onReceive = true;
            IntPtr selectedWindow = GetForegroundWindow();
            string selectedWindowTitle = GetWindowTitle(selectedWindow, IntPtr.Zero);
            _poseManager.SetFocussWindow(selectedWindowTitle);
            Console.WriteLine("focus on {0} window!", selectedWindowTitle);
            Console.WriteLine("Start receive!");
        }

        public void ReceiveOver()
        {
            _onReceive = false;
            _poseManager.ReceiveOver();
            Console.WriteLine("Receive over!");
        }

        private string GetWindowTitle(IntPtr hWnd, IntPtr lParam)
        {
            var sb = new StringBuilder(255);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpText, int nCount);
    }
}
