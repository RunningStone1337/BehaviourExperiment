using BuildingModule;
using Pathfinding;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    public class SchoolAIPath : AIPath
    {
        
        [SerializeField] private AgentEnvironment agentEnvironment;
        [SerializeField] private AIDestinationSetter destSetter;
        [SerializeField, HideInInspector] private Rigidbody2D agentBody;
        protected override void Awake()
        {
            base.Awake();
            agentEnvironment = GetComponent<AgentEnvironment>();
            destSetter = GetComponent<AIDestinationSetter>();
            agentBody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IAgent ag) && !canMove)
                agentBody.velocity = default;
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IAgent ag) && !canMove)
                agentBody.velocity = default;
        }
        
        public override void OnTargetReached()
        {
            if (destSetter.target == null)
            {
                return;
            }
            //Debug.Log("Target reached callback raised succeeded");
            if (destSetter.target.TryGetComponent(out ChairMovePoint chairPoint))//подход к стулу, промежуточная точка
            {
                var chair = chairPoint.GetComponentInParent<ChairInterier>();
                HandleChairPointReached(chair);
                SetThisChairTableProps(chair);
            }
            else
            {
                destSetter.target = null;//.destination
                canMove = false;
            }

            void HandleChairPointReached(ChairInterier chair)
            {
                chair.Collider2D.isTrigger = true;
                chair.ChairInfo.ThisAgent = GetComponent<IAgent>();
                agentEnvironment.ChairInfo = chair.ChairInfo;
                destSetter.target = chair.transform;
            }

            void SetThisChairTableProps(ChairInterier chair)
            {
                var closestTable = InterierHandler.Handler.Tables
                                    .Select(x => (Vector3.Distance(x.transform.position, chair.transform.position), x))
                                    .OrderBy(x => x.Item1).First().x;

                agentEnvironment.TableInfo = closestTable.TableInfo;
                agentEnvironment.TableInfo.AddAgentIfFree(GetComponent<IAgent>());
            }
        }
    }
}