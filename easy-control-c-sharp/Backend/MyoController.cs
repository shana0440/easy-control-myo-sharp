﻿using System;
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

namespace easy_control_c_sharp
{
    public class MyoController
    {
        private IChannel _myoChannel;
        private IHub _myoHub;
        private bool _onReceive = false;
        private bool _isLock = false;
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
        }

        private void MyoConnected(object sender, MyoEventArgs e)
        {
            Console.WriteLine("Myo Connented!!");
            e.Myo.Unlock(UnlockType.Hold);
            e.Myo.PoseChanged += OnPose;
            e.Myo.OrientationDataAcquired += OnOrientationData;
            e.Myo.Locked += OnLocked;
            e.Myo.Unlocked += OnUnlocked;
            //e.Myo.EmgDataAcquired += OnEmgData;
            //e.Myo.SetEmgStreaming(true);
        }

        private void MyoDisconnected(object sender, MyoEventArgs e)
        {
            Console.WriteLine("Myo Disconnented!!");
            e.Myo.PoseChanged -= OnPose;
            e.Myo.OrientationDataAcquired -= OnOrientationData;
            e.Myo.Locked -= OnLocked;
            e.Myo.Unlocked -= OnUnlocked;
            //e.Myo.EmgDataAcquired -= OnEmgData;
            //e.Myo.SetEmgStreaming(false);
        }

        private void OnLocked(object sender, MyoEventArgs e)
        {
            _isLock = true;
            Console.WriteLine("Myo Locked");
        }

        private void OnUnlocked(object sender, MyoEventArgs e)
        {
            _isLock = false;
            e.Myo.Unlock(UnlockType.Hold);
            Console.WriteLine("Myo UnLocked");
        }

        private void OnPose(object sender, PoseEventArgs e)
        {
            if (e.Myo.Pose == Pose.DoubleTap)
            {
                // use doubletap trigger myo lock
                if (_isLock)
                    e.Myo.Unlock(UnlockType.Hold);
                else
                    e.Myo.Lock();
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
            if (_onReceive)
            {
                _orientation.PushQuat(e.Roll, e.Pitch, e.Yaw);
                if (_orientation.BufferFull)
                {
                    string dir = _orientation.GetArmDirection();
                    _orientation.ClearBuffer();

                    if (dir != "")
                        ReceivePose(dir);
                }
            }
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
            _poseManager.SetFocusWindow(selectedWindowTitle);
            Console.WriteLine("focus on {0} window!", selectedWindowTitle);
            Console.WriteLine("Start receive!");
        }

        public void ReceiveOver()
        {
            _onReceive = false;
            _poseManager.ReceiveOver();
            _orientation.ClearBuffer();
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
