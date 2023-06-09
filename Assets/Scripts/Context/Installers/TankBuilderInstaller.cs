using UnityEngine;
using Zenject;

namespace Game.Context
{
    public class TankBuilderInstaller : MonoInstaller
    { 
        public override void InstallBindings()
        {
            Container.Bind<TankBuilder>()
                .FromNew()
                .AsSingle();
        }
    }
}