using BuildingModule;
using Common;
using Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class Eyes : MonoBehaviour, IPhenomenonsCreator
    {
        [SerializeField] private AgentBase thisAgent;
        [SerializeField] private PolygonCollider2D viewCollider;
        [SerializeField] private List<IPhenomenon> visiblePhenomenons;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != thisAgent.AgentCollider)
            {
                var phen = collision.GetComponent<IPhenomenon>();
                if (phen != null)
                {
                    if (!VisiblePhenomens.Contains(phen))
                        VisiblePhenomens.Add(phen);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision != thisAgent.AgentCollider)
            {
                var phen = collision.GetComponent<IPhenomenon>();
                if (phen != null)
                {
                    if (VisiblePhenomens.Contains(phen))
                        VisiblePhenomens.Remove(phen);
                }
            }
        }

        public PolygonCollider2D ViewCollider => viewCollider;
        public List<IPhenomenon> VisiblePhenomens { get => visiblePhenomenons; private set => visiblePhenomenons = value; }

        /// <summary>
        /// Визуальные источники действий, окружение.
        /// Определяется тем что видит напрямую.
        /// </summary>
        /// <returns></returns>
        public List<IPhenomenon> GetPhenomenons()
        {
            var res = new List<IPhenomenon>(VisiblePhenomens);
            return res;
        }
    }
}