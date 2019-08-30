using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QianXuFramework
{
    public class BaseManager : MonoBehaviour
    {
        public virtual void ReceiveMessage(BaseEvent inMessage, BaseManager sender)
        {
            //Debug.Log(this.name + "," + inMessage.msgName + "," + sender.name);
        }

        public virtual void PostMessage(BaseEvent outMessage)
        {
            NotificationCenter.PostMessage(outMessage, this);
        }
    }
}
