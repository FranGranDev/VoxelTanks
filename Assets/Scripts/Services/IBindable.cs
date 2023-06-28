using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Services
{
    public interface IBindable<T> where T: class
    {
        void Bind(T obj);
    }
}
