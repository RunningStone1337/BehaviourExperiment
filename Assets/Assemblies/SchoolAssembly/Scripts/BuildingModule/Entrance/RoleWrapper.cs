using UI;
using UnityEngine;

namespace BuildingModule
{
    public class RoleWrapper : MonoBehaviour, IUIViewedObjectHandler
    {
        [SerializeField] private EntranceRoleBase role;

        public IUIViewedObject CorrespondingObjectPrefab => role;
    }
}