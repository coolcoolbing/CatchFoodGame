using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QianXuFramework
{
    public class BaseEvent
    {
        public string msgName = "";
        public BaseManager sender;

        public BaseEvent(string inMsg, BaseManager inSender)
        {
            msgName = inMsg;
            sender = inSender;
        }
    }
}
