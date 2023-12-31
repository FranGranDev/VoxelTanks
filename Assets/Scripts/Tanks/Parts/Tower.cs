using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class Tower : Part, ITower
    {
        [SerializeField, Range(0, 1f)] private float turnSpeed;

        public override PartTypes Type => PartTypes.Tower;

        private Vector3 target;


        public void Rotate(Vector3 target)
        {
            this.target = target;
        }


        private void FixedUpdate()
        {
            if (parent == null)
                return;
            Vector3 direction = target - transform.position;

            direction = parent.gameObject.transform.InverseTransformDirection(direction);
            direction.y = 0;
            direction.Normalize();

            if (direction == Vector3.zero)
                return;

            Quaternion rotation = Quaternion.LookRotation(direction);

            transform.localRotation = Quaternion.Lerp(transform.localRotation, rotation, 0.25f * turnSpeed);
        }

        public override void Accept(IPartInstaller installer)
        {
            installer.Install(this);
        }
    }
}
