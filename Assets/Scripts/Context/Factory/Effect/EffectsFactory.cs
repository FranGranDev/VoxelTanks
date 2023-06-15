using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Game.Tanks;

namespace Game.Context
{
    public class EffectsFactory : IFactory<HitInfo, float, IEffect>
    {
        [Inject]
        private EffectsData effectsData;

        [Inject]
        private DiContainer container;

        public IEffect Create(HitInfo hitInfo, float duration)
        {
            GameObject instance = container.InstantiatePrefab(effectsData.HitEffect);

            instance.transform.SetParent(hitInfo.Origin);
            instance.transform.position = hitInfo.Position;
            instance.transform.forward = hitInfo.Normal;

            IEffect effect = instance.GetComponent<IEffect>();

            effect.Activate(duration);

            return effect;
        }
    }
}
