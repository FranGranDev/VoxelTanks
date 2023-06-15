using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [Header("Settings")]
        [SerializeField, Min(0)] private int damage;
        [Header("Components")]
        [SerializeField] private new Collider collider;
        [SerializeField] private new Rigidbody rigidbody;

        public Collider Collider
        {
            get => collider;
        }
        public float Mass
        {
            get => rigidbody.mass;
        }


        public void Fire(float power, Vector3 direction)
        {
            rigidbody.isKinematic = false;
            transform.parent = null;

            rigidbody.AddForce(direction * power, ForceMode.VelocityChange);

            Destroy(gameObject, 10);
        }

        public void Set(Transform point)
        {
            transform.parent = point;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            rigidbody.isKinematic = true;
        }


        private void Hit(IEntity entity, Collision collision)
        {
            entity.Hit(new HitInfo(damage, collision.collider.transform, collision.GetContact(0).normal, collision.GetContact(0).point));
        }


        private void OnCollisionEnter(Collision collision)
        {
            if(collision.rigidbody != null)
            {
                IEntity entity = collision.transform.GetComponentInParent<IEntity>();
                if(entity != null)
                {
                    Hit(entity, collision);
                    Destroy(gameObject);
                }
            }
        }
    }
}
