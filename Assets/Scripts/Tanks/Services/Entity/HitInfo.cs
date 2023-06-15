using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class HitInfo
    {
        public HitInfo(int damage, Transform origin, Vector3 normal, Vector3 position)
        {
            Damage = damage;
            Origin = origin;
            Normal = normal;
            Position = position;
        }

        public int Damage { get; }

        public Transform Origin { get; }
        public Vector3 Normal { get; }
        public Vector3 Position { get; }
    }
}
