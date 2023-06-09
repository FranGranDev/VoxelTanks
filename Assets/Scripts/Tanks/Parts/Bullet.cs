using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [Header("Components")]
        [SerializeField] private new Collider collider;
        [SerializeField] private new Rigidbody rigidbody;

        public Collider Collider
        {
            get => collider;
        }


        public void Fire(float power, Vector3 direction)
        {
            rigidbody.isKinematic = false;
            transform.parent = null;

            rigidbody.AddForce(direction * power, ForceMode.VelocityChange);
        }

        public void Set(Transform point)
        {
            transform.parent = point;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            rigidbody.isKinematic = true;
        }
    }
}
