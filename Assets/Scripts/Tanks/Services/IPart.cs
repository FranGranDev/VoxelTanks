using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public interface IPart
    {
        Rigidbody Rigidbody { get; }
        Transform Transform { get; }
        Collider Collider { get; }
        List<PartPoint> Points { get; }
        PartTypes Type { get; }

        void Accept(IPartInstaller installer);
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
    }


    public interface IPartInstaller
    {
        void Install(IBody body);
        void Install(ITrack track);
    }
}
