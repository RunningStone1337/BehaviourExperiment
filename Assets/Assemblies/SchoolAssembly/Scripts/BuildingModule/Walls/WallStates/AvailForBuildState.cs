using Common;
using System.Collections;
using UnityEngine;

namespace BuildingModule
{
    public class AvailForBuildState : WallStateBase, IVisualEffectRoutineHandler
    {
        private Coroutine routine;
        [SerializeField] [Range(0f, 1f)] private float step = 0.005f;
        [SerializeField] private Color targetColor;
        public Coroutine Routine { get => routine; set => routine = value; }

        public override void Initiate()
        {
            ThisWall.Renderer.enabled = true;
            ThisWall.WallCollider.enabled = true;
            StartRoutine();
        }

        public void StartRoutine()
        {
            if (Routine != null)
                StopCoroutine(Routine);
            Routine = StartCoroutine(VisualEffectRoutine());
        }

        public IEnumerator VisualEffectRoutine()
        {
            var targetGraphics = thisWall.Renderer;
            Color baseColor = targetGraphics.color;
            yield return VisualEffectsProvider.ShiningEffect(baseColor,
                targetColor,
                targetGraphics,
                step,
                () => ThisWall.CurrentState is AvailForBuildState);
        }
    }
}