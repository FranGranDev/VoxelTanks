using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.Tanks;
using Game.UserInput;
using Game.Context.Factory;


namespace Game.Context
{
    public class PlayerTankSpawner : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawn;
        [SerializeField] private Transform enemySpawn;

        [Inject]
        private TankBuilder tankBuilder;

        private void Start()
        {
            Tank tank = tankBuilder.New()
                .Position(playerSpawn.position)
                .Rotation(playerSpawn.rotation)
                .Parent(playerSpawn.parent)
                .Body(BodyTypes.Small)
                .Tower(TowerTypes.Small)
                .Gun(GunTypes.Small)
                .Ammo(BulletTypes.Base)
                .Track(TrackTypes.Medium)
                .With<TankController>()
                .Create();

            Tank enemy = tankBuilder.New()
                .Position(enemySpawn.position)
                .Rotation(enemySpawn.rotation)
                .Parent(enemySpawn.parent)
                .Body(BodyTypes.Small)
                .Tower(TowerTypes.Small)
                .Gun(GunTypes.Small)
                .Ammo(BulletTypes.Base)
                .Track(TrackTypes.Small)
                .Create();
        }
    }
}
