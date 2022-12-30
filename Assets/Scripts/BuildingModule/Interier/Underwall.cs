using Common;
using UnityEngine;

namespace BuildingModule
{
    public class Underwall : InterierPlaceBase, IDependentFromChanges
    {
        [SerializeField] private Wall associatedWall;
        public Wall AssociatedWall => associatedWall;

        public void ResetIfConditionsChanged(object param)
        {
            var inter = GetInterier();
            if (inter != null)
            {
                if (!inter.CanExist(this))
                    RemoveInterier(inter);
            }
        }
    }
}