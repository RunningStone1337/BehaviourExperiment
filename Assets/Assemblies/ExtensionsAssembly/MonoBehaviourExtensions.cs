using UnityEngine;

public static class MonoBehaviourExtensions
{
    public static bool Equals<T>(this MonoBehaviour mb)
    {
        return mb.GetType().Equals<T>();
    }
}