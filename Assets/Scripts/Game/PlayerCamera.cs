using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.Services;
using Game.Tanks;

namespace Game
{
    public class PlayerCamera : MonoBehaviour, IBindable<Transform>, IBindable<Tank>
    {
        [SerializeField] private Vector3 offset;

        public void Bind(Transform target)
        {
            this.target = target;

            transform.position = target.position + offset;
        }
        public void Bind(Tank tank)
        {
            target = tank.transform;

            transform.position = target.position + offset;
        }

        private Transform target;


        private void FixedUpdate()
        {
            if (!target)
                return;
            Vector3 position = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, position, 0.2f);
        }

    }
}
