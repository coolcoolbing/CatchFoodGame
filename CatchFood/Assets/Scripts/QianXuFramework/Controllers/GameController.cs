using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QianXuFramework
{
    public class GameController : BaseController
    {
        public override void GamingLoop()
        {
            Debug.Log("Gaming Process" + this.name);
        }

        public override void GamePauseProcess()
        {

        }
    }
}
