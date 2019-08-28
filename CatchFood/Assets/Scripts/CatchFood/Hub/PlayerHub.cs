using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHub : MonoBehaviour
{
    public GameObject Player;
    public int moveSpeed;

    private Transform playerTransform; //直接拿组件，减少性能消耗
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = Player.transform;
    }

    /// <summary>
    /// 控制玩家移动
    /// </summary>
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        playerTransform.Translate(new Vector3(h * Time.fixedDeltaTime * moveSpeed, 0, 0));
    }
}
