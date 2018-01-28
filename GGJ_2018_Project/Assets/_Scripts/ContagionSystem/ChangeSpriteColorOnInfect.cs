using System;
using UnityEngine;
using System.Collections;
using MichaelWolfGames;

namespace GGJ_2018.ContagionSystem
{

    public class ChangeSpriteColorOnInfect : SubscriberBase<InfectionBase>
    {
        public Color NewColor = Color.green;

        protected SpriteRenderer _spriteRenderer;
        protected Color _oldColor;

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
            if (!_spriteRenderer)
            {
                _spriteRenderer = host.GetComponent<SpriteRenderer>();
                if (!_spriteRenderer)
                {
                    _spriteRenderer = host.GetComponentInChildren<SpriteRenderer>();
                }
            }
            if (_spriteRenderer)
            {
                _oldColor = _spriteRenderer.color;
                _spriteRenderer.color = NewColor;
            }
        }
        private void OnCure(InfectableBase host)
        {
            //var _spriteRenderer = host.GetComponent<SpriteRenderer>();
            if (_spriteRenderer)
            {
                _spriteRenderer.color = _oldColor;
            }
        }
    }
}
