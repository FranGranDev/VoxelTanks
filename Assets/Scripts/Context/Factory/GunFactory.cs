using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Tanks;
using Zenject;


namespace Game.Context
{
    public class GunFactory : IFactory<GunTypes, IGun>
    {
        [Inject]
        private GunData gunData;

        [Inject]
        private DiContainer container;


        public IGun Create(GunTypes param)
        {
            return container.InstantiatePrefabForComponent<IGun>(gunData.GetGun(param));
        }
    }
}
