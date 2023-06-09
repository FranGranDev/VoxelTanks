using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.Tanks;


namespace Game.Context
{
    public class AmmoFactory : IFactory<BulletTypes, IAmmo>
    {
        [Inject]
        private AmmoData ammoData;

        [Inject]
        private DiContainer container;


        public IAmmo Create(BulletTypes param)
        {
            IAmmo ammo = container.InstantiatePrefabForComponent<IAmmo>(ammoData.GetAmmo);
            ammo.Bullets = container.Instantiate<BulletFactory>(new object[1] { param });

            return ammo;
        }
    }
}
