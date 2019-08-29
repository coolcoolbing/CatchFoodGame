using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QianXuFrameWork
{
    public class KeyEvent : BaseEvent
    {
        public const string KEY_DOWN = "KEY_DOWN";
        public const string KEY_UP = "KEY_UP";
        public string keyValue = "";

        public KeyEvent(string inMsg, BaseManager inSender,string keyInfo) : base(inMsg, inSender)
        {
            msgName = inMsg;
            sender = inSender;
            keyValue = keyInfo;
        }
    }
}
