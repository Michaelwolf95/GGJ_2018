using System.Collections;
using System.Collections.Generic;
using MichaelWolfGames;
using UnityEngine;
namespace GGJ_2018
{
public class Final_Goal_Controller : MonoBehaviour
    {

        //public GameObject WinPanel;

        //Game_Manager goalReached = new Game_Manager();

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!PlayerInstance.Instance)
                return;
            var go = col.attachedRigidbody ? col.attachedRigidbody.gameObject : col.gameObject;
            if (go == PlayerInstance.Instance.gameObject)
            {
                //goalReached.YouWin(WinPanel);
                if (Game_Manager.Instance)
                {
                    Game_Manager.Instance.LoadFinalLevel();
                }
            }


        }
    }

}


