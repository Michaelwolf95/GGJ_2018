using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public class ContactInfector : InfectorBase
    {
        //public void OnCollisionEnter2D(Collision2D col)
        //{
        //    var go = col.collider.attachedRigidbody ? col.collider.attachedRigidbody.gameObject : col.collider.gameObject;
        //    TryInfect(go);
        //}
        public virtual void OnCollisionStay2D(Collision2D col)
        {
            var go = col.collider.attachedRigidbody ? col.collider.attachedRigidbody.gameObject : col.collider.gameObject;
            TryInfect(go);
        }
    }
}