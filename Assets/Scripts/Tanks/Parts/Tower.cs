using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class Tower : Part, ITower
    {
        public override PartTypes Type => PartTypes.Tower;


        public void Rotate(float angle)
        {

        }

        public override void Accept(IPartInstaller installer)
        {
            installer.Install(this);
        }
    }
}
