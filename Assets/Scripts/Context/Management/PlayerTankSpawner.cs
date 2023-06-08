using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.Tanks;


namespace Game.Context
{
    public class PlayerTankSpawner : MonoBehaviour
    {
        [Inject]
        private IFactory<Tank> tankFactory;

        private void Start()
        {
            Tank tank = tankFactory.Create();
        }
    }
}
