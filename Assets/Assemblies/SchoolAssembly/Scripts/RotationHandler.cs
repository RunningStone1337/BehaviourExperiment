using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public class RotationHandler
    {
        public static readonly float QuickRotation = 5f;
        public static readonly float MiddleRotation = 2.5f;
        public static readonly float SlowRotation = 0.5f;

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

        public IEnumerator RotateToAngle(Rigidbody2D bodyToRotate, float targetRotationAngle, float anglePerFixUpdSpeed)
        {
            var startRotation = bodyToRotate.rotation;
            GetProps(targetRotationAngle, startRotation, out int sign, out float lowBorder, out float highBorder);
            while (!Mathf.Approximately(bodyToRotate.rotation, targetRotationAngle))
            {
                bodyToRotate.MoveRotation(Mathf.Clamp(bodyToRotate.rotation + sign * anglePerFixUpdSpeed, lowBorder, highBorder));
                yield return new WaitForFixedUpdate();
            }
        }

        public IEnumerator RotateToFaceDirection(Vector3 targetDirection, Rigidbody2D rotatedBody, float roatePerFixUpd)
        {
            var norm = targetDirection.normalized;
            var move = Vector2.MoveTowards(rotatedBody.transform.up, targetDirection, roatePerFixUpd * Time.fixedDeltaTime);
            var existAngle = Vector2.SignedAngle(move, targetDirection);
            var deltaAngle = Vector2.SignedAngle(rotatedBody.transform.up, move);
            while (Mathf.Abs(existAngle) > 0.5f)
            {
                rotatedBody.MoveRotation(rotatedBody.rotation + deltaAngle);
                yield return new WaitForFixedUpdate();
                move = Vector2.MoveTowards(rotatedBody.transform.up, targetDirection, roatePerFixUpd * Time.fixedDeltaTime);
                existAngle = Vector2.SignedAngle(move, targetDirection);
                deltaAngle = Vector2.SignedAngle(rotatedBody.transform.up, move);
#if DEBUG
                if (rotatedBody.TryGetComponent(out TeacherAgent t))
                {
                    //Debug.Log($"ExistAngle between target and next vector: {existAngle}");
                }
#endif
            }
            
        }
        public IEnumerator RotateToFaceDirectionStep(Vector3 targetDirection, Rigidbody2D rotatedBody, float roatePerFixUpd)
        {
            var norm = targetDirection.normalized;
            var move = Vector2.MoveTowards(rotatedBody.transform.up, targetDirection, roatePerFixUpd * Time.fixedDeltaTime);
            var existAngle = Vector2.SignedAngle(move, targetDirection);
            var deltaAngle = Vector2.SignedAngle(rotatedBody.transform.up, move);
            rotatedBody.MoveRotation(rotatedBody.rotation + deltaAngle);
            yield return new WaitForFixedUpdate();
#if DEBUG
            if (rotatedBody.TryGetComponent(out TeacherAgent t))
            {
                //Debug.Log($"ExistAngle between target and next vector: {existAngle}");
            }
#endif
        }

        public IEnumerator RotateToFaceDirection(Transform targetTransform, Rigidbody2D rotatedBody, float roatePerFixUpd)
        {
            var targetDirection = targetTransform.position - rotatedBody.transform.position;
            yield return RotateToFaceDirection(targetDirection, rotatedBody, roatePerFixUpd);          
        }
        public IEnumerator RotateToFaceDirectionStep(Transform targetTransform, Rigidbody2D rotatedBody, float roatePerFixUpd)
        {
            var targetDirection = targetTransform.position - rotatedBody.transform.position;
            yield return RotateToFaceDirectionStep(targetDirection, rotatedBody, roatePerFixUpd);
        }
        private static float WrapAngleAroundZero(float a)
        {
            if (a >= 0)
            {
                float rotation = a % 360;
                if (rotation > 180) rotation -= 360;
                return rotation;
            }
            else
            {
                float rotation = -a % 360;
                if (rotation > 180) rotation -= 360;
                return -rotation;
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