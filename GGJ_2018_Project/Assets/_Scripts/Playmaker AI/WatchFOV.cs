using HutongGames.PlayMaker;
using UnityEngine;

namespace GGJ_2018.PlayMaker
{
    public class WatchFOV : FsmStateAction
    {
        public FsmGameObject gameObject;

        public FsmGameObject ResultTarget;
        public FsmEvent DetectEvent;

        [HutongGames.PlayMaker.Tooltip("Repeat every frame. Useful when using normalizedTime to manually control the animation.")]
		public bool everyFrame;

        protected FieldOfView _fov;

		public override void Reset()
		{
			gameObject = null;
			everyFrame = false;
		}
		
		public override void OnEnter()
		{
			// get the animator component
		    var go = gameObject.Value;
			
			if (go==null)
			{
				Finish();
				return;
			}
			
			_fov = go.GetComponent<FieldOfView>();
			
			DoWatch();
			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoWatch();
		}

		protected virtual void DoWatch()
		{
            
			if (_fov !=null)
			{
			    Debug.Log("Watching");
                var results = _fov.GetVisibleTargets();
			    foreach (var result in results)
			    {
                    Debug.Log("Checking " + result.gameObject.name);
			        if (CheckCondition(result.gameObject))
			        {
			            Debug.Log("Detected!");
                        ResultTarget.Value = result.gameObject;
                        Fsm.Event(DetectEvent);
                        Finish();
                        return;
			        }
			    }
			}

		}

        protected virtual bool CheckCondition(GameObject go)
        {
            return true;
        }


    }
}