using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public class RotationHandler
    {
        public static readonly float QuickRotation = 3f;
        public static readonly float MiddleRotation = 2f;
        public static readonly float SlowRotation = 1f;

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

        public IEnumerator RotateToAngle(Rigidbody2D bodyToRotate, float targetRotationAngle, float anglePerUpdSpeed)
        {
            var startRotation = bodyToRotate.rotation;
            GetProps(targetRotationAngle, startRotation, out int sign, out float lowBorder, out float highBorder);
            while (!Mathf.Approximately(bodyToRotate.rotation, targetRotationAngle))
            {
                bodyToRotate.SetRotation(Mathf.Clamp(bodyToRotate.rotation + sign * anglePerUpdSpeed, lowBorder, highBorder));
                yield return null;
            }
        }

        public IEnumerator RotateToFaceDirection(Vector3 targetDirection, Rigidbody2D rotatedBody, float roatePerUpd)
        {
            var existAngleBetweenVectors = Vector2.SignedAngle(rotatedBody.transform.right, targetDirection);
            float existRotation = rotatedBody.rotation;
            var targetRotation = existRotation + existAngleBetweenVectors;
            while (Mathf.Abs(Mathf.Abs(targetRotation) - Mathf.Abs(existRotation)) >0.5f /*!Mathf.Approximately(targetRotation, existRotation)*/)
            {
                existRotation = rotatedBody.rotation;
                if (existRotation < targetRotation)
                    rotatedBody.SetRotation(Mathf.Clamp(rotatedBody.rotation + roatePerUpd, existRotation, targetRotation));
                else if (existRotation > targetRotation)
                    rotatedBody.SetRotation(Mathf.Clamp(rotatedBody.rotation - roatePerUpd, targetRotation, existRotation));
                yield return null;
            }
        }

        public IEnumerator SmoothRotateToSides(Rigidbody2D rotateBody, float angleToRotate, float rotationTimeout, float anglePerUpdSpeed)
        {
            float startAngle = rotateBody.rotation;
            int side = Random.Range(0, 2) == 0 ? 1 : -1;
            float targetAngle = startAngle + angleToRotate * side;
            while (rotationTimeout > 0f)
            {
                var statrTime = Time.time;
                yield return RotateToAngle(rotateBody, targetAngle, anglePerUpdSpeed);
                var endTime = Time.time;
                rotationTimeout -= endTime - statrTime;
                side *= -1;
                targetAngle = startAngle + angleToRotate * side;
            }
        }
    }
}