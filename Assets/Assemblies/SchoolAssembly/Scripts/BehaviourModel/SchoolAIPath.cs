using BuildingModule;
using Pathfinding;
using Pathfinding.Util;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    public class SchoolAIPath : AIPath
    {
        [SerializeField, HideInInspector] private Rigidbody2D agentBody;
        [SerializeField] private AgentEnvironment agentEnvironment;
        [SerializeField] private AIDestinationSetter destSetter;

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

        protected override void Awake()
        {
            base.Awake();
            agentEnvironment = GetComponent<AgentEnvironment>();
            destSetter = GetComponent<AIDestinationSetter>();
            agentBody = GetComponent<Rigidbody2D>();
        }

        protected override void FixedUpdate()
        {
            if (shouldRecalculatePath) SearchPath();

            if (canMove)
            {
                Vector3 nextPosition;
                Quaternion nextRotation;
                MovementUpdate(Time.fixedDeltaTime, out nextPosition, out nextRotation);
                FinalizeMovement(nextPosition, nextRotation);
            }
        }

        protected override void MovementUpdateInternal(float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation)
        {
            float currentAcceleration = maxAcceleration;

            // If negative, calculate the acceleration from the max speed
            if (currentAcceleration < 0) currentAcceleration *= -maxSpeed;

            if (updatePosition)
            {
                // Get our current position. We read from transform.position as few times as possible as it is relatively slow
                // (at least compared to a local variable)
                simulatedPosition = tr.position;
            }
            if (updateRotation) simulatedRotation = tr.rotation;

            var currentPosition = simulatedPosition;

            // Update which point we are moving towards
            interpolator.MoveToCircleIntersection2D(currentPosition, pickNextWaypointDist, movementPlane);
            var dir = movementPlane.ToPlane(steeringTarget - currentPosition);

            // Calculate the distance to the end of the path
            float distanceToEnd = dir.magnitude + Mathf.Max(0, interpolator.remainingDistance);

            // Check if we have reached the target
            var prevTargetReached = reachedEndOfPath;
            reachedEndOfPath = distanceToEnd <= endReachedDistance && interpolator.valid;
            if (!prevTargetReached && reachedEndOfPath) OnTargetReached();
            float slowdown;

            // Normalized direction of where the agent is looking
            var forwards = movementPlane.ToPlane(simulatedRotation * (orientation == OrientationMode.YAxisForward ? Vector3.up : Vector3.forward));

            // Check if we have a valid path to follow and some other script has not stopped the character
            bool stopped = isStopped || (reachedDestination && whenCloseToDestination == CloseToDestinationMode.Stop);
            if (interpolator.valid && !stopped)
            {
                // How fast to move depending on the distance to the destination.
                // Move slower as the character gets closer to the destination.
                // This is always a value between 0 and 1.
                slowdown = distanceToEnd < slowdownDistance ? Mathf.Sqrt(distanceToEnd / slowdownDistance) : 1;

                if (reachedEndOfPath && whenCloseToDestination == CloseToDestinationMode.Stop)
                {
                    // Slow down as quickly as possible
                    velocity2D -= Vector2.ClampMagnitude(velocity2D, currentAcceleration * deltaTime);
                }
                else
                {
                    velocity2D += MovementUtilities.CalculateAccelerationToReachPoint(dir, dir.normalized * maxSpeed, velocity2D, currentAcceleration, rotationSpeed, maxSpeed, forwards) * deltaTime;
                }
            }
            else
            {
                slowdown = 1;
                // Slow down as quickly as possible
                velocity2D -= Vector2.ClampMagnitude(velocity2D, currentAcceleration * deltaTime);
            }

            velocity2D = MovementUtilities.ClampVelocity(velocity2D, maxSpeed, slowdown, slowWhenNotFacingTarget && enableRotation, forwards);

            ApplyGravity(deltaTime);

            if (rvoController != null && rvoController.enabled)
            {
                // Send a message to the RVOController that we want to move
                // with this velocity. In the next simulation step, this
                // velocity will be processed and it will be fed back to the
                // rvo controller and finally it will be used by this script
                // when calling the CalculateMovementDelta method below

                // Make sure that we don't move further than to the end point
                // of the path. If the RVO simulation FPS is low and we did
                // not do this, the agent might overshoot the target a lot.
                var rvoTarget = currentPosition + movementPlane.ToWorld(Vector2.ClampMagnitude(velocity2D, distanceToEnd), 0f);
                rvoController.SetTarget(rvoTarget, velocity2D.magnitude, maxSpeed);
            }

            // Set how much the agent wants to move during this frame
            var delta2D = lastDeltaPosition = CalculateDeltaToMoveThisFrame(movementPlane.ToPlane(currentPosition), distanceToEnd, deltaTime);
            nextPosition = currentPosition + movementPlane.ToWorld(delta2D, verticalVelocity * lastDeltaTime);
            CalculateNextRotation(slowdown, out nextRotation);
        }

        protected override void Update()
        {
        }

        public override void OnTargetReached()
        {
            if (destSetter.target == null)
                return;
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
                constrainInsideGraph = false;
                chair.Collider2D.isTrigger = true;
                var ag = GetComponent<IAgent>();
                chair.ChairInfo.CurrentAgent = ag;
                chair.ChairInfo.BindedAgent = ag;

                agentEnvironment.ChairInfo = chair.ChairInfo;
                agentEnvironment.BindedChair = chair;
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