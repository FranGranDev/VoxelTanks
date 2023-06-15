using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class Gun : Part, IGun
    {
        [Header("Gun Settings")]
        [SerializeField] private float power;
        [SerializeField] private float reloadTime;
        [Header("Components")]
        [SerializeField] private Transform firePoint;
        [SerializeField] private new Collider collider;

        public override PartTypes Type
        {
            get => PartTypes.Gun;
        }

        private IAmmo ammo;
        private bool reloaded;
        private bool reloading;

        private Vector3 target;


        public override void Initialize(Rigidbody rigidbody)
        {
            base.Initialize(rigidbody);

            Reload();
        }

        public async void Reload()
        {
            if (reloading || reloaded)
                return;
            reloading = true;

            await UniTask.Delay(reloadTime);
            reloaded = true;
            reloading = false;
        }
        public void SetAmmo(IAmmo ammo)
        {
            this.ammo = ammo;
        }
        public void Shot()
        {
            if (!reloaded)
            {
                Reload();
                return;
            }

            IBullet bullet = ammo.Bullets.Create();
            Physics.IgnoreCollision(bullet.Collider, collider);

            bullet.Set(firePoint);
            bullet.Fire(power, firePoint.forward);

            parent.AddForceAtPosition(-firePoint.forward * power * bullet.Mass * 0.25f, firePoint.position, ForceMode.VelocityChange);

            reloaded = false;
            Reload();
        }
        public void Aim(Vector3 target)
        {
            this.target = target;
        }

        private void Rotate()
        {
            if (target == default)
                return;

            float angle = CalculateAngle(target);


            Quaternion localRotation = Quaternion.Euler(Mathf.Clamp(angle, -45, 15f), 0, 0);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, localRotation, 0.1f);
        }
        private float CalculateAngle(Vector3 target)
        {
            Vector3 vector = (firePoint.position - target);
            float distance = vector.magnitude;

            float time = distance / power;

            float fallY = time * time * Physics.gravity.y / 2;


            return Mathf.Atan((vector.y + fallY) / distance) * Mathf.Rad2Deg;
        }

        private void FixedUpdate()
        {
            Rotate();
        }

        public override void Accept(IPartInstaller installer)
        {
            installer.Install(this);
        }
    }
}
