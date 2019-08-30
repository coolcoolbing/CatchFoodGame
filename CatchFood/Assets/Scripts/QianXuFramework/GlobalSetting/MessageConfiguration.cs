using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QianXuFramework
{
    public class MessageConfiguration : MonoBehaviour
    {
        public BaseManager[] hubList;
        public BaseManager[] controllerList;

        void Awake()
        {
            if (NotificationCenter.ManagerList != null)
            {
                NotificationCenter.ManagerList.Clear();
            }
            else
            {
                NotificationCenter.ManagerList = new List<BaseManager>();
            }

            for (int i = 0; i < hubList.Length; i++)
            {
                if (hubList[i] != null)
                    NotificationCenter.ManagerList.Add(hubList[i]);
            }

            for (int i = 0; i < controllerList.Length; i++)
            {
                if (controllerList[i] != null)
                    NotificationCenter.ManagerList.Add(controllerList[i]);
            }
        }
    }
}
