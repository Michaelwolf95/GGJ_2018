using HutongGames.PlayMaker;

namespace GGJ_2018.PlayMaker.NavMesh2D
{
    public class AgentFollowTarget : NavMeshAgent2DStateAction
    {
        public FsmGameObject Target;

        public override void OnEnter()
        {
            base.OnEnter();
            if (Target.Value)
            {
                FollowTarget(Target.Value.transform);
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