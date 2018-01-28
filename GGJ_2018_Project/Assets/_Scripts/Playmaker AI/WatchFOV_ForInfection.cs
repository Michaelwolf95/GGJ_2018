
using GGJ_2018.ContagionSystem;
using UnityEngine;

namespace GGJ_2018.PlayMaker
{
    public class WatchFOV_ForInfection : WatchFOV
    {
        protected override bool CheckCondition(GameObject go)
        {
            var infectable = go.GetComponent<InfectableBase>();

            if (infectable)
            {
                return (infectable.IsInfected);
            }

            return false;
        }

        protected override bool CompareTargets(GameObject currentTarget, GameObject newTarget)
        {
            var curDist = Vector2.Distance(currentTarget.transform.position, _fov.transform.position);
            var newDist = Vector2.Distance(newTarget.transform.position, _fov.transform.position);

            return (newDist < curDist);
        }
    }
}