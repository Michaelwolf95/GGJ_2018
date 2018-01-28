using MichaelWolfGames;
using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public class PlayAnimationOnInfectSuccess : SubscriberBase<InfectorBase>
    {
        [SerializeField] private Animator m_Animator;
        [SerializeField] private string m_StateName = "Cough";
        [SerializeField] private int m_Layer = 0;

        protected override void Start()
        {
            base.Start();

            if (!m_Animator) m_Animator = GetComponent<Animator>();

        }

        protected override void SubscribeEvents()
        {
            SubscribableObject.OnInfectSuccess += PlayAnimation;
        }

        protected override void UnsubscribeEvents()
        {
            SubscribableObject.OnInfectSuccess -= PlayAnimation;
        }

        private void PlayAnimation()
        {
            if (m_Animator)
            {
                m_Animator.Play(m_StateName, m_Layer);
            }
        }
    }
}