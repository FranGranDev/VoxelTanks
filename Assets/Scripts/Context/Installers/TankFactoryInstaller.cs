using UnityEngine;
using Zenject;
using Game.Tanks;
using Game.Context.Factory;


namespace Game.Context
{
    public class TankFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {            
            Container.Bind<IFactory<BodyTypes, IBody>>()
                .To<BodyFactory>()
                .AsSingle();

            Container.Bind<IFactory<TowerTypes, ITower>>()
                .To<TowerFactory>()
                .AsSingle();

            Container.Bind<IFactory<TrackTypes, ITrack>>()
                .To<TrackFactory>()
                .AsSingle();

            Container.Bind<IFactory<GunTypes, IGun>>()
                .To<GunFactory>()
                .AsSingle();

            Container.Bind<IFactory<BulletTypes, IAmmo>>()
                .To<AmmoFactory>()
                .AsSingle();

            Container.Bind<TankFactory>()
                .FromNew()
                .AsSingle();
        }
    }
}