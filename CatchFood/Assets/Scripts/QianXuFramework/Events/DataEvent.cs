using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QianXuFramework
{
    public class DataEvent : BaseEvent
    {
        public const string LOAD_CONFIG_DATA_OVER = "LOAD_CONFIG_DATA_OVER";
        public const string GERT_HQ_FROM_SERVER = "GERT_HQ_FROM_SERVER";

        public DataEvent(string inMsg, BaseManager inSender) : base(inMsg, inSender)
        {
            msgName = inMsg;
            sender = inSender;
        }
    }
}
