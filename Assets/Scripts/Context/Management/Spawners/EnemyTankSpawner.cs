using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Services;
using Zenject;
using Game.Tanks;

namespace Game.Context
{
    public class EnemyTankSpawner : TankSpanwer
    {
        [Header("Settings")]
        [SerializeField] private float spawnHeight;
        [SerializeField] private float spawnRadius;
        [Header("Components")]
        [SerializeField] private List<Transform> spawnPoints;

        [Inject]
        private TankBuilder tankBuilder;


        public override Tank Spawn()
        {
            Vector3 offset = Random.insideUnitSphere * spawnRadius;
            offset.y = spawnHeight;
            Vector3 point = spawnPoints.RandomItem().position;

            Tank tank = tankBuilder.New()
                .Position(point + offset)
                .Rotation(Quaternion.Euler(0, Random.Range(-180, 180), 0))
                .Body(BodyTypes.Small)
                .Tower(TowerTypes.Small)
                .Gun(GunTypes.Small)
                .Ammo(BulletTypes.Base)
                .Track(TrackTypes.Medium)
                .Create();

            return tank;
        }
    }
}
