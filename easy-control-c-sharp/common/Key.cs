using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace easy_control_c_sharp.common
{
    public class Key
    {
        private KeyStates _state;
        private VirtualKeyCode _code;

        public Key(VirtualKeyCode code, KeyStates state)
        {
            _state = state;
            _code = code;
        }

        public KeyStates State
        {
            get { return _state; }
            set { _state = value; }
        }

        public VirtualKeyCode Code
        {
            get { return _code; }
            set { _code = value; }
        }

    }
}
