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
        [SerializeField] private Rigidbody2D agentRigidbody;
        [SerializeField] private AIDestinationSetter destSetter;
        [SerializeField] private Transform lastTarget;
        public Transform LastTarget { set => lastTarget = value; }
        protected override void Awake()
        {
            base.Awake();
            agentEnvironment = GetComponent<AgentEnvironment>();
            agentRigidbody = GetComponent<Rigidbody2D>();
            destSetter = GetComponent<AIDestinationSetter>();
        }
        private IEnumerator RotateToFace(Vector3 direction)
        {
            Debug.Log("Rotate to face callback enter");
            var rotator = new RotationHandler();
            yield return rotator.RotateToFaceDirection(direction, agentRigidbody, 3f);
            Debug.Log("Rotate to face callback end");
        }
        
        public override void OnTargetReached()
        {
            if (destSetter.target == null)
            {
                Debug.Log("Target reached callback breaked");
                return;
            }
            Debug.Log("Target reached callback raised succeeded");
            if (lastTarget.TryGetComponent(out ChairMovePoint chairPoint))
            {
                var chair = chairPoint.GetComponentInParent<ChairInterier>();
                HandleChairReached(chair);
                SetThisChairTableProps(chair);
            }
            LastTarget = null;
            destSetter.target = null;//.destination

            void HandleChairReached(ChairInterier chair)
            {
                //destSetter.target = null;
                chair.Collider2D.isTrigger = true;
                chair.ChairInfo.ThisAgent = GetComponent<IAgent>();
                agentRigidbody.velocity = default;
                //yield return MovementComponent.StartMoveToTransform(chair.transform, () => true);
                Teleport(chair.transform.position);
                //agentRigidbody.MovePosition(chair.transform.position);
                Debug.Log("Agent body moved to chair");
                agentEnvironment.ChairInfo = chair.ChairInfo;
                //yield return RotateRoutine(chair.transform.up);
                //agentRigidbody.bodyType = RigidbodyType2D.Kinematic;
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