using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace BuildingModule
{
    public class RoleWrapper : MonoBehaviour, IUIViewedObjectHandler
    {
        [SerializeField] EntranceRoleBase role;

        public IUIViewedObject CorrespondingObjectPrefab => role;
    }
}