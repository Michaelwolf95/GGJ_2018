
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
    }
}