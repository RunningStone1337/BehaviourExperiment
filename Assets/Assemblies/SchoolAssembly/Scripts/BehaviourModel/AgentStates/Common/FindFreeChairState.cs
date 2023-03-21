using BuildingModule;
using System.Collections.Generic;

namespace BehaviourModel
{
    public class FindFreeChairState<T> : FindPlaceToSeatState<T>
        where T : SchoolAgentBase<T>
    {
        protected override ChairInterier FindPlaceToSeat()
        {
            List<ChairInterier> chairs = new List<ChairInterier>(InterierHandler.Handler.Chairs);
            for (int i = 0; i <= chairs.Count; i++)
            {
                var rand = chairs.GetRandom();
                if (rand.ChairInfo.CurrentAgent == null && rand.ChairInfo.BindedAgent == null)
                    return rand;
                else
                    chairs.Remove(rand);
            }
            return default;
        }

        public FindFreeChairState() : base()
        {
        }
    }
}