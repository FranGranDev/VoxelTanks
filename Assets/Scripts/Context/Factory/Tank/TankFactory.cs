using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.Tanks;


namespace Game.Context.Factory
{
    public class TankFactory
    {
        [Inject]
        private TankData tankData;

        [Inject]
        private IFactory<BodyTypes, IBody> bodyFactory;

        [Inject]
        private IFactory<TowerTypes, ITower> towerFactory;

        [Inject]
        private IFactory<TrackTypes, ITrack> trackFactory;

        [Inject]
        private IFactory<BulletTypes, IAmmo> ammoFactory;

        [Inject]
        private IFactory<GunTypes, IGun> gunFactory;

        [Inject]
        private DiContainer container;


        public Tank Create(Vector3 position, Quaternion rotation, Transform parent, BodyTypes body, TrackTypes track, TowerTypes tower, GunTypes gun, BulletTypes bullet)
        {
            Tank tank = container.InstantiatePrefabForComponent<Tank>(tankData.Tank);
            tank.transform.position = position;
            tank.transform.rotation = rotation;
            tank.transform.SetParent(parent);

            tank.InstallPart(bodyFactory.Create(body));
            tank.InstallPart(towerFactory.Create(tower));
            tank.InstallPart(gunFactory.Create(gun));
            tank.InstallPart(ammoFactory.Create(bullet));

            tank.InstallPart(trackFactory.Create(track));
            tank.InstallPart(trackFactory.Create(track));

            tank.Initialize();

            return tank;
        }
    }
}
