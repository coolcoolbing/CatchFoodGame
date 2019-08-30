using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QianXuFramework
{
    public class BaseController : BaseManager
    {
        public float tweenTime = 0.1f;
        protected float tick = 0.0f;

        protected BaseEvent currentEvent;
        protected BaseManager currentSender;

        //protected Dictionary<string, dynamic> funcMapping = new Dictionary<string, dynamic>();

        private void Start()
        {
            //funcMapping[GameStatus.STATUS_IDLE] = idleProcess();
        }

        // Update is called once per frame
        void Update()
        {
            //INIT,INTRO,SELECTION,SETTING,GAMING,GAME_PAUSE,GAME_END,CLENN_UP
            if (Time.time > tick)
            {
                //Debug.Log(gameObject.name + GameStatus.GAME_STATUS);
                if (GameStatus.GAME_STATUS == GameStatus.STATUS_IDLE_LOOP)
                {
                    IdleLoop();
                }
                else if (GameStatus.GAME_STATUS == GameStatus.STATUS_INIT)
                {
                    InitProcess();
                }
                else if (GameStatus.GAME_STATUS == GameStatus.STATUS_INTRO_LOOP)
                {
                    IntroLoop();
                }
                else if (GameStatus.GAME_STATUS == GameStatus.STATUS_SELECTION_LOOP)
                {
                    SelectionProcess();
                }
                else if (GameStatus.GAME_STATUS == GameStatus.STATUS_SETTING_LOOP)
                {
                    SettingProcess();
                }
                else if (GameStatus.GAME_STATUS == GameStatus.STATUS_GAME_READY)
                {
                    GameReadyProcess();
                }
                else if (GameStatus.GAME_STATUS == GameStatus.STATUS_GAME_LOOP)
                {
                    GamingLoop();
                }
                else if (GameStatus.GAME_STATUS == GameStatus.STATUS_GAME_PAUSE_READY)
                {
                    GamePauseProcess();
                }
                else if (GameStatus.GAME_STATUS == GameStatus.STATUS_GAME_EXIT)
                {
                    GameExitProcess();
                }
                else if (GameStatus.GAME_STATUS == GameStatus.STATUS_GAME_END_READY)
                {
                    GameEndReady();
                }
                else if (GameStatus.GAME_STATUS == GameStatus.STATUS_GAME_END_LOOP)
                {
                    GameEndLoop();
                }
                else if (GameStatus.GAME_STATUS == GameStatus.STATUS_CLEAN_UP)
                {
                    CleanUpProcess();
                }
                tick = Time.time + tweenTime;

                if (currentEvent != null)
                    currentEvent = null;

                if (currentSender != null)
                    currentSender = null;
            }
        }

        public virtual void IdleLoop() { }

        public virtual void InitProcess() { }

        public virtual void IntroLoop() { }

        public virtual void SelectionProcess() { }

        public virtual void SettingProcess() { }

        public virtual void GameReadyProcess() { }

        public virtual void GamingLoop() { }

        public virtual void GamePauseProcess() { }

        public virtual void GameExitProcess() { }

        public virtual void GameEndReady() { }

        public virtual void GameEndLoop() { }

        public virtual void CleanUpProcess() { }
    }

}
