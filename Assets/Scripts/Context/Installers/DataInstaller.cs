using Game.Tanks;
using UnityEngine;
using Zenject;

namespace Game.Context
{
    [CreateAssetMenu(fileName = "DataInstaller", menuName = "Installers/DataInstaller")]
    public class DataInstaller : ScriptableObjectInstaller<DataInstaller>
    {
        [SerializeField] private TankData tankData;
        [SerializeField] private BodyData bodyData;
        [SerializeField] private TrackData trackData;

        public override void InstallBindings()
        {
            Container.Bind<TankData>()
                .FromInstance(tankData)
                .AsSingle();

            Container.Bind<BodyData>()
                .FromInstance(bodyData)
                .AsSingle();

            Container.Bind<TrackData>()
                .FromInstance(trackData)
                .AsSingle();
        }
    }
}