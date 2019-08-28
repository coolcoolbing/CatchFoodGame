using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QianXuFramework
{
    public class CharacterEvent : BaseEvent
    {
        public CharacterEvent(string inMsg, BaseManager inSender) : base(inMsg, inSender)
        {
            msgName = inMsg;
            sender = inSender;
        }
    }
}
