using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Tanks;
using Zenject;


namespace Game.Context
{
    public class TrackFactory : IFactory<TrackTypes, ITrack>
    {
        [Inject]
        private TrackData trackData;

        [Inject]
        private DiContainer container;


        public ITrack Create(TrackTypes param)
        {
            return container.InstantiatePrefabForComponent<ITrack>(trackData.GetTrack(param));
        }
    }
}
