
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QianXuFramework;

namespace CatchFood
{
    public class CountDownHub : BaseHub
    {
        public int countDownTime { private get; set; }  //倒计时的时间
        public Text countDownText;   //显示倒计时的hub


        //开启倒计时
        public void StartCountDown()
        {
            InvokeRepeating("ShowCountDownTime", 0, 1);
        }

        /// <summary>
        /// 显示倒计时的时间
        /// </summary>
        void ShowCountDownTime()
        {
            countDownText.text = countDownTime.ToString();
            countDownTime--;
            if (countDownTime < 0)
            {
                CancelInvoke();
            }
        }
    }
}