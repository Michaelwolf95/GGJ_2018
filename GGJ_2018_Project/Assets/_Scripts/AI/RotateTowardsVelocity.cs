using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsVelocity : MonoBehaviour {
    public float rotationSpeed = 5f;
    public bool lookAtTarget = true;

    void LateUpdate()
    {
        Vector2 vectorToTarget = GetComponentInParent<NavMeshAgent2D>().velocity;
        if (lookAtTarget && vectorToTarget != new Vector2(0.0f, 0.0f))
        {
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }
        else
        {
            Vector3 vec = transform.eulerAngles;
            vec.z = Mathf.Round(vec.z / 90) * 90;
            transform.eulerAngles = vec;
        }
    }
}
