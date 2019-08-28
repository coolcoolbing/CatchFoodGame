using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 食材的代理脚本
/// </summary>
public class ingredient : MonoBehaviour
{
    public float fallSpeed=15f;//下落速度
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * -1 * Time.fixedDeltaTime * fallSpeed);
    }
}
