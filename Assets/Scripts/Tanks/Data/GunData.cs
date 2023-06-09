using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    [CreateAssetMenu(menuName = "Tank Parts/Gun")]
    public class GunData : ScriptableObject
    {
        [SerializeField] private GameObject smallGun;
        [SerializeField] private GameObject mediumGun;
        [SerializeField] private GameObject bigGun;


        public GameObject GetGun(GunTypes types)
        {
            switch (types)
            {
                case GunTypes.Small:
                    return smallGun;
                case GunTypes.Medium:
                    return mediumGun;
                case GunTypes.Big:
                    return bigGun;
                default:
                    return null;
            }
        }
    }
}
