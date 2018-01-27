using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target != null)
        {
            GetComponent<NavMeshAgent2D>().destination = target.position;
        }
    }

    public void setTarget(Transform newTarget)
    {
        target = newTarget;
    }
}