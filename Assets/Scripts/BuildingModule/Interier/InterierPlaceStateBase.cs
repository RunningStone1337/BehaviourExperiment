using Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    /// <summary>
    /// �������� ��������� ��� ���� ���������� ���������.
    /// </summary>
    public abstract class InterierPlaceStateBase : MonoBehaviour, IState
    {
        [SerializeField] protected InterierPlaceBase thisPlace;

        private void Awake()
        {
            thisPlace = GetComponent<InterierPlaceBase>();
        }

        public virtual void InitializeState()
        { }

        public virtual void BeforeChangeState()
        { }

        public virtual void HandleInterierPlaceClick(PointerEventData eventData)
        { }

        /// <summary>
        /// ������������� ����� ��������� ��� ��������� ������ � ����������� �� ������� �������������
        /// </summary>
        public abstract void SetStateForInterier(PlacedInterier interier);

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