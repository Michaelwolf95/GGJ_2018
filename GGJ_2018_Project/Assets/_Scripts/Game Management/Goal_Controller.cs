using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ_2018
{
    public class Goal_Controller : MonoBehaviour
    {
        //public GameObject WinPanel;

        //Game_Manager goalReached = new Game_Manager();
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //goalReached.YouWin(WinPanel);
            if (Game_Manager.Instance)
            {
                Debug.Log("YOU WIN!!!!!");
                Game_Manager.Instance.WinLevel();
                Game_Manager.Instance.StopGameTime();

            }

        }

    }
}


