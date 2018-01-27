using UnityEngine;
using System.Collections.Generic;

namespace GGJ_2018.ContagionSystem
{
    public class InfectableBase : MonoBehaviour, IInfectable
    {
        [SerializeField] protected TransmissionMediumType[] m_MediumImmunities;
        public TransmissionMediumType[] MediumImmunities
        {
            get { return m_MediumImmunities; }
        }

        public virtual bool Infect(object sender, InfectionEventArgs args)
        {
            if (!(new List<TransmissionMediumType>(m_MediumImmunities)).Contains(args.TransmissionMedium))
            {
                // This should be made more complex in the future.
                return true;
            }
            return false;
        }

        public event InfectionEventHandler OnInfect;
    }
}