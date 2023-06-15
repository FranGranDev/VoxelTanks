using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public interface IBullet
    {
        public Collider Collider { get; }
        public float Mass { get; }

        void Fire(float power, Vector3 direction);
        void Set(Transform point);
    }

    public enum BulletTypes
    {
        None,
        Base,
    }
}