using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private Transform model;
        [SerializeField] private new Rigidbody rigidbody;


        public void Fire(float power)
        {
            
        }

        public void Set(Transform point)
        {
            transform.parent = point;
        }
    }
}
