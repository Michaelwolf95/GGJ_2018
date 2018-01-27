using System;
using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public abstract class InfectionBase : MonoBehaviour
    {
        [SerializeField] private string m_InfectionName;
        public string InfectionName { get { return m_InfectionName;} }

        public InfectableBase Host { get; protected set; }

        public Action<InfectableBase> OnInfect = delegate { };
        public Action<InfectableBase> OnCure = delegate { };

        public virtual void Infect(InfectableBase host)
        {
            if (Host != null)
            {
                Debug.LogWarning("Infection Instances can only infect one host during its life cycle!");
                return;
            }

            Host = host;
            OnInfect(Host);
        }


        public virtual void Cure()
        {
            if (Host == null)
            {
                return;
            }

            OnCure(Host);
            Host = null;

            //Destroy(this.gameObject);
        }
    }
}