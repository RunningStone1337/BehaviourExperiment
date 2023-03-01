using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class RotationHandler
    {
        

        
        public IEnumerator RotateToFaceDirection(Vector3 targetDirection, Rigidbody2D rotatedBody, float rotationSpeed, float rotationOffset, float rotationAnglePrecision)
        {
            var existAngle = Vector2.SignedAngle(rotatedBody.transform.right, targetDirection);
            var diff = Mathf.Abs(existAngle - rotationOffset);
            while (rotationAnglePrecision < diff)
            {
                existAngle = Vector2.SignedAngle(rotatedBody.transform.right, targetDirection);
                diff = Mathf.Abs(existAngle - rotationOffset);
                if (existAngle > rotationOffset)
                    rotatedBody.SetRotation(rotatedBody.rotation + rotationSpeed);
                else if (existAngle < rotationOffset)
                    rotatedBody.SetRotation(rotatedBody.rotation - rotationSpeed);
                yield return null;
            }
        }

        public IEnumerator RotateToAngle(Rigidbody2D bodyToRotate, float targetRotationAngle, float anglePerFixedUpdRotation)
        {
            var startRotation = bodyToRotate.rotation;
            GetProps(targetRotationAngle, startRotation, out int sign, out float lowBorder, out float highBorder);
            while (!Mathf.Approximately(bodyToRotate.rotation, targetRotationAngle))
            {
                bodyToRotate.SetRotation(Mathf.Clamp(bodyToRotate.rotation + sign * anglePerFixedUpdRotation, lowBorder, highBorder));
                yield return new WaitForFixedUpdate();
            }
        }

        private static void GetProps(float targetRotationAngle, float startRotation, out int sign, out float lowBorder, out float highBorder)
        {
            if (targetRotationAngle > startRotation)
            {
                sign = 1;
                lowBorder = startRotation;
                highBorder = targetRotationAngle;
            }
            else
            {
                sign = -1;
                lowBorder = targetRotationAngle;
                highBorder = startRotation;
            }
        }
    }
}
