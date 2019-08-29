using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QianXuFrameWork;

namespace CatchFood
{
    public class PlayerHub : BaseHub
    {
        public GameObject Player;
        public int moveSpeed;

        private Transform playerTransform; //直接拿组件，减少性能消耗

        void Start()
        {
            playerTransform = Player.transform;
        }

        public override void PostMessage(BaseEvent outMessage)
        {
           NotificationCenter.PostMessage(outMessage,this);
        }
        /*
        /// <summary>
        /// 控制玩家移动
        /// </summary>
        void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            playerTransform.Translate(new Vector3(h * Time.fixedDeltaTime * moveSpeed, 0, 0));
        }*/
    }
}