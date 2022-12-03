using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtension 
{
    public static void Disable(this GameObject go)
    {
        go.SetActive(false);
    }
    public static void Enable(this GameObject go)
    {
        go.SetActive(true);
    }
}
