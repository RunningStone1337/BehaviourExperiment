using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    /// <summary>
    /// Иерархия состояний для мест размещения интерьера.
    /// </summary>
    [Serializable]
    public abstract class InterierPlaceStateBase : MonoBehaviour, IState
    {
        [SerializeField] protected InterierPlaceBase thisPlace;
     
        private void Awake()
        {
            thisPlace = GetComponent<InterierPlaceBase>();
        }

        public virtual void InitializeState() { }

        public virtual void BeforeChangeState() { }

        public virtual void HandleInterierPlaceClick(PointerEventData eventData) { }       
       
        /// <summary>
        /// Устанавливает новое состояние или оставляет старое в зависимости от текущих обстоятельств
        /// </summary>
        public abstract void ResetState(InterierBase interier);
#if UNITY_EDITOR
        protected void DrawSphereGizmo(Color color)
        {
            if (thisPlace != null)
            {
                if (thisPlace.CurrentState.Equals(this))
                {
                    Gizmos.color = color;
                    var col = Gizmos.color;
                    Gizmos.DrawSphere(thisPlace.transform.position, 0.1f);
                    Gizmos.color = col;
                }
            }
        }
#endif
    }
}