using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatchFood
{
    /// <summary>
    /// 食材的代理脚本
    /// </summary>
    public class ingredient : MonoBehaviour
    {
        public float fallSpeed = 15f;//下落速度
                                     // Start is called before the first frame update
        void Start()
        {
            Invoke("DestroyThis", 6);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            transform.Translate(Vector3.up * -1 * Time.fixedDeltaTime * fallSpeed);
        }

        void DestroyThis()
        {
            Destroy(this.gameObject);
        }
    }
}