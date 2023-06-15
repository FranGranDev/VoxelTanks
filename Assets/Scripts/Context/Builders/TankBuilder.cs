using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.Context.Factory;
using Game.Tanks;
using System;

namespace Game.Context
{
    public class TankBuilder
    {
        [Inject]
        private TankFactory tankFactory;

        [Inject]
        private DiContainer container;

        public Instance New()
        {
            return new Instance(tankFactory, container);
        }


        public class Instance
        {
            internal Instance(TankFactory tankFactory, DiContainer container)
            {
                this.tankFactory = tankFactory;
                this.container = container;

                addedComponents = new List<Type>();
            }
            private TankFactory tankFactory;
            private DiContainer container;


            private Vector3 position;
            private Quaternion rotation;
            private Transform parent;

            private BodyTypes bodyType;
            private TowerTypes towerType;
            private GunTypes gunType;
            private BulletTypes bulletType;
            private TrackTypes trackType;


            private List<Type> addedComponents;



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

            public Instance With<T>() where T : Component
            {
                addedComponents.Add(typeof(T));
                return this;
            }


            public Tank Create()
            {
                Tank tank = tankFactory.Create(position, rotation, parent, bodyType, trackType, towerType, gunType, bulletType);


                foreach(Type type in addedComponents)
                {
                    container.InstantiateComponent(type, tank.gameObject);
                }
                addedComponents.Clear();

                return tank;
            }
        }
    }
}
