using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Tanks
{
    public abstract class Part : MonoBehaviour, IPart
    {
        [Header("Components")]
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private new Collider collider;
        [Header("Points")]
        [SerializeField] private List<PartPoint> points;


        public Rigidbody Rigidbody
        {
            get => rigidbody;
        }
        public Transform Transform
        {
            get => transform;
        }
        public Collider Collider
        {
            get => collider;
        }
        public List<PartPoint> Points
        {
            get => points;
        }
        public abstract PartTypes Type { get; }

        public abstract void Accept(IPartInstaller installer);

        public void Demolish()
        {
            Destroy(gameObject);
        }
    }
}
