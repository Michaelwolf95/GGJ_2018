using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public class TriggerInfector : ContactInfector
    {
        public override void OnCollisionStay2D(Collision2D col)
        {
            //base.OnCollisionStay2D(col);
        }

        protected virtual void OnTriggerStay2D(Collider2D col)
        {
            var go = col.attachedRigidbody ? col.attachedRigidbody.gameObject : col.gameObject;
            TryInfect(go);
        }
    }
}