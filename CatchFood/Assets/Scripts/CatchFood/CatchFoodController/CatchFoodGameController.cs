using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QianXuFramework;

namespace CatchFood
{
    public class CatchFoodGameController : BaseController
    {
        [Tooltip("设置游戏的时长(秒)")]
        public int gameDuration=60;

        public CountDownHub countDownHub;                //控制倒计时的hub           
        public CreateIngredientHub createIngredientHub;  //控制生成掉落食材的hub
        public CurrentUserDataHub currentUserDataHub;    //记录有当前游戏过程中的信息的hub
        public PlayMusicHub playMusicHub;                //控制播放背景音乐的hub

        public override void GameReadyProcess()
        {
            //Debug.Log(" GameReadyProcess" + this.name);

            playMusicHub.StopMusic();        //停止游戏音乐
            playMusicHub.PlayMusic("Game");  //播放游戏音乐

            currentUserDataHub.SetActiveTrue();  //显示所有游戏过程需要的元素

            countDownHub.countDownTime = gameDuration;  //设置倒计时的时间
            countDownHub.StartCountDown();              //开始倒计时的显示
            Invoke("GameEndTrigger", gameDuration);     //触发多少秒后游戏结束

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
        private void GameEndTrigger()
        {
            createIngredientHub.DestroyAllFallingIngredients(); //游戏结束时销毁所有还在下落的食材
            currentUserDataHub.SetActiveFalse();                //隐藏所有游戏过程需要的元素
            playMusicHub.StopMusic();                           //停止游戏音乐

            GameStatus.GAME_STATUS = GameStatus.STATUS_GAME_END_READY;
        }
    }
}
