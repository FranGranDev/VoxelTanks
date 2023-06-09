using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    [CreateAssetMenu(menuName = "Tank Parts/Cannons")]
    public class CannonData : ScriptableObject
    {
        [SerializeField] private Track baseTrack;
        [SerializeField] private Track fastTrack;
        [SerializeField] private Track superFastTrack;

        public Track BaseTrack
        {
            get => baseTrack;
        }
    }
}
