using BuildingModule;
using UnityEngine;

namespace BehaviourModel
{
    public class FindClosestToDeskChairPupilState : FindPlaceToSeatState<PupilAgent>
    {
        protected override ChairInterier FindPlaceToSeat()
        {
            var chairs = InterierHandler.Handler.Chairs;
            var boards = InterierHandler.Handler.Boards;
            ChairInterier best = null;
            float minDistance = float.MaxValue;
            var board = boards[0];
            foreach (var ch in chairs)
            {
                var info = ch.ChairInfo;
                if (best == null && info.CurrentAgent == null && info.BindedAgent == null)
                {
                    best = ch;
                    minDistance = Vector3.Distance(board.transform.position, ch.transform.position);
                    continue;
                }
                else
                {
                    var dist = Vector3.Distance(board.transform.position, ch.transform.position);
                    if (dist < minDistance && info.CurrentAgent == null && info.BindedAgent == null)
                    {
                        minDistance = dist;
                        best = ch;
                    }
                }
            }
            return best;
        }
    }
}