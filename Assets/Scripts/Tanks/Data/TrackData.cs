using UnityEngine;

namespace Game.Tanks
{
    [CreateAssetMenu(menuName = "Tank Parts/Track")]
    public class TrackData : ScriptableObject
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
