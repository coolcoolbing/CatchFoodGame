using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using QianXuFramework;

namespace CatchFood
{
    public class CurrentUserDataHub : BaseHub
    {
        public GameObject[] gamingGameObejects;  //游戏过程过程中需要的全部元素
        public static Dish CurrentSelectDish { set;  get; }//记录当前玩家选择的菜品

        public GameObject currentIngredientNeedUIPrefab; //显示菜品需要的食材的ui
        public Transform showUIParent;  //显示食材的父物体

        public int[] currentIngredientCount; //当前配方食材的数量
        public int[] currentIngredientNeedCount; //当前配方食材需求的数量
        public string[] currentIngredientNeedName; //当前配方食材需求的名字
        public Text[] currentIngredientText;       //显示当前食材的数量清情况的text
        
        /// <summary>
        /// 激活所有GameLoop状态下需要的元素并初始化
        /// </summary>
        public void SetActiveTrue()
        {
            foreach(var g in gamingGameObejects)
            {
                g.SetActive(true);
            }

            ShowNeedIngredients();
        }

        /// <summary>
        /// 隐藏所有GameLoop状态下需要的元素并销毁一些游戏过程中临时生成的物体
        /// </summary>
        public void SetActiveFalse()
        {
            if (currentIngredientText != null)
            {
                foreach(var t in currentIngredientText)
                {
                    Destroy(t.transform.parent.gameObject);
                }
            }

            foreach (var g in gamingGameObejects)
            {
                g.SetActive(false);
            }
            //CurrentSelectDish = null;
            //currentIngredientCount = null;
            currentIngredientNeedCount =null; //当前配方食材需求的数量
            currentIngredientNeedName = null;
        }

        /// <summary>
        /// 接收玩家发过来的接住的食材的名字的消息
        /// </summary>
        /// <param name="inMessage"></param>
        /// <param name="sender"></param>
        public override void ReceiveMessage(BaseEvent inMessage, BaseManager sender)
        {
            print("接住了食物："+ inMessage.msgName);
            string food = inMessage.msgName;
            if (currentIngredientNeedName.Contains(food))//查找接住的食材是否是需要的食材
            {
                int i = Array.IndexOf(currentIngredientNeedName,food); //查找需要的食材在数组中的位置，并将相应位置的数量加1

                print(food+"所在的位置为"+i.ToString());

                if (i < 0) { i = -i;  }//返回的i有时候是负数，不懂为什么
                if(i>= currentIngredientCount.Length) { return;   }


                currentIngredientCount[i] ++;

                IsEnough(i);

                //刷新显示接住的食材数量
                UpdateShowIngredientsCurrent(i); // 更新显示接住的食材的数量
            }
        }

        /// <summary>
        /// 获得食材是否足够了，达到需求了，则文本变色
        /// </summary>
        private void IsEnough(int i)
        {
            if (currentIngredientCount[i]>=currentIngredientNeedCount[i]){
                if (currentIngredientText[i].color != Color.green)
                {
                    currentIngredientText[i].color = Color.green;
                }
            }
        }

        /// <summary>
        /// 在游戏过程中初始化显示当前选择的菜品所需要的食材
        /// </summary>
        public void ShowNeedIngredients()
        {
            if (CurrentUserDataHub.CurrentSelectDish == null)
            {
                Debug.LogError("你还没有选择菜品!");
            }
            else
            {
                //记录当前菜品需要的配方
                currentIngredientNeedCount = CurrentSelectDish.ingredientsCountNeed; //将菜品需要的数量记录下来
                currentIngredientCount = new int[currentIngredientNeedCount.Length];
                this.currentIngredientNeedName = CurrentSelectDish.IngredientsNeedName;
                currentIngredientText = new Text[currentIngredientNeedCount.Length];

                //显示当前菜品的配方
                for(int i=0;i< CurrentSelectDish.ingredientsNeed.Length; i++)
                {
                    var ingredientNeedSprite = CurrentSelectDish.ingredientsNeed[i];
                    GameObject g = Instantiate(currentIngredientNeedUIPrefab, showUIParent);
                    g.GetComponent<Image>().sprite = ingredientNeedSprite;
                    currentIngredientText[i] = g.transform.GetComponentInChildren<Text>();
                }

                ShowIngredientsCurrent();
            }
        }

        /// <summary>
        /// 更新显示接住的食材的文本
        /// </summary>
        /// <param name="i">接住的食材所在的数组的索引</param>
        private void UpdateShowIngredientsCurrent(int i)
        {
           currentIngredientText[i].text = currentIngredientCount[i] + "/" + currentIngredientNeedCount[i];
        }

        /// <summary>
        /// 初始化显示当前食材的数量
        /// </summary>
        private void ShowIngredientsCurrent()
        {
            for(int i=0;i<currentIngredientText.Length;i++)
            {
                currentIngredientText[i].text= currentIngredientCount[i]+"/"+currentIngredientNeedCount[i];
            }
        }
    }
}
