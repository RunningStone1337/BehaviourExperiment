using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    public class AvailableForPlacingInterierPlaceState : InterierPlaceStateBase, IVisualEffectRoutineHandler
    {
        [SerializeField] SpriteRenderer placeRenderer;
        [SerializeField] Color targetColor;
        [SerializeField] [Range(0f,1f)]float step;
        Coroutine routine;
        public Coroutine Routine { get => routine; set => routine = value; }

        public override void InitializeState()
        {
            thisPlace.Collider2D.enabled = true;
            StartRoutine();
        }

        public IEnumerator VisualEffectRoutine()
        {
            var baseCOlor = new Color(1, 1, 1, 0);
            yield return VisualEffectsProvider.ShiningEffect(baseCOlor,
                targetColor, 
                placeRenderer,
                step,
                () => thisPlace.CurrentState is AvailableForPlacingInterierPlaceState);
        }
        public override void HandleInterierPlaceClick(PointerEventData eventData)
        {
           EntranceBuilder.TryAddSelectedInterier(thisPlace);
        }
        public override void BeforeChangeState()
        {
            thisPlace.Collider2D.enabled = false;
        }

        public void StartRoutine()
        {
            if (Routine != null)
                StopCoroutine(Routine);
            Routine = StartCoroutine(VisualEffectRoutine());
        }
    }
}