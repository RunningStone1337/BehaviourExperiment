using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class Eyes : Sensor
    {
        [SerializeField] private LayerMask detectMask;
        [SerializeField] private LayerMask obstaclesMask;
        [SerializeField] private SchoolAgentBase thisAgent;
        [SerializeField] private PolygonCollider2D viewCollider;
        [SerializeField] private List<IPhenomenon> visiblePhenomenons;

        private void AddIfNotContainsAndRaycast(IPhenomenon phen)
        {
            if (!VisiblePhenomens.Contains(phen))
            {
                var mono = (MonoBehaviour)phen;
                var startPos = transform.position;
                var endPos = mono.transform.position;
                if (!Physics2D.Linecast(startPos, endPos, obstaclesMask) &&
                    Physics2D.Linecast(startPos, endPos, detectMask))
                    VisiblePhenomens.Add(phen);
                //Debug.Log("New phenom founded");
            }
        }

        private void Awake()
        {
            VisiblePhenomens = new List<IPhenomenon>();
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
            if (collision.TryGetComponent(out IPhenomenon phen))
            {
                AddIfRaycastRemoveIfNot(phen);
            }
        }

        private void AddIfRaycastRemoveIfNot(IPhenomenon phen)
        {
            var mono = (MonoBehaviour)phen;
            var startPos = transform.position;
            var endPos = mono.transform.position;
            if (!VisiblePhenomens.Contains(phen))
            {
                if (!Physics2D.Linecast(startPos, endPos, obstaclesMask) &&
                    Physics2D.Linecast(startPos, endPos, detectMask))
                    VisiblePhenomens.Add(phen);
            }
            else if (Physics2D.Linecast(startPos, endPos, obstaclesMask) ||
                    !Physics2D.Linecast(startPos, endPos, detectMask))
                VisiblePhenomens.Remove(phen);
        }

        private void RemoveIfContains(IPhenomenon phen)
        {
            if (VisiblePhenomens.Contains(phen))
            {
                VisiblePhenomens.Remove(phen);
                //Debug.Log("Phenom removed");
            }
        }

        public PolygonCollider2D ViewCollider => viewCollider;
        public List<IPhenomenon> VisiblePhenomens { get => visiblePhenomenons; private set => visiblePhenomenons = value; }

        /// <summary>
        /// Визуальные источники действий, окружение.
        /// Определяется тем что видит напрямую.
        /// </summary>
        /// <returns></returns>
        public override List<IPhenomenon> CreatePhenomenons()
        {
            var res = new List<IPhenomenon>(VisiblePhenomens);
            return res;
        }
    }
}