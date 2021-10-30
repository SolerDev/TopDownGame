using System;
using UnityEngine;

namespace Extensions
{
    public static class GameObjectX
    {
        public static T AddComponent<T>(this GameObject go, T toCopy) where T : Component
        {
            return go.AddComponent<T>().GetCopyOf(toCopy);
        }
    }
}