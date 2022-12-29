using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    /// <summary>
    /// —тейт доступности размещени€ интерьера.
    /// </summary>
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
            var selected = (InterierBase)SceneMaster.Master.LastSelectedViewObject;
            EntranceBuilder.AddInterier(selected, thisPlace);
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

        public override void ResetState(InterierBase interier)
        {
            var intCount = thisPlace.InterierCount();
            if (intCount > 0)//обычно нельз€ размещать больше 1 предмета на место
                thisPlace.SetNotAvailForPlacingState();

        }
        void OnDrawGizmos()
        {
            var color = Color.green;
            DrawSphereGizmo(color);
        }
    }
}