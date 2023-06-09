using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Tanks
{
    public abstract class Part : MonoBehaviour, IPart
    {
        [Header("Components")]
        [SerializeField] private new Rigidbody rigidbody;
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
        public List<PartPoint> Points
        {
            get => points;
        }
        public IPart Parent
        {
            get;
            private set;
        }
        public abstract PartTypes Type
        {
            get;
        }


        public virtual void Initialize()
        {

        }
        public abstract void Accept(IPartInstaller installer);

        public void Demolish()
        {
            Destroy(gameObject);
        }
        public virtual void Join(IPart other)
        {
            Parent = other;
        }
    }
}
