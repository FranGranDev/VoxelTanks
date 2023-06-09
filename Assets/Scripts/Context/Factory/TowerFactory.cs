using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Tanks;
using Zenject;

namespace Game.Context
{
    public class TowerFactory : IFactory<TowerTypes, ITower>
    {
        [Inject]
        private TowerData towerData;

        [Inject]
        private DiContainer container;

        public ITower Create(TowerTypes param)
        {
            return container.InstantiatePrefabForComponent<ITower>(towerData.GetTower(param));
        }
    }
}
