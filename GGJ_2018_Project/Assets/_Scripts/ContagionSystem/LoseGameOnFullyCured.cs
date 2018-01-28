using System;
using MichaelWolfGames;
using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public class LoseGameOnFullyCured : SubscriberBase<InfectableBase>
    {
        protected override void SubscribeEvents()
        {
            SubscribableObject.OnFullyCured += DoOnFullyCured;
        }
        protected override void UnsubscribeEvents()
        {
            SubscribableObject.OnFullyCured -= DoOnFullyCured;
        }

        private void DoOnFullyCured()
        {
            Debug.Log("Fully Cured.");
            if (Game_Manager.Instance)
            {
                Game_Manager.Instance.LoseLevel();
                Game_Manager.Instance.StopGameTime();
            }
        }
    }
}