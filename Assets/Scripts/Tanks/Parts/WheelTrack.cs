using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class WheelTrack : Part, ITrack
    {
        [Header("Setting")]
        [SerializeField] private float wheelTorque;
        [Header("Wheels")]
        [SerializeField] private List<WheelCollider> wheelColliders;

        public override PartTypes Type
        {
            get => PartTypes.Track;
        }


        public void Drive(float direction)
        {
            foreach(WheelCollider wheelCollider in wheelColliders)
            {
                wheelCollider.motorTorque = direction * wheelTorque;
            }
        }

        public override void Join(IPart other)
        {
            base.Join(other);

            transform.parent = other.Transform;
            if (Rigidbody)
            {
                Rigidbody.isKinematic = true;
            }
        }
        public override void Accept(IPartInstaller installer)
        {
            installer.Install(this);
        }
    }
}
