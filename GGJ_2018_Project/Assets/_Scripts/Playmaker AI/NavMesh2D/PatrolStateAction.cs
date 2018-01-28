using MichaelWolfGames;
using UnityEngine;
using WellTold.AI.Playmaker.Pathing;

namespace GGJ_2018.PlayMaker.NavMesh2D
{
    public class PatrolStateAction : NavMeshAgent2DStateAction
    {
        public PatrolPath Path;
        public bool UsePath = true;

        private Timer _waitTimer = new Timer(0.5f);

        public override void OnEnter()
        {
            base.OnEnter();
            //reachedDestinationThreshold = 0.01f;
        }

        public override void OnUpdate()
        {
            if (Path && UsePath)
            {
                FollowPatrol();
            }
            else
            {
                base.OnUpdate();
            }
        }

        private void FollowPatrol()
        {
            if (HasReachedDestination && !navMeshAgent.pathPending)
            {
                if (_waitTimer.Tick())
                {
                    //FindNewRandomDestination(_wanderRadius);
                    FindNextPathPosition();
                    _waitTimer.Reset();
                }

            }
        }

        protected void FindNextPathPosition()
        {
            Debug.Log("Next Position");
            Vector3 newPos = Path.GetNextNode().position;
            navMeshAgent.SetDestination(newPos);
            
        }
    }
}