using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class FindFarFromDeskChairPupilState : FindPlaceToSeatState<PupilAgent>
    {
        protected override ChairInterier FindPlaceToSeat()
        {
            return FindMostRemoteFreeChairToSeat(InterierHandler.Handler.Chairs, InterierHandler.Handler.Boards);
        }
        private ChairInterier FindMostRemoteFreeChairToSeat(List<ChairInterier> chairs, List<BoardInterier> boards)
        {
            ChairInterier best = null;
            float maxDistance = float.MinValue;
            var board = boards[0];
            foreach (var ch in chairs)
            {
                if (best == null && ch.ChairInfo.ThisAgent == null)
                {
                    best = ch;
                    maxDistance = Vector3.Distance(board.transform.position, ch.transform.position);
                    continue;
                }
                else
                {
                    var dist = Vector3.Distance(board.transform.position, ch.transform.position);
                    if (dist > maxDistance && ch.ChairInfo.ThisAgent == null)
                    {
                        maxDistance = dist;
                        best = ch;
                    }
                }
            }
            return best;
        }
    }
}
