using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    public abstract class BuildingPlaceState : MonoBehaviour
    {
        #region Public Methods

        public abstract bool TryPlaceNewEntrance(PointerEventData eventData);
        public abstract bool TryRemoveExistEntrance(PointerEventData eventData);

        #endregion Public Methods

        #region Protected Fields

        [SerializeField] protected BuildingPlace thisPlace;

        #endregion Protected Fields

        #region Private Methods

        private void Awake()
        {
            if (thisPlace == null)
                thisPlace = GetComponent<BuildingPlace>();
        }


        #endregion Private Methods
    }
}