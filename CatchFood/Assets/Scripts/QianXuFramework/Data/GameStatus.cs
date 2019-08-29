using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QianXuFrameWork
{
    public class GameStatus
    {
        public const string STATUS_INIT = "INIT";
        public const string STATUS_IDLE_LOOP = "IDLE_LOOP";
        public const string STATUS_INTRO_LOOP = "INTRO_LOOP";
        public const string STATUS_SELECTION_LOOP = "SELECTION_LOOP";
        public const string STATUS_SETTING_LOOP = "SETTING_LOOP";

        public const string STATUS_GAME_READY = "GAME_READY";
        public const string STATUS_GAME_LOOP = "GAME_LOOP";

        public const string STATUS_GAME_PAUSE_READY = "GAME_PAUSE_READY";
        public const string STATUS_GAME_PAUSE_LOOP = "GAME_PAUSE_LOOP";

        public const string STATUS_GAME_EXIT = "GAME_EXIT";

        public const string STATUS_GAME_END_READY = "GAME_END_READY";
        public const string STATUS_GAME_END_LOOP = "GAME_END_LOOP";

        public const string STATUS_CLEAN_UP = "CLEAN_UP";

        public static string GAME_STATUS = "";//INIT,INTRO,SELECTION,SETTING,GAMING,GAME_PAUSE,GAME_EXIT,GAME_END,CLENN_UP
    }
}
