using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QianXuFrameWork;

namespace CatchFood
{
    public class Player : MonoBehaviour
    {
        [Tooltip("玩家的移动速度")]
        public int moveSpeed;

        public PlayerHub playerHub;
        /// <summary>
        /// 控制玩家移动
        /// </summary>
        void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(h * Time.fixedDeltaTime * moveSpeed, 0, 0));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Ingredient")
            {
                Destroy(collision.GetComponent<ingredient>());
                Destroy(collision.GetComponent<BoxCollider2D>());
                //collision.GetComponent<ingredient>().CancelInvoke();
                //collision.GetComponent<ingredient>().enabled = false;
                collision.transform.parent = this.transform;
                collision.transform.position= this.transform.position;

                playerHub.PostMessage(new BaseEvent(collision.name,playerHub));
            }
        }
    }
}
