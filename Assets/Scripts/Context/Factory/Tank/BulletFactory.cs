using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.Tanks;

namespace Game.Context
{
    public class BulletFactory : IFactory<IBullet>
    {
        public BulletFactory(BulletTypes bulletTypes)
        {
            this.bulletTypes = bulletTypes;
        }

        private BulletTypes bulletTypes;

        [Inject]
        private AmmoData ammoData;

        [Inject]
        private DiContainer container;

        public IBullet Create()
        {
            return container.InstantiatePrefabForComponent<IBullet>(ammoData.GetBullet(bulletTypes));
        }
    }
}
