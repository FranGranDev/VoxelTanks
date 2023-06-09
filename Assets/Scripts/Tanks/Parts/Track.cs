using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class Track : Part, ITrack
    {
        [Header("Settings")]
        [SerializeField] private float speed;

        private Vector3 force;

        public override PartTypes Type
        {
            get => PartTypes.Track;
        }

        public void Drive(float direction)
        {
            force = Transform.forward * direction * speed;
        }

        private void FixedUpdate()
        {
            Rigidbody.velocity = Vector3.Lerp(Rigidbody.velocity, force, 0.25f);
        }

        public override void Join(IPart other)
        {
            base.Join(other);

            Joint joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = other.Rigidbody;
        }
        public override void Accept(IPartInstaller installer)
        {
            installer.Install(this);
        }
    }
}
