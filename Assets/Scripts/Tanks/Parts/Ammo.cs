using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Tanks
{
    public class Ammo : Part, IAmmo
    {
        public override PartTypes Type => PartTypes.Ammo;

        public IFactory<IBullet> Bullets { get; set; }


        public override void Accept(IPartInstaller installer)
        {
            installer.Install(this);
        }
    }
}
