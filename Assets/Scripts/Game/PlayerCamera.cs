using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;

        public void SetTarget(Transform target)
        {
            this.target = target;

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
