using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Tanks
{
    public interface IBody : IPart
    {
        void Drive(float direction);
        void Turn(float turn);
    }
}
