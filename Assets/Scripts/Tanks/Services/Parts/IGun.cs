using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public interface IGun : IPart
    {
        public void SetAmmo(IAmmo ammo);

        public void Shot();
        public void Reload();
        public void Aim(Vector3 target);
    }

    public enum GunTypes
    {
        None,
        Small,
        Medium,
        Big,
    }
}