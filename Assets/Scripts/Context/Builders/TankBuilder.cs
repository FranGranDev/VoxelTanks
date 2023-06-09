using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.Context.Factory;
using Game.Tanks;


namespace Game.Context
{
    public class TankBuilder
    {
        [Inject]
        private TankFactory tankFactory;


        public Instance New()
        {
            return new Instance(tankFactory);
        }


        public class Instance
        {
            internal Instance(TankFactory tankFactory)
            {
                this.tankFactory = tankFactory;
            }
            private TankFactory tankFactory;


            private Vector3 position;
            private Quaternion rotation;
            private Transform parent;

            private BodyTypes bodyType;
            private TowerTypes towerType;
            private GunTypes gunType;
            private BulletTypes bulletType;
            private TrackTypes trackType;


            public Instance Position(Vector3 argument)
            {
                position = argument;
                return this;
            }
            public Instance Rotation(Quaternion argument)
            {
                rotation = argument;
                return this;
            }
            public Instance Parent(Transform argument)
            {
                parent = argument;
                return this;
            }
            public Instance Body(BodyTypes argument)
            {
                bodyType = argument;
                return this;
            }
            public Instance Tower(TowerTypes argument)
            {
                towerType = argument;
                return this;
            }
            public Instance Gun(GunTypes argument)
            {
                gunType = argument;
                return this;
            }
            public Instance Ammo(BulletTypes argument)
            {
                bulletType = argument;
                return this;
            }
            public Instance Track(TrackTypes argument)
            {
                trackType = argument;
                return this;
            }


            public Tank Create()
            {
                return tankFactory.Create(position, rotation, parent, bodyType, trackType, towerType, gunType, bulletType);
            }
        }
    }
}
