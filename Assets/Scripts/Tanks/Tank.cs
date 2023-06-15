using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Tanks
{
    public class Tank : MonoBehaviour, IPartInstaller, IBodyControll, ITowerControll, IGunControll, IEntity
    {
        [Header("Components")]
        [SerializeField] private new Rigidbody rigidbody;


        [Inject]
        private IFactory<HitInfo, float, IEffect> effectFactory;


        private IBody body;
        private ITower tower;
        private IGun gun;
        private List<ITrack> leftTracks = new List<ITrack>();
        private List<ITrack> rightTracks = new List<ITrack>();
        private List<IPart> parts = new List<IPart>();
        private List<PartPair> pairs = new List<PartPair>();

        private int maxHp;
        private int hp;

        private float drive;
        private float turn;


        public int Hp
        {
            get => hp;
            set
            {
                hp = value;
                hp = Mathf.Max(hp, 0);
            }
        }
        public int MaxHp
        {
            get => maxHp;
        }


        public void Initialize()
        {
            rigidbody.centerOfMass = new Vector3(0.1f, 0.05f, 0);

            foreach(IPart part in parts)
            {
                part.Initialize(rigidbody);

                maxHp += part.MaxHp;
            }
            parts.ForEach(x => x.Initialize(rigidbody));

            hp = maxHp;
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

            if (gun == null)
                return;

            gun.Aim(target);
        }
        void IGunControll.Fire()
        {
            if (gun == null)
                return;

            gun.Shot();
        }


        public void Hit(HitInfo info)
        {
            if (Hp == 0)
                return;

            Hp -= info.Damage;

            if(Hp == 0)
            {
                Demolish();
            }
            else
            {
                effectFactory.Create(info, 5);
            }
        }

        private void Demolish()
        {
            foreach(IPart part in parts)
            {
                part.Demolish();
            }
            parts.Clear();

            foreach(PartPair pair in pairs)
            {
                pair.Destroy();
            }
            pairs.Clear();

            rigidbody.isKinematic = true;

            gun = null;
            body = null;
            tower = null;
            leftTracks.Clear();
            rightTracks.Clear();
        }


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
