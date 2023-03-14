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
            //���������� �����:
            //��������� �������� � �������
            IsContinue = true;

            BoardInterier closestBOard = GetClosestBoard();
            var cachedRotation = thisAgent.transform.rotation.eulerAngles.z%360f;
            var classAngle = (closestBOard.transform.rotation.eulerAngles.z % 360f);
            var rotator = new RotationHandler();
            var slowRotation = RotationHandler.SlowRotation;
            var fastRotation = RotationHandler.QuickRotation;
            //������� � ������
            yield return rotator.RotateToAngle(thisAgent.AgentRigidbody, classAngle, fastRotation);
            //��������� �������� � �������
            yield return rotator.SmoothRotateToSides(thisAgent.AgentRigidbody, 15f, 3f, slowRotation);
            //������� � �����
            yield return rotator.RotateToFaceDirection(closestBOard.transform.position - thisAgent.transform.position, thisAgent.AgentRigidbody, fastRotation);
            yield return new WaitForSeconds(Random.Range(3f,7f));
            //������� � ������
            yield return rotator.RotateToAngle(thisAgent.AgentRigidbody, classAngle, fastRotation);
            //��������� �������� � �������
            yield return rotator.SmoothRotateToSides(thisAgent.AgentRigidbody, 15f, 3f, slowRotation);
            //������� � ��������
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
