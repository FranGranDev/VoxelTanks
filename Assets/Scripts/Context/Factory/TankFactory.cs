using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


namespace Game.Tanks.Factory
{
    public class TankFactory : IFactory<Tank>
    {
        [Inject]
        private TankData tankData;
        [Inject]
        private BodyData bodyData;
        [Inject]
        private TrackData trackData;

        [Inject]
        private DiContainer container;

        public Tank Create()
        {
            Tank tank = container.InstantiatePrefabForComponent<Tank>(tankData.Tank);

            //tank.InstallPart(bodyFactory.Create());
            //tank.InstallPart(trackFactory.Create());
            //tank.InstallPart(trackFactory.Create());

            return tank;
        }
    }
}
