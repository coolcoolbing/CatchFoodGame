using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QianXuFramework;

namespace CatchFood
{
    /// <summary>
    /// 用于管理结算面板的相关功能
    /// </summary>
    public class SettlementHub : MonoBehaviour
    {
        public GameObject SettlementPanel;  //游戏结算的面板
        public Button restartBtn;
        public Button quitGameBtn;  //退出游戏的按钮

        [Tooltip("介绍菜品的历史背景")]
        public Text dishHistory;
        [Tooltip("显示菜品的图片")]
        public Image dishImage;


        [Tooltip("是否制作成功的文本")]
        public Text isSuccessText;

        private void Start()
        {
            //初始化按钮的监听事件
            restartBtn.onClick.AddListener(Restart);
            quitGameBtn.onClick.AddListener(QuitGame);
        }

        /// <summary>
        /// 重新开始.切换状态至最初的状态
        /// </summary>
        public void Restart()
        {
            GameStatus.GAME_STATUS = GameStatus.STATUS_CLEAN_UP;
        }

        /// <summary>
        /// 退出游戏
        /// </summary>
        private void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        /// <summary>
        /// 激活或者隐藏结算面板
        /// </summary>
        /// <param name="active"></param>
        public void SetActiveSettlementPanel(bool active)
        {
            SettlementPanel.SetActive(active);
        }

        /// <summary>
        /// 对玩家的游戏过程进行结算
        /// </summary>
        /// <param name="selectDish">玩家选择的菜品</param>
        /// <param name="catchCount">玩家游戏过程中接住的需要的食材的数量</param>
        public void StartSettlement(Dish selectDish,int[] catchCount)
        {
            if (selectDish == null) { Debug.LogWarning("没有选择菜品，所以结算面板为空");  return;   }
            //显示菜品的历史背景
            dishHistory.text = "\t-----"+selectDish.dishHistory;
            dishImage.sprite = selectDish.DishImage; //显示菜品的图片

            //bool isSuccess; //游戏是否成功
            for (int i = 0; i < catchCount.Length; i++)
            {
                if(catchCount[i]>= selectDish.ingredientsCountNeed[i]) //如果数量这个食材的数量足够则继续比对
                {
                    continue;
                }
                else //有一个食材不足够则失败
                {
                    isSuccessText.text = "制作菜品失败!再接再励";
                    return;
                    //break;
                }
            }
            isSuccessText.text = "制作成功!";
        }
    }
}
