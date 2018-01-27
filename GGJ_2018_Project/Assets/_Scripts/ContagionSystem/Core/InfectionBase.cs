using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public class InfectionBase : MonoBehaviour
    {
        [SerializeField] private string m_InfectionName;
        public string InfectionName { get { return m_InfectionName;} }

        public IInfectable Host;
    }
}