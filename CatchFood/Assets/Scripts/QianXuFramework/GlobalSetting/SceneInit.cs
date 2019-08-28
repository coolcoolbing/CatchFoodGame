using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QianXuFramework
{
    public class SceneInit : MonoBehaviour
    {
        public string initialState;

        // Start is called before the first frame update
        void Start()
        {
            GameStatus.GAME_STATUS = initialState;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
