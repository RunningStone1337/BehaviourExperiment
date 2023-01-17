using BuildingModule;
using Common;
using Core;
using UnityEngine;

namespace BehaviourModel
{
    public class Eyes : MonoBehaviour
    {
        [SerializeField] private AgentBase thisAgent;
        [SerializeField] private PolygonCollider2D viewCollider;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != thisAgent.NearestFeelingCollider)
            {
                var contextHandler = collision.GetComponent<IContextCreator>();
                if (contextHandler != null)
                {
                    if (contextHandler is PlacedInterier pi)
                        thisAgent.SeeingInterier.Add(pi);
                    if (contextHandler is IInfluenceSource iis)
                        thisAgent.CurrentComfort += iis.InfluenceValue;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision != thisAgent.NearestFeelingCollider)
            {
                var contextHandler = collision.GetComponent<IContextCreator>();
                if (contextHandler != null)
                {
                    if (contextHandler is PlacedInterier pi)
                        thisAgent.SeeingInterier.Remove(pi);
                    if (contextHandler is IInfluenceSource iis)
                        thisAgent.CurrentComfort -= iis.InfluenceValue;
                }
            }
        }

        public PolygonCollider2D ViewCollider => viewCollider;
    }
}