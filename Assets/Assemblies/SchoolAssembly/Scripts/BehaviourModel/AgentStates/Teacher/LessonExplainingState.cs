using BuildingModule;
using System;
using System.Collections;
using System.Collections.Generic;
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
            var cachedDirection = thisAgent.transform.up;/* .rotation.eulerAngles.z%360f;*/
            var classDirection = board.transform.right;
            //var classAngle = (board.transform.rotation.eulerAngles.z % 360f);
            var rotator = new RotationHandler();
            var slowRotation = RotationHandler.SlowRotation;
            var fastRotation = RotationHandler.QuickRotation;
            //поворот к классу
            Debug.Log("Statrt rotate to class");
            yield return rotator.RotateToFaceDirection(classDirection, thisAgent.AgentRigidbody,  fastRotation);
            //небольшие повороты в стороны
            Debug.Log("Statrt rotate to sides look class");
            yield return rotator.SmoothRotateToSides(thisAgent.AgentRigidbody, 20f, 3f, slowRotation);
            //поворот к доске
            Debug.Log("Statrt rotate to board");
            yield return rotator.RotateToFaceDirection(board.transform, thisAgent.AgentRigidbody, fastRotation);
            Debug.Log("Statrt waiting");
            yield return new WaitForSeconds(Random.Range(3f,7f));
            //поворот к классу
            Debug.Log("Statrt rotate to class again");
            yield return rotator.RotateToFaceDirection(classDirection, thisAgent.AgentRigidbody,  fastRotation);
            //yield return rotator.RotateToAngle(thisAgent.AgentRigidbody, classAngle, fastRotation);
            //небольшие повороты в стороны
            Debug.Log("Statrt rotate to sides look on class again");
            yield return rotator.SmoothRotateToSides(thisAgent.AgentRigidbody, 20f, 3f, slowRotation);
            //возврат в исходное
            Debug.Log("Statrt rotate to statrt direction");
            yield return rotator.RotateToFaceDirection( cachedDirection, thisAgent.AgentRigidbody, fastRotation);
            //yield return rotator.RotateToAngle(thisAgent.AgentRigidbody, cachedRotation, fastRotation);
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
