using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QianXuFramework;

namespace CatchFood
{
    public class CatchFoodEndController : BaseController
    {
        public SettlementHub settlementHub;  //用于游戏结算的Hub
        public CurrentUserDataHub currentUserDataHub;    //记录了游戏过程中接住的食材的数量和选择的菜品的信息
        public override void GameEndReady()
        {
            print(this.name+"：GameEndReady");

            settlementHub.SetActiveSettlementPanel(true); //激活结算面板
            settlementHub.StartSettlement(CurrentUserDataHub.CurrentSelectDish,currentUserDataHub.currentIngredientCount);

            GameStatus.GAME_STATUS = GameStatus.STATUS_GAME_END_LOOP;
        }

        public override void GameExitProcess()
        {

        }

        public override void GameEndLoop()
        {
            print(this.name + ":GameEndLoop");
        }

        public override void CleanUpProcess()
        {
            print(this.name + ":CleanUpProcess");
            settlementHub.SetActiveSettlementPanel(false); //隐藏结算面板

            GameStatus.GAME_STATUS = GameStatus.STATUS_INIT;
        }

    }
}
