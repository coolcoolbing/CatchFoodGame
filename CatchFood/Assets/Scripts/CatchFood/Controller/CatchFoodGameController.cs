using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QianXuFrameWork;

namespace CatchFood
{
    public class CatchFoodGameController : BaseController
    {
        [Tooltip("设置游戏的时长(秒)")]public int gameDuration=60;
        public CreateIngredientHub createIngredientHub;  //生成掉落食材的hub
        public CurrentUserDataHub currentUserDataHub;

        public override void GameReadyProcess()
        {
            Debug.Log(" GameReadyProcess" + this.name);

            currentUserDataHub.SetActiveTrue();

            Invoke("GameEnd", gameDuration);

            GameStatus.GAME_STATUS = GameStatus.STATUS_GAME_PAUSE_READY;
        }

        public override void GamingLoop()
        {
            //Debug.Log("Gaming Process" + this.name);

            createIngredientHub.CreateIngredient(); //生成食材

        }

        public override void GamePauseProcess()
        {
            GameStatus.GAME_STATUS = GameStatus.STATUS_GAME_LOOP;
        }

        /// <summary>
        /// 经过设置的游戏时长后停止游戏
        /// </summary>
        private void GameEnd()
        {
            GameStatus.GAME_STATUS = GameStatus.STATUS_GAME_END_READY;
        }
    }
}
