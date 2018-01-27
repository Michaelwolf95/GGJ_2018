using MichaelWolfGames;
using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public class AddContactInfectorOnInfect : SubscriberBase<InfectionBase>
    {
        [SerializeField] private GameObject _infectionPrefab;
        private ContactInfector _contactInfector;

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
            _contactInfector = host.gameObject.AddComponent<ContactInfector>();
            _contactInfector.InfectionPrefab = _infectionPrefab;
        }
        private void OnCure(InfectableBase host)
        {
            Destroy(_contactInfector);
        }
    }
}