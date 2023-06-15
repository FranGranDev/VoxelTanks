using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using Zenject;

namespace Game.Context
{
    public class PlayerCameraInstaller : MonoInstaller
    {
        [SerializeField] private PlayerCamera playerCamera;
        public override void InstallBindings()
        {
            Container.Bind<PlayerCamera>()
                .FromInstance(playerCamera);
        }
    }
}
