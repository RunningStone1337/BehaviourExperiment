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
}