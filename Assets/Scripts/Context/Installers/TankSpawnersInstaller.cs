using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Context
{
    public class TankSpawnersInstaller : MonoInstaller
    {
        [SerializeField] private TankSpanwer playerTankSpawner;
        [SerializeField] private TankSpanwer enemyTankSpawner;

        public override void InstallBindings()
        {
            Container.Bind<TankSpanwer>()
                .WithId("Player")
                .FromInstance(playerTankSpawner);

            Container.Bind<TankSpanwer>()
                .WithId("Enemy")
                .FromInstance(enemyTankSpawner);
        }
    }
}
