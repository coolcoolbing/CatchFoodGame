using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 用于记录一个菜的各种属性的类
/// </summary>
public class Dish : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip("这个菜的名字(根据传入菜品的图片自动赋值)")]
    public string dishName;  //这个菜的名字

    [Tooltip("这道菜需要的配方食材")]
    public Sprite[] ingredientsNeed;   //这道菜需要的食材

    [Tooltip("每种食材需要的数量")]
    public int[] ingredientsCountNeed;   //每种食材需要的数量

    [Tooltip("制作这个菜品的星级难度")]
    [Range(0,5)]public int star;

    public string[] IngredientsNeedName { get; private set; }  //对外开放的需要的食材的名字
    public GameObject FormulaPanel { private get; set; }  //该菜品对应的配方面板
    /// <summary>
    /// 初始化菜品的各项参数，提供给DishesHub调用
    /// </summary>
    public void InitializeDish()
    {
        InitializeDishName();
        InitializeDishFormula();
        InitializeDishShowStar();
    }

    /// <summary>
    /// 根据传入菜品的图片的初始化这道菜的名字
    /// </summary>
    void InitializeDishName()
    {
        //根据给的图片初始化名字
        Sprite s = this.GetComponent<UnityEngine.UI.Image>().sprite;
        if (s)
        {
            dishName = s.name;  //获得图片的名字
            this.name = s.name;
        }
    }

    /// <summary>
    /// 根据给的配方食材的图片初始化配方的名字
    /// </summary>
    void InitializeDishFormula()
    {
        //根据给的需要的配方食材的图片初始化配方的名字
        IngredientsNeedName = new string[ingredientsNeed.Length];
        for (int i = 0; i < IngredientsNeedName.Length; i++)
        {
            if (ingredientsNeed[i] == null) { Debug.LogError(this.name + "菜品配方的图片不能为空！"); break; }
            IngredientsNeedName[i] = ingredientsNeed[i].name;
        }
    }

    /// <summary>
    /// 初始化显示菜品所拥有的星级难度
    /// </summary>
    void InitializeDishShowStar()
    {
        //激活显示对应的星星图片
        for(int i=0;i< star; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);   
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (FormulaPanel) { FormulaPanel.SetActive(true);  }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (FormulaPanel) { FormulaPanel.SetActive(false); }
    }
}
