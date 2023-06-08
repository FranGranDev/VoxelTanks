using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class PartPair
    {
        private PartPair(IPart parent, IPart child, PartPoint point)
        {
            Parent = parent;
            Child = child;
            Point = point;

            Physics.IgnoreCollision(parent.Collider, child.Collider);

            Point.Installed = true;

            child.Transform.position = Point.Place.position;
            child.Transform.rotation = Point.Place.rotation;

            if(!child.Transform.gameObject.TryGetComponent(out joint))
            {
                joint = child.Transform.gameObject.AddComponent<FixedJoint>();
            }
            joint.connectedBody = parent.Rigidbody;
        }

        public IPart Parent { get; private set; }
        public IPart Child { get; private set; }
        public PartPoint Point { get; private set; }


        private Joint joint;


        public static bool TryCreate(out PartPair pair, IPart parent, IPart child)
        {
            PartPoint point = parent.Points.FirstOrDefault(x => x.Type == child.Type && !x.Installed);
            if (point == null)
            {
                pair = null;
                return false;
            }

            pair = new PartPair(parent, child, point);
            return true;
        }
        public void Destroy()
        {
            Point.Installed = false;
            joint.connectedBody = null;
        }
    }
}
