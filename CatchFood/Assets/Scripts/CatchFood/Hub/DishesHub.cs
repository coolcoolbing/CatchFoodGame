using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CatchFood
{
    public class DishesHub : MonoBehaviour
    {
        [Tooltip("选择菜品的滚动列表")]
        public GameObject selectDishScrollView; 

        [Tooltip("全部菜品的父物体，用来初始化hub上所有的菜品引用")]
        public GameObject dishesParent;

        [Tooltip("需要管理的全部菜品")]
        public Dish[] Dishes;

        public GameObject formulaPanel;   //显示菜品配方的面板
        public GameObject formulaPanelParent;   //显示菜品配方的面板的父物体
        public GameObject formulaIngredient;   //显示菜品配方的面板下的食材

        
        void Start()
        {
            InitializeAllDish();
        }

        /// <summary>
        /// 激活或者隐藏用于选择菜品的滚动框
        /// </summary>
        /// <param name="active"></param>
        public void SetActiveScrollView(bool active)
        {
            selectDishScrollView.SetActive(active);
        }

        /// <summary>
        /// 初始化所有的菜品
        /// </summary>
        public void InitializeAllDish()
        {
            Dishes = new Dish[dishesParent.transform.childCount];

            for (int i = 0; i < dishesParent.transform.childCount; i++)
            {
                Dish dish = dishesParent.transform.GetChild(i).GetComponent<Dish>();
                if (dish != null)
                {
                    Dishes[i] = dish;
                }
                else
                {
                    Debug.LogError("未能获得菜品对应的Dish组件!");
                }
            }

            foreach (var i in Dishes)
            {
                i.InitializeDish();
            }

            CreateFormulaPanel();
        }

        /// <summary>
        /// 给每一个菜品创建其对应的配方面板，上面显示它需要的各种食材和数量
        /// </summary>
        void CreateFormulaPanel()
        {
            foreach (var d in Dishes)
            {
                GameObject formulaPanelInstance = Instantiate(formulaPanel, formulaPanelParent.transform); //菜品作为生成的配方面板的父物体
                d.FormulaPanel = formulaPanelInstance;   //赋予菜品的配方面板
                for (int i = 0; i < d.ingredientsNeed.Length; i++)
                {
                    GameObject formulaIngredientInstance = Instantiate(formulaIngredient, formulaPanelInstance.transform);//生成的食材元素作为面板的子物体
                    formulaIngredientInstance.GetComponent<Image>().sprite = d.ingredientsNeed[i];
                    formulaIngredientInstance.transform.GetChild(0).GetComponent<Text>().text = "X" + d.ingredientsCountNeed[i];//显示这个食材需要的数量
                }
                formulaPanelInstance.SetActive(false);
            }
        }
    }
}
