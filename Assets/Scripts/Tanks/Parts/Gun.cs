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


        public override void Initialize()
        {
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

            reloaded = false;

            Reload();
        }

        public override void Join(IPart other)
        {
            base.Join(other);

            transform.parent = other.Transform;
            if (Rigidbody)
            {
                Rigidbody.isKinematic = true;
            }
        }
        public override void Accept(IPartInstaller installer)
        {
            installer.Install(this);
        }
    }
}
