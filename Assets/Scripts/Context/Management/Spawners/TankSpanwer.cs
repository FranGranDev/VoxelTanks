using Game.Tanks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Context
{
    public abstract class TankSpanwer : MonoBehaviour
    {
        public abstract Tank Spawn();
    }
}
