using System.Collections.Generic;
using UnityEngine;

public static partial class Vetor2IntExtensions
{
    public static List<int> GetDiapazoneBetweenXY(this Vector2Int v)
    {
        var res = new List<int>();
        if (v.x > v.y)
            throw new System.Exception("X must me less or equal Y");
        for (int start = v.x; start <= v.y; start++)
            res.Add(start);
        return res;
    }
    public static Vector2 RotateFrom(this Vector2 v, float a, bool bUseRadians = false)
    {
        if (!bUseRadians) a *= Mathf.Deg2Rad;
        var ca = Mathf.Cos(a);
        var sa = Mathf.Sin(a);
        var rx = v.x * ca - v.y * sa;

        return new Vector2((float)rx, (float)(v.x * sa + v.y * ca));
    }
}