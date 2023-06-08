using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public interface IGun : IPart
    {
        public void Shot();
        public void Reload();
    }
}