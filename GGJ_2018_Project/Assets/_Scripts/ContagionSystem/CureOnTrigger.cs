using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public class CureOnTrigger : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D col)
        {
            var go = col.attachedRigidbody ? col.attachedRigidbody.gameObject : col.gameObject;
            InfectableBase inf = go.GetComponent<InfectableBase>();
            //Debug.Log("Curing....");
            if (inf != null)
            {
                //Debug.Log("Curing!");
                inf.CureAll();
            }
        }
    }
}