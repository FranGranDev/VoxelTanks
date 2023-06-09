using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public interface ITrack : IPart
    {
        void Drive(float direction);
    }

    public enum TrackTypes
    {
        None,
        Small,
        Medium,
        Big,
    }
}