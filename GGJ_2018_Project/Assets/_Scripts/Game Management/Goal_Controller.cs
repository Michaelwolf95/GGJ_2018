using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ_2018_AP
{
    public class Goal_Controller : MonoBehaviour
    {
        public GameObject WinPanel;

        Game_Manager goalReached = new Game_Manager();
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("YOU WIN!!!!!");
            goalReached.YouWin(WinPanel);
            goalReached.StopGameTime();

        }

    }
}


