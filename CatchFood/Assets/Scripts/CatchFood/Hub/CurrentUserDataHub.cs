using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentUserDataHub : MonoBehaviour
{
    public static Dish CurrentSelectDish { set; private get; }//记录当前玩家选择的菜品

    public GameObject currentIngredientNeedUIPrefab; //显示菜品需要的食材的ui
    public Transform showUIParent;  //显示食材的父物体
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 在游戏过程中显示当前选择的菜品所需要的食材
    /// </summary>
    void ShowNeedIngredients()
    {
        if (CurrentUserDataHub.CurrentSelectDish == null)
        {
            Debug.LogError("你还没有选择菜品!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
