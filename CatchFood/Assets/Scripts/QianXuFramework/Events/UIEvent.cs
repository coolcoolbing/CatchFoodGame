using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QianXuFrameWork
{
    public class UIEvent : BaseEvent
    {
        public const string TRIGGER_GAME_START = "TRIGGER_GAME_START";

        public UIEvent(string inMsg, BaseManager inSender) : base(inMsg, inSender)
        {
            msgName = inMsg;
            sender = inSender;
        }
    }
}
