using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class Track : Part, ITrack
    {
        [Header("Settings")]
        [SerializeField] private float speed;

        public override PartTypes Type
        {
            get => PartTypes.Track;
        }

        public void Drive(float direction)
        {
            Vector3 force = Vector3.forward * direction * speed * Time.deltaTime;

            Rigidbody.AddForce(force, ForceMode.VelocityChange);
        }


        public override void Accept(IPartInstaller installer)
        {
            installer.Install(this);
        }
    }
}
