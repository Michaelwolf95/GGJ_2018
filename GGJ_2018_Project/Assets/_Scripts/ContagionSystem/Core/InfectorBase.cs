using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public class InfectorBase : MonoBehaviour
    {
        public TransmissionMediumType TransmissionMedium;

        public void TryInfect(GameObject target)
        {
            InfectableBase inf = target.GetComponent<InfectableBase>();
            if (inf != null)
            {
                inf.Infect(this, new InfectionEventArgs(TransmissionMedium));
            }
        }
    }
}