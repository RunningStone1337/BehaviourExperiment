using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CurveDrawerElement : VisualElement
{
    public float xRangeAttr { get; set; }
    public float yRangeAttr { get; set; }
    public float xIncrementsAttr { get; set; }
    public float yIncrementsAttr { get; set; }
    public bool xHasNegativeAttr { get; set; }
    public bool yHasNegativeAttr { get; set; }
    public float curveThicknessAttr { get; set; }
    public Color curveColorAttr { get; set; }
    public Color mainAxisColorAttr { get; set; }
    public Color incrementAxisColorAttr { get; set; }

    public Func<float, float> CurveEvaluator;

    public List<Vertex> vertices = new List<Vertex>();
    public List<ushort> indices = new List<ushort>();
    public List<Vector2> points = new List<Vector2>();

    public new class UxmlFactory : UxmlFactory<CurveDrawerElement, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlFloatAttributeDescription m_xRange = new UxmlFloatAttributeDescription { name = "xRange-attr", defaultValue = 1f };
        UxmlFloatAttributeDescription m_yRange = new UxmlFloatAttributeDescription { name = "yRange-attr", defaultValue = 1f };
        UxmlFloatAttributeDescription m_xIncrements = new UxmlFloatAttributeDescription { name = "xIncrements-attr", defaultValue = 0.1f };
        UxmlFloatAttributeDescription m_yIncrements = new UxmlFloatAttributeDescription { name = "yIncrements-attr", defaultValue = 0.1f };
        UxmlBoolAttributeDescription m_xHasNegative = new UxmlBoolAttributeDescription { name = "xHasNegative-attr", defaultValue = true };
        UxmlBoolAttributeDescription m_yHasNegative = new UxmlBoolAttributeDescription { name = "yHasNegative-attr", defaultValue = true };
        UxmlFloatAttributeDescription m_curveThickness = new UxmlFloatAttributeDescription { name = "curveThickness-attr", defaultValue = 1f };
        UxmlColorAttributeDescription m_curveColor = new UxmlColorAttributeDescription { name = "curveColor-attr", defaultValue = Color.green };
        UxmlColorAttributeDescription m_mainAxisColor = new UxmlColorAttributeDescription { name = "mainAxisColor-attr", defaultValue = Color.white };
        UxmlColorAttributeDescription m_incrementAxisColor = new UxmlColorAttributeDescription { name = "incrementAxisColor-attr", defaultValue = Color.gray };

        public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
        {
            get { yield break; }
        }

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            CurveDrawerElement drawer = ve as CurveDrawerElement;

            drawer.Clear();

            drawer.xRangeAttr = m_xRange.GetValueFromBag(bag, cc);
            drawer.yRangeAttr = m_yRange.GetValueFromBag(bag, cc);
            drawer.xIncrementsAttr = m_xIncrements.GetValueFromBag(bag, cc);
            drawer.yIncrementsAttr = m_yIncrements.GetValueFromBag(bag, cc);
            drawer.xHasNegativeAttr = m_xHasNegative.GetValueFromBag(bag, cc);
            drawer.yHasNegativeAttr = m_yHasNegative.GetValueFromBag(bag, cc);
            drawer.curveThicknessAttr = m_curveThickness.GetValueFromBag(bag, cc);
            drawer.curveColorAttr = m_curveColor.GetValueFromBag(bag, cc);
            drawer.mainAxisColorAttr = m_mainAxisColor.GetValueFromBag(bag, cc);
            drawer.incrementAxisColorAttr = m_incrementAxisColor.GetValueFromBag(bag, cc);

            drawer.CurveEvaluator = (x) =>
            {
                if (x < 0f)
                {
                    return x * x * -1f;
                }
                else
                {
                    return x * x;
                }
            };

            drawer.generateVisualContent = (ctx) =>
            {
                drawer.vertices.Clear();
                drawer.indices.Clear();
                drawer.points.Clear();

                float gridThickness = 1f;
                float lineThickness = drawer.curveThicknessAttr;

                float w = drawer.layout.width;
                float h = drawer.layout.height;
                float hw = w * 0.5f;
                float hh = h * 0.5f;
                int pixelWidth = Mathf.CeilToInt(w);
                int pixelHeight = Mathf.CeilToInt(h);

                if (drawer.xIncrementsAttr > 0f)
                {
                    int incrementCount = Mathf.FloorToInt(drawer.xRangeAttr / drawer.xIncrementsAttr);
                    for (int i = 0; i < incrementCount; i++)
                    {
                        int widthPixel = ValueToPixel(i * drawer.xIncrementsAttr, drawer.xHasNegativeAttr, pixelWidth, drawer.xRangeAttr);
                        DrawLine(drawer.vertices, drawer.indices, new Vector2(widthPixel, 0f), new Vector2(widthPixel, h), gridThickness, drawer.incrementAxisColorAttr);

                        if (drawer.xHasNegativeAttr)
                        {
                            widthPixel = ValueToPixel(-(i * drawer.xIncrementsAttr), drawer.xHasNegativeAttr, pixelWidth, drawer.xRangeAttr);
                            DrawLine(drawer.vertices, drawer.indices, new Vector2(widthPixel, 0f), new Vector2(widthPixel, h), gridThickness, drawer.incrementAxisColorAttr);
                        }
                    }
                }

                if (drawer.yIncrementsAttr > 0f)
                {
                    int incrementCount = Mathf.FloorToInt(drawer.yRangeAttr / drawer.yIncrementsAttr);
                    for (int i = 0; i < incrementCount; i++)
                    {
                        int heightPixel = ValueToPixel(i * drawer.yIncrementsAttr, drawer.yHasNegativeAttr, pixelHeight, drawer.yRangeAttr);
                        DrawLine(drawer.vertices, drawer.indices, new Vector2(0f, heightPixel), new Vector2(w, heightPixel), gridThickness, drawer.incrementAxisColorAttr);

                        if (drawer.xHasNegativeAttr)
                        {
                            heightPixel = ValueToPixel(-(i * drawer.yIncrementsAttr), drawer.yHasNegativeAttr, pixelHeight, drawer.yRangeAttr);
                            DrawLine(drawer.vertices, drawer.indices, new Vector2(0f, heightPixel), new Vector2(w, heightPixel), gridThickness, drawer.incrementAxisColorAttr);
                        }
                    }
                }

                if (drawer.xHasNegativeAttr)
                {
                    DrawLine(drawer.vertices, drawer.indices, new Vector2(hw, 0f), new Vector2(hw, h), gridThickness, drawer.mainAxisColorAttr);
                }

                if (drawer.yHasNegativeAttr)
                {
                    DrawLine(drawer.vertices, drawer.indices, new Vector2(0f, hh), new Vector2(w, hh), gridThickness, drawer.mainAxisColorAttr);
                }

                if (drawer.CurveEvaluator != null)
                {
                    if (pixelWidth > 1)
                    {
                        for (int i = 0; i < pixelWidth; i++)
                        {
                            float xValue = PixelToValue(i, drawer.xHasNegativeAttr, pixelWidth, drawer.xRangeAttr);
                            float yValue = drawer.CurveEvaluator.Invoke(xValue);

                            Vector2 p2 = new Vector2(
                                ValueToPixel(xValue, drawer.xHasNegativeAttr, pixelWidth, drawer.xRangeAttr),
                                pixelHeight - ValueToPixel(yValue, drawer.yHasNegativeAttr, pixelHeight, drawer.yRangeAttr));

                            drawer.points.Add(p2);
                        }

                        DrawLine(drawer.vertices, drawer.indices, drawer.points, lineThickness, drawer.curveColorAttr);
                    }
                }

                var mwd = ctx.Allocate(drawer.vertices.Count, drawer.indices.Count);
                foreach (var v in drawer.vertices)
                {
                    mwd.SetNextVertex(v);
                }
                foreach (var i in drawer.indices)
                {
                    mwd.SetNextIndex(i);
                }
            };
        }

        public void DrawLine(List<Vertex> vertices, List<ushort> indices, Vector2 from, Vector2 to, float thickness, Color color)
        {
            Vector2 vec = to - from;
            Vector3 perpenticularDirection = new Vector3(vec.y, -vec.x, 0f).normalized;

            ushort startIndex = (ushort)vertices.Count;
            float halfThickness = thickness * 0.5f;

            vertices.Add(new Vertex()
            {
                position = new Vector3(from.x, from.y, Vertex.nearZ) - (perpenticularDirection * halfThickness),
                tint = color
            });
            vertices.Add(new Vertex()
            {
                position = new Vector3(from.x, from.y, Vertex.nearZ) + (perpenticularDirection * halfThickness),
                tint = color
            });
            vertices.Add(new Vertex()
            {
                position = new Vector3(to.x, to.y, Vertex.nearZ) + (perpenticularDirection * halfThickness),
                tint = color
            });
            vertices.Add(new Vertex()
            {
                position = new Vector3(to.x, to.y, Vertex.nearZ) - (perpenticularDirection * halfThickness),
                tint = color
            });

            indices.Add((ushort)(startIndex + 0));
            indices.Add((ushort)(startIndex + 1));
            indices.Add((ushort)(startIndex + 2));
            indices.Add((ushort)(startIndex + 0));
            indices.Add((ushort)(startIndex + 2));
            indices.Add((ushort)(startIndex + 3));
        }

        public void DrawLine(List<Vertex> vertices, List<ushort> indices, List<Vector2> points, float thickness, Color color)
        {
            if (points.Count < 2)
                return;

            float halfThickness = thickness * 0.5f;

            // Start with 2 initial vertices
            {
                Vector2 startPoint = points[0];
                Vector2 nextPoint = points[1];
                Vector2 vec = nextPoint - startPoint;
                Vector3 perpenticularDirection = new Vector3(vec.y, -vec.x, 0f).normalized;
                vertices.Add(new Vertex()
                {
                    position = new Vector3(startPoint.x, startPoint.y, Vertex.nearZ) - (perpenticularDirection * halfThickness),
                    tint = color
                });
                vertices.Add(new Vertex()
                {
                    position = new Vector3(startPoint.x, startPoint.y, Vertex.nearZ) + (perpenticularDirection * halfThickness),
                    tint = color
                });
            }

            for (int i = 1; i < points.Count; i++)
            {
                Vector2 from = points[i - 1];
                Vector2 to = points[i];
                Vector2 vec = to - from;
                Vector3 perpenticularDirection = new Vector3(vec.y, -vec.x, 0f).normalized;

                ushort startIndex = (ushort)vertices.Count;

                vertices.Add(new Vertex()
                {
                    position = new Vector3(to.x, to.y, Vertex.nearZ) - (perpenticularDirection * halfThickness),
                    tint = color
                });
                vertices.Add(new Vertex()
                {
                    position = new Vector3(to.x, to.y, Vertex.nearZ) + (perpenticularDirection * halfThickness),
                    tint = color
                });

                indices.Add((ushort)(startIndex - 2));
                indices.Add((ushort)(startIndex - 1));
                indices.Add((ushort)(startIndex + 1));
                indices.Add((ushort)(startIndex - 2));
                indices.Add((ushort)(startIndex + 1));
                indices.Add((ushort)(startIndex + 0));
            }
        }
    }

    protected static float PixelToValue(int pixel, bool hasNegatives, int totalPixels, float valueRange)
    {
        float pixelRatio = (float)pixel / (float)totalPixels;

        if (hasNegatives)
        {
            return Mathf.Lerp(-valueRange, valueRange, pixelRatio);
        }
        else
        {
            return Mathf.Lerp(0f, valueRange, pixelRatio);
        }
    }

    protected static int ValueToPixel(float value, bool hasNegatives, int totalPixels, float valueRange)
    {
        float valueRatio = value / valueRange;
        if (hasNegatives)
        {
            valueRatio = (valueRatio + 1f) * 0.5f;
        }

        return Mathf.RoundToInt(Mathf.Lerp(0f, (float)totalPixels, valueRatio));
    }
}
