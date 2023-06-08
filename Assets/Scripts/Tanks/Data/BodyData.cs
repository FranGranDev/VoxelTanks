using UnityEngine;

namespace Game.Tanks
{
    [CreateAssetMenu(menuName = "Tank Parts/Body")]
    public class BodyData : ScriptableObject
    {
        [SerializeField] private Body body;

        public Body Body
        {
            get => body;
        }
    }
}
