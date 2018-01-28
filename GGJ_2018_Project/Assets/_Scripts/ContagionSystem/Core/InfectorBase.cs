using System;
using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public abstract class InfectorBase : MonoBehaviour
    {
        public GameObject InfectionPrefab;
        public TransmissionMediumType TransmissionMedium;

        public Action OnInfectSuccess = delegate {  };

        public void TryInfect(GameObject target)
        {
            InfectableBase inf = target.GetComponent<InfectableBase>();
            //Debug.Log("Infecting..");
            if (inf != null)
            {
                if(inf.Infect(this, new InfectionEventArgs(InfectionPrefab, TransmissionMedium)))
                {
                    Debug.Log("Infect Success!");
                    OnInfectSuccess();
                }
            }
        }
    }
}