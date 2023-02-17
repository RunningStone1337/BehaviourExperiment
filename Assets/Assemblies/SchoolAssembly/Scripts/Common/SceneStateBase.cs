using BuildingModule;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    /// <summary>
    /// �������� ���������� ��������� �����.
    /// </summary>
    public abstract class SceneStateBase : MonoBehaviour, IState
    {
        private void Awake()
        {
            master = GetComponent<SceneMaster>();
        }

        [SerializeField] protected SceneMaster master;

        /// <summary>
        /// ������������ ������ ��� ����� ��� ��� ��������� ����� �������� ���������� ���������
        /// </summary>
        public virtual void BeforeChangeOldState()
        { }

        /// <summary>
        /// ���� �� ����� ��� ���������� ���������.
        /// </summary>
        /// <param name="buildingPlace"></param>
        /// <param name="eventData"></param>
        public virtual void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData)
        { }

        /// <summary>
        /// ���� �� ���������.
        /// </summary>
        /// <param name="entrance"></param>
        /// <param name="eventData"></param>
        public virtual void HandleEntranceClick(Entrance entrance, PointerEventData eventData)
        { }

        /// <summary>
        /// ���� �� ������������ �������� ���������.
        /// </summary>
        /// <param name="interierBase"></param>
        /// <param name="eventData"></param>
        public virtual void HandleInterierClick(PlacedInterier interierBase, PointerEventData eventData)
        { }

        /// <summary>
        /// ���� �� ����� ���������� ���������.
        /// </summary>
        /// <param name="interierPlaceBase"></param>
        /// <param name="eventData"></param>
        public virtual void HandleInterierPlaceClick(InterierPlaceBase interierPlaceBase, PointerEventData eventData)
        { }

        /// <summary>
        /// ���� �� UI ������, ��������������� ������������ GO
        /// </summary>
        /// <param name="placeableUIView"></param>
        /// <param name="eventData"></param>
        public virtual void HandlePlaceableUIViewClick(PlaceableUIView placeableUIView, PointerEventData eventData)
        { }

        /// <summary>
        /// ���� �� �����
        /// </summary>
        /// <param name="wall"></param>
        /// <param name="eventData"></param>
        public virtual void HandleWallClick(Wall wall, PointerEventData eventData)
        { }

        /// <summary>
        /// ������������ ������ ��� ����� ���������� ������ �������� ���������� ���������
        /// </summary>
        public virtual void Initiate()
        { }
    }
}