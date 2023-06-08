using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public interface IBullet
    {
        void Fire(float power);
        void Set(Transform point);
    }
}