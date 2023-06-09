using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public interface IPart
    {
        Rigidbody Rigidbody { get; }
        Transform Transform { get; }
        List<PartPoint> Points { get; }
        PartTypes Type { get; }


        void Initialize();
        void Accept(IPartInstaller installer);

        void Join(IPart other);
        void Demolish();
    }

    [System.Serializable]
    public class PartPoint
    {
        [SerializeField] private PartTypes type;
        [SerializeField] private Transform point;


        public PartTypes Type
        {
            get => type;
        }
        public Transform Place
        {
            get => point;
        }
        public bool Installed
        {
            get; set;
        }
    }

    public enum PartTypes
    {
        Body,
        Track,
        Tower,
        Gun,
        Ammo,
    }


    public interface IPartInstaller
    {
        void Install(IBody body);
        void Install(ITrack track);
        void Install(ITower tower);
        void Install(IGun gun);
        void Install(IAmmo ammo);
    }
}
