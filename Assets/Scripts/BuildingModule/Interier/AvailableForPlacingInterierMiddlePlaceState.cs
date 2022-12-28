namespace BuildingModule {
    public class AvailableForPlacingInterierMiddlePlaceState : AvailableForPlacingInterierPlaceState
    {
        public override bool IsAvailableForPlacingInterier(InterierBase interier)
        {
            if (interier is TableInterier)
                return !IsOppositeOccupedByTable();
            else if (interier is Chair)
                return true;
            return base.IsAvailableForPlacingInterier(interier);
        }
    }
}