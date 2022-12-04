using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public class AvailForBuildState : WallStateBase
    {
        //[SerializeField] [Range(0f, 1f)] float lerp;
        //[SerializeField] [Range(0f, 10f)] float timeDelay;
        [SerializeField] [Range(0f, 1f)] float step;
        [SerializeField] Color targetColor;
        static GradientColorKey[] colorKeys;
        static GradientAlphaKey[] alphaKeys;
        Coroutine routine;
        public override void Initiate()
        {
            ThisWall.Renderer.enabled = true;
            routine = StartCoroutine(VisualShiningRoutine());
        }
        private void Awake()
        {
            colorKeys = new GradientColorKey[2];
            alphaKeys = new GradientAlphaKey[2];
            colorKeys[0].color = ThisWall.Renderer.color;
            colorKeys[1].color = targetColor;
            colorKeys[0].time = 0f;
            colorKeys[1].time = 1;

            alphaKeys[0].alpha = 1f;
            alphaKeys[1].alpha = targetColor.a;
            alphaKeys[0].time = 0f;
            alphaKeys[1].time = 1;
        }
        private IEnumerator VisualShiningRoutine()
        {
            var rend = thisWall.Renderer;
            Color baseColor = rend.color;
            Gradient grad = new Gradient();
            grad.SetKeys(colorKeys, alphaKeys);
            float time = 0;
            int sign = 1;
            while (ThisWall.CurrentState is AvailForBuildState)
            {
                rend.color = grad.Evaluate(time);
                if (time == 1f)
                    sign = -1;
                if (time == 0f)
                    sign = 1;
                time = Mathf.Clamp(time + step * sign, 0f, 1f);
                yield return null;
            }
            thisWall.Renderer.color = baseColor;
        }
    }
}