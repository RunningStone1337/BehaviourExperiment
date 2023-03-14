using Common;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    /// <summary>
    /// —тейт доступности размещени€ интерьера.
    /// </summary>
    public class AvailableForPlacingInterierPlaceState : InterierPlaceStateBase, IVisualEffectRoutineHandler
    {
        [SerializeField] private SpriteRenderer placeRenderer;
        private Coroutine routine;
        [SerializeField] [Range(0f, 1f)] private float step;
        [SerializeField] private Color targetColor;

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            var color = Color.green;
            DrawSphereGizmo(color);
        }
#endif

        public Coroutine Routine { get => routine; set => routine = value; }

        public override void BeforeChangeState()
        {
            thisPlace.Collider2D.enabled = false;
        }

        public override void HandleInterierPlaceClick(PointerEventData eventData)
        {
            var selected = (InterierBase)SceneMaster.Master.LastSelectedViewObject;
            EntranceBuilder.AddInterier(selected, thisPlace);
        }

        public override void InitializeState()
        {
            thisPlace.Collider2D.enabled = true;
            StartRoutine();
        }

        public override void SetStateForInterier(PlacedInterier interier)
        {
            if (!interier.IsAvailForPlacing(thisPlace))
                thisPlace.SetNotAvailForPlacingState();
        }

        public void StartRoutine()
        {
            if (Routine != null)
                StopCoroutine(Routine);
            Routine = StartCoroutine(VisualEffectRoutine());
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
    }
}