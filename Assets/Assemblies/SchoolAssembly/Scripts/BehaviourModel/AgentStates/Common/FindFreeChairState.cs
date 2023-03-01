using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class FindFreeChairState<T> : FindPlaceToSeatState<T>
        where T : SchoolAgentBase<T>
    {
        //public override bool StateBreaked { get => stateBreaked; set => stateBreaked = value; }
        public FindFreeChairState() : base()
        {

        }
       
        protected override ChairInterier FindPlaceToSeat()
        {
            List<ChairInterier> chairs = InterierHandler.Handler.Chairs;
            foreach (var ch in chairs)
            {
                if (ch.ChairInfo.ThisAgent == null)
                    return ch;
            }
            return default;
        }
    }
}