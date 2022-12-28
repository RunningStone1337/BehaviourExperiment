namespace BuildingModule
{
    public class OccupedInterierMiddlePlaceState : OccupedInterierPlaceState
    {
        protected MiddlePlace ThisPlace { get => (MiddlePlace)thisPlace; }
        public override bool IsAvailableForPlacingInterier(InterierBase interier)
        {
            //сделать обработчики на каждый случай в interier?
            if (interier is Chair)
            {
                var chairsCount = ThisPlace.GetComponentsInChildren<Chair>().Length;
                if (chairsCount <= 1)
                    return true;
                return false;
            }
            return base.IsAvailableForPlacingInterier(interier);
        }

        public override void InitializeState()
        {
            base.InitializeState();
            var tp = (MiddlePlace)thisPlace;
            tp.LeftMiddlePlace.CurrentState = tp.LeftMiddlePlace.FreeInterierPlaceState;
            tp.RightMiddlePlace.CurrentState = tp.RightMiddlePlace.FreeInterierPlaceState;
            SetOppositePlaceStateAccordingSelectedInterier<TableInterier>();
        }
    }
}