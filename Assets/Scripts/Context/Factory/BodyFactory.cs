using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.Tanks;

namespace Game.Context
{
    public class BodyFactory : IFactory<BodyTypes, IBody>
    {
        [Inject]
        private BodyData bodyData;

        [Inject]
        private DiContainer container;

        public IBody Create(BodyTypes param)
        {
            return container.InstantiatePrefabForComponent<IBody>(bodyData.GetBody(param));
        }
    }
}
