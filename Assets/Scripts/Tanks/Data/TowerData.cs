using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    [CreateAssetMenu(menuName = "Tank Parts/Towers")]
    public class TowerData : ScriptableObject
    {
        [SerializeField] private GameObject smallTower;
        [SerializeField] private GameObject mediumTower;
        [SerializeField] private GameObject bigTower;

        
        public GameObject GetTower(TowerTypes towerTypes)
        {
            switch(towerTypes)
            {
                case TowerTypes.Small:
                    return smallTower;
                case TowerTypes.Medium:
                    return mediumTower;
                case TowerTypes.Big:
                    return bigTower;
                default:
                    return null;
            }
        }
    }
}
