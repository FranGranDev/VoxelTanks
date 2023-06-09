using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class PartPair
    {
        private PartPair(IPart parent, IPart child, PartPoint point, Types joinTypes)
        {
            Parent = parent;
            Child = child;
            Point = point;

            Physics.IgnoreCollision(parent.Collider, child.Collider);

            Point.Installed = true;

            child.Transform.position = Point.Place.position;
            child.Transform.rotation = Point.Place.rotation;

            switch(joinTypes)
            {
                case Types.FixedJoint:
                    if (!child.Transform.gameObject.TryGetComponent(out joint))
                    {
                        joint = child.Transform.gameObject.AddComponent<FixedJoint>();
                    }
                    joint.connectedBody = parent.Rigidbody;
                    break;
                case Types.Kinematic:
                    child.Transform.parent = parent.Transform;
                    child.Rigidbody.isKinematic = true;
                    break;
            }

        }

        public IPart Parent { get; private set; }
        public IPart Child { get; private set; }
        public PartPoint Point { get; private set; }


        private Joint joint;


        public static bool TryCreate(out PartPair pair, IPart parent, IPart child, Types joinTypes)
        {
            if (parent == null || child == null)
            {
                pair = null;
                return false;
            }

            PartPoint point = parent.Points.FirstOrDefault(x => x.Type == child.Type && !x.Installed);
            if (point == null)
            {
                pair = null;
                return false;
            }

            pair = new PartPair(parent, child, point, joinTypes);
            return true;
        }
        public void Destroy()
        {
            Point.Installed = false;
            joint.connectedBody = null;
        }

        public enum Types
        {
            FixedJoint,
            Kinematic,
        }
    }
}
