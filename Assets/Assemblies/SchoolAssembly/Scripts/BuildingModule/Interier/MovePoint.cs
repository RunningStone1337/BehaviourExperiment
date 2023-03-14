using BehaviourModel;
using Common;
using UnityEngine;

namespace BuildingModule
{
    [RequireComponent(typeof(Collider2D))]
    public class MovePoint : MonoBehaviour, ICanBeOccuped, IMovementTarget
    {
        [SerializeField] protected bool isOccuped;
        [SerializeField] protected CircleCollider2D placeCollider;

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PupilAgent pup))
                IsOccuped = true;
            else if (collision.TryGetComponent(out TeacherAgent teach))
                IsOccuped = true;
        }

        protected virtual void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PupilAgent pup))
                IsOccuped = false;
            else if (collision.TryGetComponent(out TeacherAgent teach))
                IsOccuped = false;
        }

        public bool IsOccuped { get => isOccuped; set => isOccuped = value; }
    }
}