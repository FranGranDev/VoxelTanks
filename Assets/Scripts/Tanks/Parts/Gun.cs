using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class Gun : Part, IGun
    {
        public override PartTypes Type
        {
            get => PartTypes.Gun;
        }

        private IAmmo ammo;


        public void Reload()
        {
            
        }
        public void SetAmmo(IAmmo ammo)
        {
            this.ammo = ammo;
        }
        public void Shot()
        {
            
        }

        public override void Accept(IPartInstaller installer)
        {
            installer.Install(this);
        }
    }
}
