using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QianXuFrameWork;

namespace CatchFood
{
    public class CatchFoodStartController : BaseController
    {

        public StartGameBtnHub startGameBtnHub;
        public DishesHub dishesHub;  //管理所有菜品的hub

        public override void ReceiveMessage(BaseEvent inMessage, BaseManager sender)
        {
            if (inMessage.msgName == "TRIGGER_GAME_START")
            {
                currentEvent = inMessage;
                currentSender = sender;
            }
        }

        public override void InitProcess()
        {
            Debug.Log("Init Process:" + this.name);

            //DO SOME INIT
            startGameBtnHub.SetActiveBtn(true);

            //JUMP TO MAIN GAME
            //GameStatus.GAME_STATUS = GameStatus.STATUS_GAME_READY;
            GameStatus.GAME_STATUS = GameStatus.STATUS_IDLE_LOOP;
        }

        public override void SelectionProcess()
        {
            dishesHub.SetActiveScrollView(true);
            Debug.Log("SelectionProcess");
            GameStatus.GAME_STATUS = GameStatus.STATUS_IDLE_LOOP;
        }

        public override void IdleLoop()
        {
            Debug.Log("Idle Process:" + this.name);

            if (currentEvent != null && currentEvent.msgName == "TRIGGER_GAME_START")
            {
                GameStatus.GAME_STATUS = GameStatus.STATUS_INIT;
            }

        }

        public override void IntroLoop()
        {

        }

        public override void SettingProcess()
        {
            dishesHub.SetActiveScrollView(false);
            startGameBtnHub.SetActiveBtn(false);
            startGameBtnHub.startGameBtn.transform.parent.gameObject.SetActive(false);

            Debug.Log("SettingProcess");
            GameStatus.GAME_STATUS = GameStatus.STATUS_GAME_READY;
        }
    }
}
