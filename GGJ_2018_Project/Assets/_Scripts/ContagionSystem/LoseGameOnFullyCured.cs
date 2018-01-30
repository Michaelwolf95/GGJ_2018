using System;
using MichaelWolfGames;
using UnityEngine;
using UnityEngine.Events;

namespace GGJ_2018.ContagionSystem
{
    public class LoseGameOnFullyCured : SubscriberBase<InfectableBase>
    {
        [SerializeField] private float _delayTime = 1f;
        public UnityEvent OnFullyCuredUnityEvent;
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
            OnFullyCuredUnityEvent.Invoke();
            this.InvokeAction(() =>
            {
                if (Game_Manager.Instance)
                {
                    Game_Manager.Instance.LoseLevel();
                    Game_Manager.Instance.StopGameTime();
                }
            }, _delayTime);
        }
    }
}