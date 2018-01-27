using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public abstract class InfectorBase : MonoBehaviour
    {
        public GameObject InfectionPrefab;
        public TransmissionMediumType TransmissionMedium;

        public void TryInfect(GameObject target)
        {
            InfectableBase inf = target.GetComponent<InfectableBase>();
            if (inf != null)
            {
                inf.Infect(this, new InfectionEventArgs(InfectionPrefab, TransmissionMedium));
            }
        }
    }
}