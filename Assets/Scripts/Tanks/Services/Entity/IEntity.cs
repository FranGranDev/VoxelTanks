using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public interface IEntity
    {
        public int Hp { get; }
        public int MaxHp { get; }

        public void Hit(HitInfo info);
    }
}
