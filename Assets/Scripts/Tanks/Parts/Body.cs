using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class Body : Part, IBody
    {
        public override PartTypes Type => PartTypes.Body;


        public void Drive(float direction)
        {
            
        }
        public void Turn(float turn)
        {
            
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
