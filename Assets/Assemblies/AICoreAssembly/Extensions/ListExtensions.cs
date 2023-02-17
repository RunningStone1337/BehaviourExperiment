using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ListExtensions
{
    public static List<KeyValuePair<T, float>> Normalize<T>(this List<KeyValuePair<T, float>> input)
    {
        List<KeyValuePair<T, float>> normalized = new List<KeyValuePair<T, float>>();
        var total = input.Select(x => x.Value).Sum();
        for (int i = 0; i < input.Count; i++)
            normalized.Add(new KeyValuePair<T, float>(input[i].Key, input[i].Value / total));
        return normalized;
    }

    public static KeyValuePair<T, float> SelectRandom<T>(this List<KeyValuePair<T, float>> normalized)
    {
        var cum = normalized.GetCumulativelist();
        var rand = Random.Range(0f, 1f);
        for (int i = 0; i < cum.Count; i++)
        {
            if (i == 0)
            {
                if (cum[i].Value >= rand)
                    return cum[i];
            }
            else if (cum[i].Value < rand)
                return cum[i - 1];
        }
        return cum.Last();
    }

    public static List<KeyValuePair<T, float>> GetCumulativelist<T>(this List<KeyValuePair<T, float>> norm)
    {
        var cumul = new List<KeyValuePair<T, float>>();
        for (int i = 0; i < norm.Count; i++)
        {
            if (i != 0)
                cumul.Add(new KeyValuePair<T, float>(norm[i].Key, norm[i].Value + norm[i - 1].Value));
            else
                cumul.Add(new KeyValuePair<T, float>(norm[0].Key, norm[0].Value));
        }
        return cumul;
    }
}