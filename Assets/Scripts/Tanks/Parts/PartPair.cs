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

            Physics.IgnoreCollision(parent.Transform.GetComponentInChildren<Collider>(), child.Transform.GetComponentInChildren<Collider>());

            Point.Installed = true;

            child.Transform.position = Point.Place.position;
            child.Transform.rotation = Point.Place.rotation;

            child.Join(parent);
        }

        public IPart Parent { get; private set; }
        public IPart Child { get; private set; }
        public PartPoint Point { get; private set; }



        public static bool TryCreate(out PartPair pair, IPart parent, IPart child)
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

            pair = new PartPair(parent, child, point);
            return true;
        }
        public void Destroy()
        {
            Point.Installed = false;
        }
    }
}
