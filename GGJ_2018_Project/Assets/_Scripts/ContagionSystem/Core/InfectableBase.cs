using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;

namespace GGJ_2018.ContagionSystem
{
    public struct InfectionEventArgs
    {
        public GameObject InfectionPrefab;
        public TransmissionMediumType TransmissionMedium;

        public InfectionEventArgs(GameObject infectionPrefab, TransmissionMediumType mediumType = TransmissionMediumType.Default)
        {
            InfectionPrefab = infectionPrefab;
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

    public abstract class InfectableBase : MonoBehaviour
    {
        [SerializeField] protected TransmissionMediumType[] m_MediumImmunities;

        [SerializeField] protected List<InfectionBase> Infections;

        public TransmissionMediumType[] MediumImmunities
        {
            get { return m_MediumImmunities; }
        }

        public event InfectionEventHandler OnInfect;

        public virtual bool Infect(object sender, InfectionEventArgs args)
        {
            // This should be made more complex in the future.
            if (!(new List<TransmissionMediumType>(m_MediumImmunities)).Contains(args.TransmissionMedium))
            {
                var go = GameObject.Instantiate(args.InfectionPrefab, this.transform.position, this.transform.rotation, this.transform);
                var inf = go.GetComponent<InfectionBase>();
                if (inf)
                {
                    inf.Infect(this);
                }
                return true;
            }
            return false;
        }

        public virtual void Cure(InfectionBase infection)
        {
            if (Infections.Contains(infection))
            {
                infection.Cure();
                Infections.Remove(infection);
                //Destroy(infection.gameObject);
            }
        }

        public virtual void CureAll()
        {
            InfectionBase[] infections = Infections.ToArray();
            foreach (InfectionBase inf in infections)
            {
                inf.Cure();
                Infections.Remove(inf);
            }
        }

    }
}