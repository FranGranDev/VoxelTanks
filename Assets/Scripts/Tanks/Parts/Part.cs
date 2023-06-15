using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Tanks
{
    public abstract class Part : MonoBehaviour, IPart
    {
        [Header("Settings")]
        [SerializeField] private int hp = 1;
        [SerializeField] private float destroyForce = 15;
        [SerializeField] private float destroyAngular = 180;
        [Header("Points")]
        [SerializeField] private List<PartPoint> points;

        protected Rigidbody parent;

        public int MaxHp
        {
            get => hp;
        }
        public Transform Transform
        {
            get => transform;
        }
        public List<PartPoint> Points
        {
            get => points;
        }
        public abstract PartTypes Type
        {
            get;
        }


        public virtual void Initialize(Rigidbody parent)
        {
            this.parent = parent;
        }
        public abstract void Accept(IPartInstaller installer);

        public void Demolish()
        {
            transform.parent = null;

            Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();

            Vector3 direction = (rigidbody.position - parent.position);
            rigidbody.velocity = parent.velocity + direction * destroyForce;
            rigidbody.angularVelocity = Random.onUnitSphere * destroyAngular;

            OnDemolish(rigidbody);

            Hide();
        }
        protected virtual void OnDemolish(Rigidbody rigidbody)
        {

        }
        private async void Hide()
        {
            await UniTask.Delay(10f);

            float animationTime = 1f;
            Vector3 scale = transform.localScale;
            for(float time = 0; time < animationTime; time += Time.fixedDeltaTime)
            {
                transform.localScale = Vector3.Lerp(scale, Vector3.zero, time / animationTime);

                await UniTask.WaitForFixedUpdate();
            }

            Destroy(gameObject);
        }

        public void Join(IPart other)
        {
            transform.parent = other.Transform;
        }
    }
}
