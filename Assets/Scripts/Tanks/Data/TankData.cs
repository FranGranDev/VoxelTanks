using UnityEngine;

namespace Game.Tanks
{
    [CreateAssetMenu(menuName = "Tanks/Tank")]
    public class TankData : ScriptableObject
    {
        [SerializeField] private Tank tank;

        public Tank Tank
        {
            get => tank;
        }
    }
}
