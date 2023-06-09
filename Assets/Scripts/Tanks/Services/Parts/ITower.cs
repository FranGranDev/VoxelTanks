using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public interface ITower : IPart
    {
        void Rotate(Vector3 target);
    }

    public enum TowerTypes
    {
        None,
        Small,
        Medium,
        Big,
    }
}