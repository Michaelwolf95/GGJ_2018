using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using UnityEngine;

namespace GGJ_2018.PlayMaker.NavMesh2D
{

    [ActionCategory("NavMesh2D")]
    public abstract class NavMeshAgent2DStateAction : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(NavMeshAgent2D))]
        [HutongGames.PlayMaker.Tooltip("The target. An Animator component is required")]
        public FsmOwnerDefault gameObject;

        protected NavMeshAgent2D navMeshAgent;
        protected float reachedDestinationThreshold = 0.1f;

        public virtual bool HasReachedDestination
        {
            get
            {
                return
                ((Vector3.Distance(navMeshAgent.transform.position, navMeshAgent.destination) < reachedDestinationThreshold
                  || !navMeshAgent.hasPath) && !navMeshAgent.pathPending);
            }
        }

        public override void Reset()
        {
            gameObject = null;
        }

        public override void OnEnter()
        {
            // get the agent component
            var go = Fsm.GetOwnerDefaultTarget(gameObject);

            if (go == null)
            {
                Finish();
                return;
            }

            navMeshAgent = go.GetComponent<NavMeshAgent2D>();

            if (!navMeshAgent)
            {
                Debug.LogWarning("NavMeshAgent2D Not Found!");
                Finish();
            }
        }

        protected virtual void SetDestination(Vector2 position)
        {
            navMeshAgent.SetDestination(position);
        }
        protected virtual void FollowTarget(Transform target)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }
}