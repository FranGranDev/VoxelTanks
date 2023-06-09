using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Tanks
{
    [CreateAssetMenu(menuName = "Tank Parts/Bullets")]
    public class AmmoData : ScriptableObject
    {
        [SerializeField] private GameObject ammo;
        [Space]
        [SerializeField] private Bullet bullet;

        public GameObject GetAmmo
        {
            get => ammo;
        }
        public GameObject GetBullet(BulletTypes types)
        {
            switch(types)
            {
                case BulletTypes.Base:
                    return bullet.gameObject;
                default:
                    return bullet.gameObject;
            }
        }
    }
}
