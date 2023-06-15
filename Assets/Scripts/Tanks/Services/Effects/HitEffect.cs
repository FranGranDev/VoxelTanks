using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class HitEffect : MonoBehaviour, IEffect
    {
        public async void Activate(float duration)
        {
            await UniTask.Delay(duration);

            Destroy(gameObject);
        }
    }
}
