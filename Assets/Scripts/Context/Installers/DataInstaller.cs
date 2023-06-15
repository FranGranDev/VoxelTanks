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
        [SerializeField] private TowerData towerData;
        [SerializeField] private GunData gunData;
        [SerializeField] private AmmoData ammoData;
        [Space]
        [SerializeField] private EffectsData effectsData;

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

            Container.Bind<AmmoData>()
                .FromInstance(ammoData)
                .AsSingle();

            Container.Bind<TowerData>()
                .FromInstance(towerData)
                .AsSingle();

            Container.Bind<GunData>()
                .FromInstance(gunData)
                .AsSingle();


            Container.Bind<EffectsData>()
                .FromInstance(effectsData)
                .AsSingle();
        }
    }
}