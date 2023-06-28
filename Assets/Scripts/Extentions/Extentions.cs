using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions
{
    public static T RandomItem<T>(this IList<T> list)
    {
        if (list.Count == 0)
            return default;

        return list[Random.Range(0, list.Count)];
    }
}
