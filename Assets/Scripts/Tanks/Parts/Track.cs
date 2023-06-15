using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class Track : Part, ITrack
    {
        [Header("Setting")]
        [SerializeField] private AnimationCurve torqueCurve;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float wheelTorque;
        [Header("Wheels")]
        [SerializeField] private List<WheelCollider> wheelColliders;

        private List<WheelView> wheelViews;
        
        public override PartTypes Type
        {
            get => PartTypes.Track;
        }
        public float TorqueRatio
        {
            get
            {
                return torqueCurve.Evaluate(parent.velocity.magnitude / maxSpeed);
            }
        }

        public void Drive(float direction)
        {
            foreach(WheelCollider wheelCollider in wheelColliders)
            {
                wheelCollider.motorTorque = direction * wheelTorque * TorqueRatio;
            }
        }

        public override void Initialize(Rigidbody parent)
        {
            base.Initialize(parent);

            wheelViews = new List<WheelView>(GetComponentsInChildren<WheelView>());
        }
        protected override void OnDemolish(Rigidbody rigidbody)
        {
            foreach(WheelView wheelView in wheelViews)
            {
                wheelView.Demolish(rigidbody.velocity);
            }
            foreach(WheelCollider wheelCollider in wheelColliders)
            {
                Destroy(wheelCollider);
            }

            wheelViews.Clear();
            wheelColliders.Clear();
        }

        public override void Accept(IPartInstaller installer)
        {
            installer.Install(this);
        }
    }
}
