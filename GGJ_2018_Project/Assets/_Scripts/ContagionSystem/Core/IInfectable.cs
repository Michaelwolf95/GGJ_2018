using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ_2018.ContagionSystem
{
    public struct InfectionEventArgs
    {
        public TransmissionMediumType TransmissionMedium;
    }

    public enum TransmissionMediumType
    {
        Default,
        Contact,
        Airborn,
        Fluid
    }

    public delegate void InfectionEventHandler(object sender, InfectionEventArgs args);

    public interface IInfectable
    {
        TransmissionMediumType[] MediumImmunities { get; }
        bool TryInfect(object sender, InfectionEventArgs args);
        event InfectionEventHandler OnInfect;
    }
}