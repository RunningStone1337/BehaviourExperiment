using System.Collections;
using UnityEngine;

namespace Common
{
    public class RotationHandler
    {
        public static readonly float QuickRotation = 5f;
        public static readonly float MiddleRotation = 2.5f;
        public static readonly float SlowRotation = 0.5f;

        private static void GetProps(float targetRotationAngle, float currentotation, out int sign, out float lowBorder, out float highBorder)
        {
            if (targetRotationAngle > currentotation)
            {
                sign = 1;
                lowBorder = currentotation;
                highBorder = targetRotationAngle;
            }
            else
            {
                sign = -1;
                lowBorder = targetRotationAngle;
                highBorder = currentotation;
            }
        }
        public static Vector3 RotateBy(Vector3 direction, float angle, bool bUseRadians = false)
        {
            if (!bUseRadians) angle *= Mathf.Deg2Rad;
            var ca = Mathf.Cos(angle);
            var sa = Mathf.Sin(angle);
            float rx = direction.x * ca - direction.y * sa;
            float ry = direction.x * sa + direction.y * ca;

            return new Vector3(rx, ry);
        }
        public IEnumerator RotateToAngle(Transform bodyToRotate, float deltaFromCurrent, float anglePerFixUpdSpeed)
        {
            Debug.Log("RotateToAngle");
            var targetDirection = RotateBy(bodyToRotate.up, deltaFromCurrent);
            yield return RotateToFaceDirection(targetDirection, bodyToRotate, anglePerFixUpdSpeed);
        }

        public IEnumerator RotateToFaceDirection(Vector3 targetDirection, Transform rotatedBody, float roatePerFixUpd)
        {
            Debug.Log("RotateToFaceDirection");
            var step = roatePerFixUpd * Time.fixedDeltaTime;
            var newDirection = Vector2.MoveTowards(rotatedBody.up, targetDirection, step);
            var existAngle = Vector2.SignedAngle(newDirection, targetDirection);
            while (Mathf.Abs(existAngle) > 0.5f)
            {
                rotatedBody.up = newDirection;
                yield return new WaitForFixedUpdate();
                newDirection = Vector2.MoveTowards(rotatedBody.up, targetDirection, step);
                existAngle = Vector2.SignedAngle(newDirection, targetDirection);
            }
            
        }
        public IEnumerator RotateToFaceDirectionStep(Vector3 targetDirection, Transform rotatedBody, float roatePerFixUpd)
        {
            Debug.Log("RotateToFaceDirectionStep");
            var norm = targetDirection.normalized;
            var move = Vector2.MoveTowards(rotatedBody.up, norm, roatePerFixUpd);
            rotatedBody.up = move.normalized;
            yield return new WaitForFixedUpdate();
        }

        public IEnumerator RotateToFaceDirection(Transform targetTransform, Transform rotatedBody, float roatePerFixUpd)
        {
            var targetDirection = targetTransform.position - rotatedBody.transform.position;
            yield return RotateToFaceDirection(targetDirection, rotatedBody, roatePerFixUpd);          
        }
        public IEnumerator RotateToFaceDirectionStep(Transform targetTransform, Transform rotatedBody, float roatePerFixUpd)
        {
            var targetDirection = targetTransform.position - rotatedBody.transform.position;
            yield return RotateToFaceDirectionStep(targetDirection, rotatedBody, roatePerFixUpd);
        }

        public IEnumerator SmoothRotateToSides(Transform rotateBody, float rotationDelta, float rotationTimeout, float anglePerUpdSpeed)
        {
            Debug.Log("SmoothRotateToSides");
            int side = Random.Range(0, 2) == 0 ? 1 : -1;
            while (rotationTimeout > 0f)
            {
                var statrTime = Time.time;
                yield return RotateToAngle(rotateBody, rotationDelta * side, anglePerUpdSpeed);
                var endTime = Time.time;
                rotationTimeout -= endTime - statrTime;
                side *= -1;
            }
        }
    }
}