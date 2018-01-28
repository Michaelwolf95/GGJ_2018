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
        public FsmOwnerDefault agentGameObject;

        public NavMeshAgent2D navMeshAgent { get; protected set; }

        [ActionSection("NavMeshAgent Variables")]
        public bool OverrideAgentVariables = false;
        public float AgentSpeed = 0f;
        public float AgentAcceleration = 0f;

        protected float reachedDestinationThreshold = 0.1f;
        protected Vector3 startNavPos = Vector3.zero;
        protected float DefaultAgentSpeed;
        protected float DefaultAgentAcceleration;
        //protected Timer _navigationTimeOutTimer = 

        public virtual bool HasReachedDestination
        {
            get
            {
                return
                ((Vector3.Distance(navMeshAgent.transform.position, navMeshAgent.destination) < reachedDestinationThreshold + navMeshAgent.stoppingDistance
                  || !navMeshAgent.hasPath) && !navMeshAgent.pathPending);
            }
        }

        public override void Awake()
        {
            base.Awake();
            InitializeNavMeshAgent();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (!navMeshAgent)
            {
                Debug.LogWarning("NavMeshAgent2D Not Found!");
                Finish();
                return;
            }

            if (OverrideAgentVariables)
            {
                SetNavMeshAgentVariables();
            }
        }


        public override void OnExit()
        {
            base.OnExit();
            ResetNavMeshAgentVariables();
        }

        protected virtual bool InitializeNavMeshAgent()
        {
            var go = Fsm.GetOwnerDefaultTarget(agentGameObject);
            if (go == null)
            {
                //Finish();
                return false;
            }
            navMeshAgent = go.GetComponent<NavMeshAgent2D>();

            //navMeshAgent = BehaviourController.CharacterTransform.GetComponent<NavMeshAgent>();
            if (!navMeshAgent) return false;
            if (navMeshAgent)
            {
                DefaultAgentSpeed = navMeshAgent.speed;
                DefaultAgentAcceleration = navMeshAgent.acceleration;
            }
            //InitializeStartPosition(10f);
            return true;
        }

        private void SetNavMeshAgentVariables()
        {
            navMeshAgent.speed = AgentSpeed;
            navMeshAgent.acceleration = AgentAcceleration;
        }
        protected void ResetNavMeshAgentVariables()
        {
            navMeshAgent.speed = DefaultAgentSpeed;
            navMeshAgent.acceleration = DefaultAgentAcceleration;
        }

        public override void Reset()
        {
            agentGameObject = null;
        }

        //public override void OnEnter()
        //{
        //    // get the agent component
        //    var go = Fsm.GetOwnerDefaultTarget(gameObject);

        //    if (go == null)
        //    {
        //        Finish();
        //        return;
        //    }

        //    navMeshAgent = go.GetComponent<NavMeshAgent2D>();

        //    if (!navMeshAgent)
        //    {
        //        Debug.LogWarning("NavMeshAgent2D Not Found!");
        //        Finish();
        //    }
        //}

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