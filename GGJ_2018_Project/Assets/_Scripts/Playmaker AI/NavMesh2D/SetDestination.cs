using HutongGames.PlayMaker;

namespace GGJ_2018.PlayMaker.NavMesh2D
{
    public class SetDestination : NavMeshAgent2DStateAction
    {
        public FsmGameObject Target;
        public bool EveryFrame = true;

        public override void OnEnter()
        {
            base.OnEnter();
            if (Target.Value)
            {
                FollowTarget(Target.Value.transform);
            }

            if (!EveryFrame)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            if (Target.Value)
            {
                FollowTarget(Target.Value.transform);
            }
        }
    }
}