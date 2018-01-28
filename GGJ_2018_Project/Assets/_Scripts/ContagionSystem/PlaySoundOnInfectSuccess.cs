using System;
using MichaelWolfGames;
using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public class PlaySoundOnInfectSuccess : SubscriberBase<InfectorBase>
    {
        [SerializeField] private AudioSource m_AudioSource;
        [SerializeField] private AudioClip[] m_AudioClips;

        protected override void Start()
        {
            base.Start();

            if (!m_AudioSource) m_AudioSource = GetComponent<AudioSource>();

        }

        protected override void SubscribeEvents()
        {
            SubscribableObject.OnInfectSuccess += PlaySound;
        }

        protected override void UnsubscribeEvents()
        {
            SubscribableObject.OnInfectSuccess -= PlaySound;
        }

        private void PlaySound()
        {
            if (m_AudioSource && m_AudioClips.Length > 0)
            {
                m_AudioSource.PlayOneShot(m_AudioClips[UnityEngine.Random.Range(0,m_AudioClips.Length)]);
            }
        }
    }
}