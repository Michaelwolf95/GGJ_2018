using System;
using UnityEngine;
using System.Collections.Generic;
//using NUnit.Framework;

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

        [SerializeField] protected bool m_InitInfectionsAtStart = true;

        public Dictionary<string, InfectionBase> InfectionDict = new Dictionary<string, InfectionBase>();

        public TransmissionMediumType[] MediumImmunities
        {
            get { return m_MediumImmunities; }
        }

        public bool IsInfected
        {
            get { return (InfectionDict.Count > 0);}
        }

        public event InfectionEventHandler OnInfect = delegate(object sender, InfectionEventArgs args) {  };
        public Action OnCureInfection = delegate {  };
        public Action OnFullyCured = delegate {  };

        protected virtual void Start()
        {
            if(m_InitInfectionsAtStart)
            {
                foreach (var inf in Infections)
                {
                    inf.Infect(this);
                    InfectionDict.Add(inf.InfectionName, inf);
                }
            }
        }

        public virtual bool Infect(object sender, InfectionEventArgs args)
        {
            // This should be made more complex in the future.
            if (!(new List<TransmissionMediumType>(m_MediumImmunities)).Contains(args.TransmissionMedium))
            {
                var infPrefab = args.InfectionPrefab.GetComponent<InfectionBase>();
                if (infPrefab)
                {
                    if (InfectionDict.ContainsKey(infPrefab.InfectionName))
                        return false;
                    var go = GameObject.Instantiate(args.InfectionPrefab, this.transform.position, this.transform.rotation, this.transform);
                    var inf = go.GetComponent<InfectionBase>();
                    if (inf)
                    {
                        inf.Infect(this);
                        this.Infections.Add(inf);
                        this.InfectionDict.Add(inf.InfectionName, inf);
                        OnInfect(sender, args);
                        return true;
                    }
                }
            }
            return false;
        }

        public virtual void Cure(InfectionBase infection)
        {
            if (Infections.Contains(infection))
            {
                infection.Cure();
                Infections.Remove(infection);
                this.InfectionDict.Remove(infection.InfectionName);
                Destroy(infection.gameObject);

                OnCureInfection();
                if (Infections.Count == 0)
                {
                    OnFullyCured();
                }
            }
        }

        public virtual void CureAll()
        {
            InfectionBase[] infections = Infections.ToArray();
            foreach (InfectionBase inf in infections)
            {
                Cure(inf);
            }
        }

    }
}