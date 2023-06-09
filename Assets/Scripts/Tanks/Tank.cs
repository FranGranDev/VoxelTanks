using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class Tank : MonoBehaviour, IPartInstaller, IBodyControll, ITowerControll, IGunControll
    {
        private IBody body;
        private ITower tower;
        private IGun gun;

        private List<ITrack> leftTracks = new List<ITrack>();
        private List<ITrack> rightTracks = new List<ITrack>();

        private List<IPart> parts = new List<IPart>();


        private float drive;
        private float turn;


        public void Initialize()
        {

        }

        private void Drive()
        {
            foreach(ITrack track in leftTracks)
            {
                track.Drive(Mathf.Clamp(drive + turn, -1f, 1f));
            }
            foreach (ITrack track in rightTracks)
            {
                track.Drive(Mathf.Clamp(drive - turn, -1f, 1f));
            }
        }

        void IBodyControll.Drive(float direction)
        {
            this.drive = direction;
        }
        void IBodyControll.Turn(float turn)
        {
            this.turn = turn;
        }

        void ITowerControll.Turn(Vector3 target)
        {
            if (tower == null)
                return;

            tower.Rotate(target);
        }
        void IGunControll.Fire()
        {
            if (gun == null)
                return;

            gun.Shot();
        }



        private List<PartPair> pairs = new List<PartPair>();
        private bool CreatePair(IPart parent, IPart child)
        {
            if(PartPair.TryCreate(out PartPair pair, parent, child))
            {
                pairs.Add(pair);
                parts.Add(child);
                return true;
            }

            child.Demolish();
            Debug.LogWarning($"Cant install {child.Transform.name}!");
            
            return false;
        }
        public void InstallPart(IPart part)
        {
            if (part == null)
                return;

            part.Transform.SetParent(transform);
            part.Transform.localPosition = Vector3.zero;
            part.Transform.localRotation = Quaternion.identity;

            part.Accept(this);
        }

        public void Install(IBody body)
        {
            this.body = body;

            parts.Add(body);
        }
        public void Install(ITrack track)
        {
            if (CreatePair(body, track))
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
            if (CreatePair(body, tower))
            {
                this.tower = tower;
            }
        }
        public void Install(IGun gun)
        {
            if(CreatePair(tower, gun))
            {
                this.gun = gun;
            }
        }
        public void Install(IAmmo ammo)
        {
            if (CreatePair(gun, ammo))
            {
                gun.SetAmmo(ammo);
            }

        }


        private void FixedUpdate()
        {
            Drive();
        }
    }
}
