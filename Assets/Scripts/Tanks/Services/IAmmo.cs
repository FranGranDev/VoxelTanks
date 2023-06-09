using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Tanks
{
    public interface IAmmo : IPart
    {
        public IFactory<IBullet> Bullets { get; set; }
    }
}
