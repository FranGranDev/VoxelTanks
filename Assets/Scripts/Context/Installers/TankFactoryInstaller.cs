using UnityEngine;
using Zenject;
using Game.Tanks;
using Game.Tanks.Factory;

namespace Game.Context
{
    public class TankFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IFactory<Tank>>()
                .To<TankFactory>()
                .FromNew()
                .AsSingle();
        }
    }
}