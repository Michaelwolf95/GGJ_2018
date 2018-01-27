using System;
using UnityEngine;
using System.Collections;
using MichaelWolfGames;

namespace GGJ_2018.ContagionSystem
{

    public class ChangeSpriteColorOnInfect : SubscriberBase<InfectionBase>
    {
        protected override void SubscribeEvents()
        {
            SubscribableObject.OnInfect += OnInfect;
            SubscribableObject.OnCure += OnCure;
        }

        protected override void UnsubscribeEvents()
        {
            SubscribableObject.OnInfect -= OnInfect;
            SubscribableObject.OnCure -= OnCure;
        }

        private void OnInfect(InfectableBase host)
        {
            var sprite = host.GetComponent<SpriteRenderer>();
            if (sprite)
            {
                sprite.color = Color.red;
            }
        }
        private void OnCure(InfectableBase host)
        {
            var sprite = host.GetComponent<SpriteRenderer>();
            if (sprite)
            {
                sprite.color = Color.white;
            }
        }
    }
}
