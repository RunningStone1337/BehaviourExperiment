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
            //объяснение урока:
            //небольшие повороты в стороны
            IsContinue = true;

            BoardInterier closestBOard = GetClosestBoard();
            var cachedRotation = thisAgent.transform.rotation.eulerAngles.z%360f;
            var classAngle = (closestBOard.transform.rotation.eulerAngles.z % 360f);
            var rotator = new RotationHandler();
            var slowRotation = RotationHandler.SlowRotation;
            var fastRotation = RotationHandler.QuickRotation;
            //поворот к классу
            yield return rotator.RotateToAngle(thisAgent.AgentRigidbody, classAngle, fastRotation);
            //небольшие повороты в стороны
            yield return rotator.SmoothRotateToSides(thisAgent.AgentRigidbody, 15f, 3f, slowRotation);
            //поворот к доске
            yield return rotator.RotateToFaceDirection(closestBOard.transform.position - thisAgent.transform.position, thisAgent.AgentRigidbody, fastRotation);
            yield return new WaitForSeconds(Random.Range(3f,7f));
            //поворот к классу
            yield return rotator.RotateToAngle(thisAgent.AgentRigidbody, classAngle, fastRotation);
            //небольшие повороты в стороны
            yield return rotator.SmoothRotateToSides(thisAgent.AgentRigidbody, 15f, 3f, slowRotation);
            //возврат в исходное
            yield return rotator.RotateToAngle(thisAgent.AgentRigidbody, cachedRotation, fastRotation);
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
