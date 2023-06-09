using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Tanks
{
    public interface IBody : IPart
    {

    }

    public enum BodyTypes
    {
        None,
        Small,
        Medium,
        Big,
    }
}
