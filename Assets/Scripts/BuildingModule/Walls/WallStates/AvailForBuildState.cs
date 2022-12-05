using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public class AvailForBuildState : WallStateBase, IVisualEffectRoutineHandler
    {
        [SerializeField] [Range(0f, 1f)] float step = 0.005f;
        [SerializeField] Color targetColor;
        Coroutine routine;
        public Coroutine Routine { get=> routine; set=> routine = value; }
        public override void Initiate()
        {
            ThisWall.Renderer.enabled = true;
            if (routine != null)
                StopCoroutine(routine);
            routine = StartCoroutine(VisualEffectRoutine());
        }

        public IEnumerator VisualEffectRoutine()
        {
            var targetGraphics = thisWall.Renderer;
            Color baseColor = targetGraphics.color;
            yield return VisualEffectsProvider.ShiningEffect(baseColor,
                targetColor,
                targetGraphics,
                step,
                () =>  ThisWall.CurrentState is AvailForBuildState);
        }
    }
}