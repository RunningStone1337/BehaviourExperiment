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

    public static List<(T, float)> Normalize<T>(this List<(T Key, float Value)> input)
    {
        var normalized = new List<(T, float)>();
        var total = input.Select(x => x.Value).Sum();
        for (int i = 0; i < input.Count; i++)
            normalized.Add((input[i].Key, input[i].Value / total));
        return normalized;
    }
    public static List<(T, float)> Normalize<T>(this List<(T Key, int Value)> input)
    {
        var normalized = new List<(T, float)>();
        var total = input.Select(x => x.Value).Sum();
        for (int i = 0; i < input.Count; i++)
            normalized.Add((input[i].Key, input[i].Value / total));
        return normalized;
    }
    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
    public static KeyValuePair<T, float> SelectRandomFromNormalized<T>(this List<KeyValuePair<T, float>> normalized)
    {
        var cum = normalized.GetCumulativeList();
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

    public static (T, float) SelectRandomFromNormalized<T>(this List<(T Key, float Value)> normalized)
    {
        var cum = normalized.GetCumulativeList();
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
        return cum.LastOrDefault();
    }
    public static (T, int) SelectRandomFromNormalized<T>(this List<(T Key, int Value)> normalized)
    {
        var cum = normalized.GetCumulativeList();
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
        return cum.LastOrDefault();
    }

    public static (T Key, float Value) SelectRandom<T>(this List<(T Key, float Value)> nonNormalized)
    {
        var cum = nonNormalized.Normalize();
        return cum.SelectRandomFromNormalized();
    }
    public static (T Key, float Value) SelectRandom<T>(this List<(T Key, int Value)> nonNormalized)
    {
        var cum = nonNormalized.Normalize();
        return cum.SelectRandomFromNormalized();
    }

    public static List<KeyValuePair<T, float>> GetCumulativeList<T>(this List<KeyValuePair<T, float>> norm)
    {
        var cumul = new List<KeyValuePair<T, float>>();
        for (int i = 0; i < norm.Count; i++)
        {
            if (i != 0)
                cumul.Add(new KeyValuePair<T, float>(norm[i].Key, norm[i].Value + cumul[i - 1].Value));
            else
                cumul.Add(new KeyValuePair<T, float>(norm[0].Key, norm[0].Value));
        }
        return cumul;
    }

    public static List<(T Key, float Value)> GetCumulativeList<T>(this List<(T Key, float Value)> norm)
    {
        var cumul = new List<(T, float)>();
        for (int i = 0; i < norm.Count; i++)
        {
            if (i != 0)
                cumul.Add((norm[i].Key, norm[i].Value + cumul[i - 1].Item2));
            else
                cumul.Add((norm[0].Key, norm[0].Value));
        }
        return cumul;
    }
    public static List<(T Key, int Value)> GetCumulativeList<T>(this List<(T Key, int Value)> norm)
    {
        var cumul = new List<(T, int)>();
        for (int i = 0; i < norm.Count; i++)
        {
            if (i != 0)
                cumul.Add((norm[i].Key, norm[i].Value + cumul[i - 1].Item2));
            else
                cumul.Add((norm[0].Key, norm[0].Value));
        }
        return cumul;
    }
}