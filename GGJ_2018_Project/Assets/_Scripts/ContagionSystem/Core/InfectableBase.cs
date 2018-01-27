using UnityEngine;
using System.Collections.Generic;

namespace GGJ_2018.ContagionSystem
{
    public struct InfectionEventArgs
    {
        public TransmissionMediumType TransmissionMedium;

        public InfectionEventArgs(TransmissionMediumType mediumType)
        {
            TransmissionMedium = mediumType;
        }
    }

    public enum TransmissionMediumType
    {
        Default,
        Contact,
        Airborn,
        Fluid
    }

    public delegate void InfectionEventHandler(object sender, InfectionEventArgs args);

    public class InfectableBase : MonoBehaviour
    {
        [SerializeField] protected TransmissionMediumType[] m_MediumImmunities;

        [SerializeField] protected InfectionBase[] Infections;

        public TransmissionMediumType[] MediumImmunities
        {
            get { return m_MediumImmunities; }
        }

        public virtual bool Infect(object sender, InfectionEventArgs args)
        {
            // This should be made more complex in the future.
            if (!(new List<TransmissionMediumType>(m_MediumImmunities)).Contains(args.TransmissionMedium))
            {
                return true;
            }
            return false;
        }

        public event InfectionEventHandler OnInfect;
    }
}