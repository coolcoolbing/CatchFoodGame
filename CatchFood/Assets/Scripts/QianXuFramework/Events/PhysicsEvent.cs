using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QianXuFramework
{
    public class PhysicsEvent : BaseEvent
    {
        public PhysicsEvent(string inMsg, BaseManager inSender) : base(inMsg, inSender)
        {
            msgName = inMsg;
            sender = inSender;
        }
    }
}
