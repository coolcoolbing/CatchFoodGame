using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QianXuFramework
{
    public class StartController : BaseController
    {

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




            //JUMP TO MAIN GAME
            GameStatus.GAME_STATUS = GameStatus.STATUS_GAME_READY;

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

        public override void SelectionProcess()
        {

        }

        public override void SettingProcess()
        {

        }
    }
}
