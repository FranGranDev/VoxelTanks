using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.Tanks;

namespace Game.Context
{
    public class EffectFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IFactory<HitInfo, float, IEffect>>()
                .To<EffectsFactory>()
                .FromNew()
                .AsSingle();
        }
    }
}
