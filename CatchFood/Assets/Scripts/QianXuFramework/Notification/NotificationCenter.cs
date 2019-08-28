using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QianXuFramework
{
    public class NotificationCenter
    {
        public static List<BaseManager> ManagerList;

        public static void PostMessage(BaseEvent postMsg, BaseManager sender)
        {
            foreach (BaseManager baseManager in ManagerList)
            {
                baseManager.ReceiveMessage(postMsg, sender);
            }
        }
    }
}
