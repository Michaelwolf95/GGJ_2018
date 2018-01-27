using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour
{

    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
    }


    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector2 dirToTarget = (target.position - transform.position).normalized;



            if (Vector2.Angle(transform.up, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector2.Distance(transform.position, target.position);
                visibleTargets.Add(target);
                // Check for obstacles between objects in view radius
                RaycastHit2D hit2d = Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask);
                if (hit2d)
                {
                    visibleTargets.Add(target);
                }
            }
        }



        SetClosestTarget();
    }

    void SetClosestTarget()
    {
        Transform target = null;

        foreach (Transform trans in visibleTargets)
        {
            if (target == null)
            {
                target = trans;
            }
            else if (Vector2.Distance(transform.position, trans.position) < Vector2.Distance(transform.position, target.position))
            {
                target = trans;
            }
        }

        if (target != null)
        {
            GetComponentInParent<MoveToTarget>().setTarget(target);
        }
    }


    public Vector2 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees -= transform.eulerAngles.z; //convert to global angle
        }
        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}