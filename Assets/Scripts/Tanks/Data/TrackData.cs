using UnityEngine;

namespace Game.Tanks
{
    [CreateAssetMenu(menuName = "Tank Parts/Track")]
    public class TrackData : ScriptableObject
    {
        [SerializeField] private GameObject smallTrack;
        [SerializeField] private GameObject mediumTrack;
        [SerializeField] private GameObject bigTrack;


        public GameObject GetTrack(TrackTypes types)
        {
            switch(types)
            {
                case TrackTypes.None:
                    return null;
                case TrackTypes.Small:
                    return smallTrack;
                case TrackTypes.Medium:
                    return mediumTrack;
                case TrackTypes.Big:
                    return bigTrack;
                default:
                    return null;
            }
        }
    }
}
