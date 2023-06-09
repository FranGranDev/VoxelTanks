using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.Tanks;
using Game.Context.Factory;


namespace Game.Context
{
    public class PlayerTankSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawn;

        [Inject]
        private TankBuilder tankBuilder;

        private void Start()
        {
            Tank tank = tankBuilder.New()
                .Position(spawn.position)
                .Rotation(spawn.rotation)
                .Parent(spawn.parent)
                .Body(BodyTypes.Small)
                .Tower(TowerTypes.Small)
                .Gun(GunTypes.Small)
                .Ammo(BulletTypes.Base)
                .Track(TrackTypes.Small)
                .Create();
        }
    }
}
