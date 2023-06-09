using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public interface ITower : IPart
    {
        void Rotate(float angle);
    }

    public enum TowerTypes
    {
        None,
        Small,
        Medium,
        Big,
    }
}