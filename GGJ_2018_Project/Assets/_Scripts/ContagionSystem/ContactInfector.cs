using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public class ContactInfector : InfectorBase
    {
        public void OnCollisionEnter(Collider other)
        {
            var go = other.attachedRigidbody ? other.attachedRigidbody.gameObject : other.gameObject;
            TryInfect(go);
        }
    }
}