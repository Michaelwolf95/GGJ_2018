using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ_2018_AP
{
    public class Goal_Controller : MonoBehaviour
    {
        Game_Manager goalReached = new Game_Manager();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            goalReached.StopGameTime();
            goalReached.YouWin();
        }

    }
}


