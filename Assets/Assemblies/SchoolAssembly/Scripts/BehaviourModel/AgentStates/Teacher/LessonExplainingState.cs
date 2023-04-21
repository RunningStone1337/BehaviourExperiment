using BuildingModule;
using Common;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BehaviourModel
{
    public class LessonExplainingState<TAgent> : SchoolAgentStateBase<TAgent>, IOptionalToCompleteState
        where TAgent: SchoolAgentBase<TAgent>
    {
        public bool IsContinue { get; set ; }

        public override IEnumerator StartState()
        {
            IsContinue = true;
            BoardInterier board = GetClosestBoard();
            var cachedDirection = thisAgent.transform.up;
            var classDirection = board.transform.right;
            var rotator = new RotationHandler();
            var slowRotation = RotationHandler.SlowRotation;
            var fastRotation = RotationHandler.QuickRotation;
            //поворот к классу
            yield return rotator.RotateToFaceDirection(classDirection, thisAgent.transform,  fastRotation);
            //небольшие повороты в стороны
            yield return rotator.SmoothRotateToSides(thisAgent.transform, 20f, 3f, slowRotation);
            //поворот к доске
            yield return rotator.RotateToFaceDirection(board.transform, thisAgent.transform, fastRotation);
            yield return new WaitForSeconds(Random.Range(3f,7f));
            //поворот к классу
            yield return rotator.RotateToFaceDirection(classDirection, thisAgent.transform,  fastRotation);
            //небольшие повороты в стороны
            yield return rotator.SmoothRotateToSides(thisAgent.transform, 20f, 3f, slowRotation);
            //возврат в исходное
            yield return rotator.RotateToFaceDirection( cachedDirection, thisAgent.transform, fastRotation);
        }

        private BoardInterier GetClosestBoard()
        {
            var boards = InterierHandler.Handler.Boards;
            BoardInterier best = null;
            float bDist = float.MaxValue;
            foreach (var b in boards)
            {
                if (best == null)
                {
                    best = b;
                    bDist = Vector3.Distance(best.transform.position, thisAgent.transform.position);
                }
                else
                {
                    var currentDIst = Vector3.Distance(best.transform.position, thisAgent.transform.position);
                    if (currentDIst < bDist)
                    {
                        bDist = currentDIst;
                        best = b;
                    }
                }
            }
            return best;
        }
    }
}
