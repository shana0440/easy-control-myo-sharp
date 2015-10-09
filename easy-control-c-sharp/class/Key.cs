using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace easy_control_UI
{
    public class Key
    {
        private string _keyName;
        private string _keyMode;
        private byte _keyByte;
        public Key(string keyName, byte keyByte)
        {
            _keyName = keyName;
            _keyByte = keyByte;
            _keyMode = "";
        }

        //設定按鍵狀態
        public void SetKeyMode(string keyMode)
        {
            _keyMode = keyMode;
        }

        //回傳按鍵名稱
        public string GetKeyName()
        {
            return _keyName;
        }

        //回傳按鍵狀態
        public string GetKeyMode()
        {
            return _keyMode;
        }

        //回傳按鍵byte
        public byte GetKeyByte()
        {
            return _keyByte;
        }
    }
}
