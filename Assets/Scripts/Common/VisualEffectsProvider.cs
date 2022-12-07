using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class VisualEffectsProvider : MonoBehaviour
    {
        public static IEnumerator ShiningEffect(Color baseColor, Color targetColor, SpriteRenderer targetGraphics, float step, Func<bool> cycleCondition)
        {
            Gradient grad = new Gradient();
            var alphaKeys = new GradientAlphaKey[2];
            var colorKeys = new GradientColorKey[2];
            colorKeys[0].color = baseColor;
            colorKeys[1].color = targetColor;
            colorKeys[0].time = 0f;
            colorKeys[1].time = 1;

            alphaKeys[0].alpha = 1f;
            alphaKeys[1].alpha = targetColor.a;
            alphaKeys[0].time = 0f;
            alphaKeys[1].time = 1;
            grad.SetKeys(colorKeys, alphaKeys);
            float time = 0;
            int sign = 1;
            while (cycleCondition.Invoke())
            {
                targetGraphics.color = grad.Evaluate(time);
                if (time == 1f)
                    sign = -1;
                if (time == 0f)
                    sign = 1;
                time = Mathf.Clamp(time + step * sign, 0f, 1f);
                yield return null;
            }
            targetGraphics.color = baseColor;
        }
    }
}