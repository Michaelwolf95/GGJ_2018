using UnityEngine;


namespace GGJ_2018_AP
{
    public class Elevator_Scriipt : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Time.timeScale = 1;
        }
    }
}


