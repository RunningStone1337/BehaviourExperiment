using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class ColliderDetector : Sensor
    {
        [SerializeField] private LayerMask detectMask;
        [SerializeField] private LayerMask obstaclesMask;
        [SerializeField] private SchoolAgentBase<PupilAgent> thisAgent;
        [SerializeField] private PolygonCollider2D sensorCollider;
        [SerializeField] private List<IPhenomenon> detectedPhenomenons;
        [SerializeField, Range(0f, 2f)] float secondsStayingCollectingInterval = 0.5f;
        [SerializeField, HideInInspector] float currentTimer;
        private void AddIfNotContainsAndRaycast(IPhenomenon phen)
        {
            if (!DetectedPhenomens.Contains(phen))
            {
                var mono = (MonoBehaviour)phen;
                var startPos = transform.position;
                var endPos = mono.transform.position;
                if (!Physics2D.Linecast(startPos, endPos, obstaclesMask) &&
                    Physics2D.Linecast(startPos, endPos, detectMask))
                    DetectedPhenomens.Add(phen);
                //Debug.Log("New phenom founded");
            }
        }

        private void Awake()
        {
            DetectedPhenomens = new List<IPhenomenon>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IPhenomenon phen))
                AddIfNotContainsAndRaycast(phen);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IPhenomenon phen))
                RemoveIfContains(phen);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (currentTimer <= 0f)
            {
                if (collision.TryGetComponent(out IPhenomenon phen))
                {
                    AddIfRaycastRemoveIfNot(phen);
                }
                currentTimer = secondsStayingCollectingInterval;
            }
            currentTimer -= Time.fixedDeltaTime;
        }

        private void AddIfRaycastRemoveIfNot(IPhenomenon phen)
        {
            var mono = (MonoBehaviour)phen;
            var startPos = transform.position;
            var endPos = mono.transform.position;
            if (!DetectedPhenomens.Contains(phen))
            {
                if (!Physics2D.Linecast(startPos, endPos, obstaclesMask) &&
                    Physics2D.Linecast(startPos, endPos, detectMask))
                    DetectedPhenomens.Add(phen);
            }
            else if (Physics2D.Linecast(startPos, endPos, obstaclesMask) ||
                    !Physics2D.Linecast(startPos, endPos, detectMask))
                DetectedPhenomens.Remove(phen);
        }

        private void RemoveIfContains(IPhenomenon phen)
        {
            if (DetectedPhenomens.Contains(phen))
            {
                DetectedPhenomens.Remove(phen);
                //Debug.Log("Phenom removed");
            }
        }

        public PolygonCollider2D SensorCollider => sensorCollider;
        List<IPhenomenon> DetectedPhenomens { get => detectedPhenomenons; set => detectedPhenomenons = value; }

        /// <summary>
        /// Визуальные источники действий, окружение.
        /// Определяется тем что видит напрямую.
        /// </summary>
        /// <returns></returns>
        public override List<IPhenomenon> CollectObservations()
        {
            var res = new List<IPhenomenon>(DetectedPhenomens);
            return res;
        }
    }
}