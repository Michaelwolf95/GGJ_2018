using HutongGames.PlayMaker;
using MichaelWolfGames;
using UnityEngine;
using WellTold.AI.Playmaker.Pathing;

namespace GGJ_2018.PlayMaker.NavMesh2D
{
    public class PatrolStateAction : NavMeshAgent2DStateAction
    {
        public FsmGameObject PatrolPathGameObject;
        public FsmFloat WaitTime = 0.5f;

        private PatrolPath _path;
        public bool UsePath = true;

        private Timer _waitTimer = new Timer(0.5f);

        public override void Reset()
        {
            base.Reset();
            PatrolPathGameObject = null;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _waitTimer = new Timer(WaitTime.Value);
            if (UsePath)
            {
                //if(PatrolPathGameObject.Value)
                if (PatrolPathGameObject == null)
                {
                    Finish();
                    return;
                }

                _path = PatrolPathGameObject.Value.GetComponent<PatrolPath>();
            }

        }

        public override void OnUpdate()
        {
            if (_path && UsePath)
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
            if(_path.PathNodes.Length <=1) return;
            //Debug.Log("Next Position");
            Vector3 newPos = _path.GetNextNode().position;
            navMeshAgent.SetDestination(newPos);
            
        }
    }
}