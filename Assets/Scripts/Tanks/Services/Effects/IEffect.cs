using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public interface IEffect
    {
        void Activate(float duration);
    }
}
