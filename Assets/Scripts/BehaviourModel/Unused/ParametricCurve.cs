using System;
using Unity.Mathematics;

public enum ParametricCurveType
{
    Bypass,
    Step,
    Linear,
    Exponential,
    Sine,
    Logistic,
    Logit,
}

[Serializable]
public struct ParametricCurve
{
    public ParametricCurveType CurveType;
    public float HorizontalShift;
    public float Scale;
    public float Shape;
    public float VerticalShift;

    public static ParametricCurve GetDefault(ParametricCurveType curveType)
    {
        ParametricCurve newCurve = new ParametricCurve();
        newCurve.CurveType = curveType;

        switch (curveType)
        {
            case ParametricCurveType.Step:
                newCurve.Shape = 0f;
                newCurve.Scale = 1f;
                newCurve.VerticalShift = 0f;
                newCurve.HorizontalShift = 0.5f;
                break;

            case ParametricCurveType.Linear:
                newCurve.Shape = 0f;
                newCurve.Scale = 1f;
                newCurve.VerticalShift = 0f;
                newCurve.HorizontalShift = 0f;
                break;

            case ParametricCurveType.Exponential:
                newCurve.Shape = 2f;
                newCurve.Scale = 1f;
                newCurve.VerticalShift = 0f;
                newCurve.HorizontalShift = 0f;
                break;

            case ParametricCurveType.Sine:
                newCurve.Shape = 2f;
                newCurve.Scale = 0.5f;
                newCurve.VerticalShift = 0.5f;
                newCurve.HorizontalShift = 0f;
                break;

            case ParametricCurveType.Logistic:
                newCurve.Shape = 1f;
                newCurve.Scale = 1f;
                newCurve.VerticalShift = 0f;
                newCurve.HorizontalShift = 0f;
                break;

            case ParametricCurveType.Logit:
                newCurve.Shape = 3f;
                newCurve.Scale = 1f;
                newCurve.VerticalShift = 0f;
                newCurve.HorizontalShift = 0f;
                break;
        }

        return newCurve;
    }

    public float Evaluate(float t)
    {
        switch (CurveType)
        {
            case ParametricCurveType.Bypass:
                {
                    return 0f;
                }
            case ParametricCurveType.Step:
                {
                    if (t >= HorizontalShift)
                    {
                        return Scale + VerticalShift;
                    }
                    else
                    {
                        return VerticalShift;
                    }
                }
            case ParametricCurveType.Linear:
                {
                    float tb = t - HorizontalShift;
                    return (Scale * (tb)) + VerticalShift;
                }
            case ParametricCurveType.Exponential:
                {
                    float tb = t - HorizontalShift;
                    return (Scale * (1f - ((1f - math.pow(tb, Shape)) / 1f))) + VerticalShift;
                }
            case ParametricCurveType.Sine:
                {
                    return (Scale * math.cos((t * math.PI * Shape) + (HorizontalShift * math.PI))) + VerticalShift;
                }
            case ParametricCurveType.Logistic:
                {
                    float tb = t - HorizontalShift;
                    return (Scale / (1f + math.pow(math.E, -Shape * ((4f * math.E * tb) - (2f * math.E))))) + VerticalShift;
                }
            case ParametricCurveType.Logit:
                {
                    float tb = t - HorizontalShift;
                    float logResult = math.log(tb / (1f - tb)) / math.log(Shape); // log(val, base) = log(val) / log(base)
                    return (Scale * ((logResult + 5f) / 10f)) + VerticalShift;
                }
        }

        return 0f;
    }
}