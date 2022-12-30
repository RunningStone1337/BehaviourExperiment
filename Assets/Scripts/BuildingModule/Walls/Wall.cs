using Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    public class Wall : MonoBehaviour, IPointerClickHandler, ICurrentStateHandler
    {
        [SerializeField] private ActiveState activeState;
        [SerializeField] private AvailForBuildState availForBuildState;
        [SerializeField] private WallStateBase currentState;
        [SerializeField] private InactiveState inactiveState;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Direction thisDirection;
        [SerializeField] private Entrance thisEntrance;

        private void Awake()
        {
            currentState.Initiate();
            thisEntrance = GetComponentInParent<Entrance>();
        }

        private Entrance GetBorderEntrance()
        {
            if (thisDirection == Direction.Left)
                return ThisEntrance.LeftNeighbour;
            if (thisDirection == Direction.Right)
                return ThisEntrance.RightNeighbour;
            if (thisDirection == Direction.Up)
                return ThisEntrance.UpNeighbour;
            if (thisDirection == Direction.Down)
                return ThisEntrance.DownNeighbour;
            return default;
        }

        public IState CurrentState
        {
            get => currentState;
            set
            {
                currentState = (WallStateBase)value;
                currentState.Initiate();
            }
        }

        public SpriteRenderer Renderer { get => spriteRenderer; }

        public Entrance ThisEntrance => thisEntrance;

        /// <summary>
        /// Имеет ли комната с этой стеной на стороне сквозной проход? Сквозной проход -
        /// отсутствие стены здесь и на соединяемой комнате, если команты нет - считается, что прохода нет.
        /// </summary>
        /// <returns></returns>
        public bool HasPass()
        {
            var borderEntr = GetBorderEntrance();
            if (borderEntr != null)
            {
                var hasWallBetween = thisEntrance.HasWallBetween(borderEntr);
                var hasWallBetweenThis = borderEntr.HasWallBetween(thisEntrance);
                if (!hasWallBetween && !hasWallBetweenThis)
                    return true;
            }
            return default;
        }

        public bool IsActive() => currentState is ActiveState;

        public void OnPointerClick(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleWallClick(this, eventData);
        }

        public void SetActiveState() =>
            CurrentState = activeState;

        public void SetBuildingState() =>
            CurrentState = availForBuildState;

        public void SetInactiveState() =>
            CurrentState = inactiveState;

        public void SetState<S2>() where S2 : IState
        {
            if (availForBuildState is S2)
                SetBuildingState();
            else if (inactiveState is S2)
                SetInactiveState();
            else if (activeState is S2)
                SetActiveState();
            else throw new System.Exception($"Unexpected state {typeof(S2)}");
        }
    }
}