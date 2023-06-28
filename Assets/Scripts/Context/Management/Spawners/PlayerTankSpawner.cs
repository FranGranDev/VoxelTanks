using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.Tanks;
using Game.UserInput;
using Game.Context.Factory;
using Game;


namespace Game.Context
{
    public class PlayerTankSpawner : TankSpanwer
    {
        [Header("Settings")]
        [SerializeField] private BodyTypes bodyType;
        [SerializeField] private TowerTypes towerType;
        [SerializeField] private GunTypes gunType;
        [SerializeField] private BulletTypes bulletType;
        [SerializeField] private TrackTypes trackType;
        [Header("Components")]
        [SerializeField] private Transform spawnPoint;

        [Inject]
        private TankBuilder tankBuilder;

        [Inject]
        private PlayerCamera playerCamera;


        public override Tank Spawn()
        {
            Tank tank = tankBuilder.New()
                .Position(spawnPoint.position)
                .Rotation(spawnPoint.rotation)
                .Parent(spawnPoint.parent)
                .Body(bodyType)
                .Tower(towerType)
                .Gun(gunType)
                .Ammo(bulletType)
                .Track(trackType)
                .With<TankController>()
                .With<Player>()
                .Bind(playerCamera)
                .Create();

            return tank;
        }
    }
}
