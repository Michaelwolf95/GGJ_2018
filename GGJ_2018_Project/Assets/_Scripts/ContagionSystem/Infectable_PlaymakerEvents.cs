using System;
using MichaelWolfGames;
using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public class Infectable_PlaymakerEvents : SubscriberBase<InfectableBase>
    {
        [SerializeField] private PlayMakerFSM m_PlayMaker;
        [SerializeField] private string OnInfectEventName = "OnInfect";
        [SerializeField] private string OnFullyCuredEventName = "OnInfect";

        protected override void Start()
        {
            base.Start();
            if (!m_PlayMaker) m_PlayMaker = SubscribableObject.GetComponent<PlayMakerFSM>();
        }

        protected override void SubscribeEvents()
        {
            SubscribableObject.OnInfect += SendOnInfect;
            SubscribableObject.OnFullyCured += SendOnFulllyCured;
        }

        protected override void UnsubscribeEvents()
        {
            SubscribableObject.OnInfect -= SendOnInfect;
            SubscribableObject.OnFullyCured -= SendOnFulllyCured;
        }

        private void SendOnInfect(object sender, InfectionEventArgs args)
        {
            if (m_PlayMaker)
            {
                // Make sure that this is the first infection.
                if (SubscribableObject.InfectionDict.Count == 1)
                {
                    m_PlayMaker.SendEvent(OnInfectEventName);
                }
            }
        }

        private void SendOnFulllyCured()
        {
            if (m_PlayMaker)
            {
                m_PlayMaker.SendEvent(OnInfectEventName);
            }
        }
    }
}