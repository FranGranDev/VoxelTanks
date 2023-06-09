using UnityEngine;

namespace Game.Tanks
{
    [CreateAssetMenu(menuName = "Tank Parts/Body")]
    public class BodyData : ScriptableObject
    {
        [SerializeField] private GameObject smallBody;
        [SerializeField] private GameObject mediumBody;
        [SerializeField] private GameObject bigBody;


        public GameObject GetBody(BodyTypes types)
        {
            switch (types)
            {
                case BodyTypes.Small:
                    return smallBody;
                case BodyTypes.Medium:
                    return mediumBody;
                case BodyTypes.Big:
                    return bigBody;
                default:
                    return null;
            }
        }
    }
}
