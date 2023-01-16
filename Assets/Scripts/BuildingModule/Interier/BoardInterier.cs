using Extensions;

namespace BuildingModule
{
    public class BoardInterier : PlacedInterier
    {
        private void OnDestroy()
        {
            InterierHandler.Handler.Boards.Remove(this);
        }

        protected override void Awake()
        {
            base.Awake();
            InterierHandler.Handler.Boards.Add(this);
        }

        public override bool CanExist(Underwall underwall)
        {
            var princ = IsPrincipAvailableForPlacing(underwall);
            var isOnlyThis = underwall.InterierCount() == 1 && underwall.InterierContains(this);
            var hasPass = underwall.AssociatedWall.HasPass();
            var hasWall = underwall.AssociatedWall.IsActive();
            if (princ && isOnlyThis && !hasPass && hasWall)
                return true;
            return false;
        }

        public override bool IsAvailForPlacing(Underwall place)
        {
            var princ = IsPrincipAvailableForPlacing(place);
            var isFree = place.InterierCount() == 0;
            var hasPass = place.AssociatedWall.HasPass();
            var hasWall = place.AssociatedWall.IsActive();
            if (princ && isFree && !hasPass && hasWall)
                return true;
            return false;
        }

        public override bool IsPrincipAvailableForPlacing<T>(T interierPlace)
        {
            if (typeof(T).Equals<Underwall>())
                return true;
            return default;
        }
    }
}