using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public class CureOnContact : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D col)
        {
            var go = col.collider.attachedRigidbody ? col.collider.attachedRigidbody.gameObject : col.collider.gameObject;
            InfectableBase inf = go.GetComponent<InfectableBase>();
            Debug.Log("Curing....");
            if (inf != null)
            {
                Debug.Log("Curing!");
                inf.CureAll();
            }
        }
    }
}