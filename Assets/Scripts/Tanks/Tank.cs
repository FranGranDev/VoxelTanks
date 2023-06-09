using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class Tank : MonoBehaviour, IPartInstaller
    {
        private IBody body;

        private ITower tower;
        private IGun gun;

        private List<ITrack> leftTracks = new List<ITrack>();
        private List<ITrack> rightTracks = new List<ITrack>();


        public void InstallPart(IPart part)
        {
            if (part == null)
                return;

            part.Transform.SetParent(transform);
            part.Transform.localPosition = Vector3.zero;
            part.Transform.localRotation = Quaternion.identity;

            part.Accept(this);
        }


        private List<PartPair> pairs = new List<PartPair>();

        private bool CreatePair(IPart parent, IPart child, PartPair.Types joinTypes)
        {
            if(PartPair.TryCreate(out PartPair pair, parent, child, joinTypes))
            {
                pairs.Add(pair);
                return true;
            }

            child.Demolish();
            Debug.LogWarning($"Cant install {child.Transform.name}!");
            
            return false;
        }
        

        public void Install(IBody body)
        {
            this.body = body;
        }
        public void Install(ITrack track)
        {
            if (CreatePair(body, track, PartPair.Types.FixedJoint))
            {
                if (track.Transform.localPosition.x > 0)
                {
                    rightTracks.Add(track);
                }
                else
                {
                    leftTracks.Add(track);
                }
            }
        }
        public void Install(ITower tower)
        {
            if (CreatePair(body, tower, PartPair.Types.Kinematic))
            {
                this.tower = tower;
            }
        }
        public void Install(IGun gun)
        {
            if(CreatePair(tower, gun, PartPair.Types.Kinematic))
            {
                this.gun = gun;
            }
        }
        public void Install(IAmmo ammo)
        {
            if (CreatePair(gun, ammo, PartPair.Types.Kinematic))
            {
                gun.SetAmmo(ammo);
            }

        }
    }
}
