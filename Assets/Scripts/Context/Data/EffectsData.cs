using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Context
{
    [CreateAssetMenu(menuName = "Effects/Data")]
    public class EffectsData : ScriptableObject
    {
        [SerializeField] private GameObject hitEffect;

        public GameObject HitEffect
        {
            get => hitEffect;
        }
    }
}