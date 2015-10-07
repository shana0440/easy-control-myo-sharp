using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyoSharp.Poses;
using MyoSharp.Communication;
using MyoSharp.Device;
using MyoSharp.Exceptions;

namespace easy_control_c_sharp
{
    public class MyoController
    {
        IChannel _myoChannel;
        IHub _myoHub;
        bool _onReceive = false;
        bool _isLock = false;
        
        public MyoController()
        {
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
                _onReceive = false;
                Console.WriteLine("Receive over!");
            }
            else
            {
                if (!_onReceive)
                {
                    _onReceive = true;
                    Console.WriteLine("Start receive!");
                }
                ReceivePose(e.Pose.ToString());
            }
            Console.WriteLine("Detected {0} pose!", e.Pose);
        }

        private void OnOrientationData(object sender, OrientationDataEventArgs e)
        {
            //if (counter > 1)
            //{
            //    counter = 0;
            //    WriteMessage(String.Format("Roll: {0}", e.Roll));
            //    WriteMessage(String.Format("Pitch: {0}", e.Pitch));
            //    WriteMessage(String.Format("Yaw: {0}", e.Yaw));
            //}
        }

        private void ReceivePose(string pose)
        {
            if (_onReceive)
            {

            }
        }
    }
}
