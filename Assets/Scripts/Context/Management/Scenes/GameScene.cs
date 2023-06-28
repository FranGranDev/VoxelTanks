using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Context
{
    public class GameScene : BaseScene
    {
        [Inject(Id = "Player")]
        private TankSpanwer playerSpanwer;

        [Inject(Id = "Enemy")]
        private TankSpanwer enemySpanwer;

        private void Start()
        {
            playerSpanwer.Spawn();
            enemySpanwer.Spawn();
        }
    }
}
