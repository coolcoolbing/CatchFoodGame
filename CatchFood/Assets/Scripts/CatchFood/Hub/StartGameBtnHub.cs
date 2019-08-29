using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QianXuFrameWork;

namespace CatchFood
{
    public class StartGameBtnHub : MonoBehaviour
    {
        public Button startGameBtn;

        private void Start()
        {
            startGameBtn.onClick.AddListener(() => { GameStatus.GAME_STATUS = GameStatus.STATUS_SELECTION_LOOP; }); //点击开始按钮转换状态开始选择菜品
        }

        /// <summary>
        /// 激活或者隐藏开始按钮
        /// </summary>
        /// <param name="active"></param>
        public void SetActiveBtn(bool active)
        {
            startGameBtn.gameObject.SetActive(active);
        }
    }
}