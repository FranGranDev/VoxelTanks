using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public interface IBodyControll
    {
        void Drive(float direction);
        void Turn(float turn);
    }

    public interface ITowerControll
    {
        void Turn(Vector3 target);
    }
    public interface IGunControll
    {
        void Fire();
    }
}
