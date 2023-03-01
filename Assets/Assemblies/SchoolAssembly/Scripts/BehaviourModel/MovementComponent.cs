using Aoiti.Pathfinding;
using BuildingModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    [RequireComponent(typeof(Rigidbody2D))]
    //[RequireComponent(typeof(Collider2D))]
    public class MovementComponent<T> : MonoBehaviour
        where T : SchoolAgentBase<T>
    {
        #region fields

        [SerializeField] [Range(0.01f, 1f)] private float gridSize = 0.5f;
        [SerializeField] [Range(0.01f, 5f)]  private float movementSpeed = 0.05f;
        [SerializeField] [Range(0.01f, 5f)]  private float rotationSpeed = 0.05f;
        [SerializeField] [Range(-180f, 180f)]  private float rotationOffset;
        [SerializeField] [Range(0.01f, 0.5f)]  private float offsetStep = 0.05f;
        [SerializeField] [Range(0f, 180f)]  private float rotationAnglePrecision = 15f;
        private Pathfinder<Vector2> pathfinder;
        [SerializeField] private LayerMask obstacles;
        [SerializeField] private bool searchShortcut = false;
        [SerializeField] private bool snapToGrid = false;
        [SerializeField, Range(1, 1024)] private int recalcPerFrames = 100;
        private List<Vector2> path;
        private List<Vector2> pathLeftToGo = new List<Vector2>();
        [SerializeField] private bool drawDebugLines;
        private Vector2 targetVector;
        [SerializeField] private bool stopMovement;
        [SerializeField] [HideInInspector] Rigidbody2D thisBody;
        [SerializeField] [HideInInspector] T thisAgent;
        [SerializeField] [HideInInspector] private bool isAbleToMove;
        [SerializeField] [HideInInspector] private bool targetReached;
        [SerializeField] [HideInInspector] private RotationHandler rotationHandler;
        #endregion fields
        public bool StopMovement { get => stopMovement; set => stopMovement = value; }
        private void Awake()
        {
            thisBody = GetComponent<Rigidbody2D>();
            thisAgent = GetComponent<T>();
            rotationHandler = new RotationHandler();
        }
        private void Start()
        {
            pathfinder = new Pathfinder<Vector2>(GetDistance, GetNeighbourNodes, 1000); //increase patience or gridSize for larger maps
        }

        public IEnumerator StartMoveToPoint(Vector2 target, Func<bool> movementCondition = default)
        {
            targetVector = target;
            isAbleToMove = true;
            targetReached = false;
            pathLeftToGo = CreatePath(targetVector);
            if (pathLeftToGo != null)
                yield return MoveRoutine(movementCondition);
            else throw new System.Exception("Path not founded");
            if (targetReached)
                yield return thisAgent.OnTargetReached();
            //Debug.Log("After target reached");
            isAbleToMove = false;
        }

        public IEnumerator RotateToFaceDirection(Vector3 directionVector)
        {
            yield return rotationHandler.RotateToFaceDirection(directionVector, thisBody, rotationSpeed, rotationOffset, rotationAnglePrecision);
        }

        private IEnumerator MoveRoutine(Func<bool> movementCondition)
        {
            int recalcCounter = 0;
            while (NeedToMove() && (movementCondition == null || movementCondition.Invoke()))
            {
                Vector3 dir = (Vector3)pathLeftToGo[0] - transform.position;
                yield return rotationHandler.RotateToFaceDirection(dir, thisBody, rotationSpeed, rotationOffset, rotationAnglePrecision);
                float normSpeed = movementSpeed * Time.fixedDeltaTime;
                thisBody.MovePosition((Vector3)thisBody.position + dir.normalized * normSpeed);
                if (((Vector2)transform.position - pathLeftToGo[0]).sqrMagnitude < normSpeed)
                {
                    thisBody.MovePosition(pathLeftToGo[0]);
                    pathLeftToGo.RemoveAt(0);
                }
#if UNITY_EDITOR
                DrawPathLines();
#endif
               
                yield return null;
                recalcCounter++;
                if (recalcCounter == recalcPerFrames)
                {
                    recalcCounter = 0;
                    pathLeftToGo = CreatePath(targetVector);
                }
                //Debug.Log("Movement cycle");
            }
        }

#if UNITY_EDITOR
        private void DrawPathLines()
        {
            if (drawDebugLines)
            {
                for (int i = 0; i < pathLeftToGo.Count - 1; i++) //visualize your path in the sceneview
                {
                    Debug.DrawLine(pathLeftToGo[i], pathLeftToGo[i + 1]);
                }
            }
        }
#endif
       

        public bool NeedToMove() =>
           pathLeftToGo.Count > 0 && !stopMovement;

        private List<Vector2> CreatePath(Vector2 target)
        {
            int multiplier = 1;
            int increaseLimit = 25;
            
            Vector2 closestNode = GetClosestNode(transform.position);
            List<Vector2> offsets = GetOffsets();
            while (multiplier < increaseLimit)
            {
                for (int offs = 0; offs < offsets.Count; offs++)
                {
                    if (pathfinder.GenerateAstarPath(closestNode, GetClosestNode(target + offsets[offs] * multiplier), out path))
                    {
                        if (searchShortcut && path.Count > 0)
                            return ShortenPath(path);
                        else
                        {
                            var res = new List<Vector2>(path);
                            if (!snapToGrid) res.Add(target);
                            return res;
                        }
                    }
                }
                multiplier++;
            }
            return default;
        }

        public List<Vector2> GetOffsets()
        {
            float sqrt = Mathf.Sqrt(2) / 2f;
            float sqrOffset = offsetStep * sqrt;
            return new List<Vector2>() {
                new Vector2(),
                new Vector2(0, offsetStep),
                new Vector2(sqrOffset,sqrOffset),
                new Vector2(offsetStep,0f),
                new Vector2(sqrOffset,-sqrOffset),
                new Vector2(0, -offsetStep),
                new Vector2(-sqrOffset,-sqrOffset),
                new Vector2(-offsetStep, 0),
                new Vector2(-sqrOffset,sqrOffset)
            };
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!isAbleToMove)
                thisBody.velocity = default;
            if (collision.collider.TryGetComponent(out T agent))
            {
                if (agent == (MonoBehaviour)thisAgent.MovementTarget)
                {
                    stopMovement = true;
                    thisBody.velocity = default;
                    targetReached = true;
                }
            }
            else if (collision.collider.TryGetComponent(out PlacedInterier inter))
            {
                if (inter == (MonoBehaviour)thisAgent.MovementTarget)
                {
                    targetReached = true;
                    stopMovement = true;
                }
            }
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (!isAbleToMove)
                thisBody.velocity = default;
        }
       
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (!isAbleToMove)
                thisBody.velocity = default;
        }
        /// <summary>
        /// Finds closest point on the grid
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private Vector2 GetClosestNode(Vector2 target)
        {
            return new Vector2(Mathf.Round(target.x / gridSize) * gridSize, Mathf.Round(target.y / gridSize) * gridSize);
        }

        /// <summary>
        /// A distance approximation.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        private float GetDistance(Vector2 A, Vector2 B)
        {
            return (A - B).sqrMagnitude; //Uses square magnitude to lessen the CPU time.
        }

        /// <summary>
        /// Finds possible conenctions and the distances to those connections on the grid.
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private Dictionary<Vector2, float> GetNeighbourNodes(Vector2 pos)
        {
            Dictionary<Vector2, float> neighbours = new Dictionary<Vector2, float>();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0) continue;

                    Vector2 dir = new Vector2(i, j) * gridSize;
                    if (!Physics2D.Linecast(pos, pos + dir, obstacles))
                    {
                        neighbours.Add(GetClosestNode(pos + dir), dir.magnitude);
                    }
                }
            }
            return neighbours;
        }

        private List<Vector2> ShortenPath(List<Vector2> path)
        {
            List<Vector2> newPath = new List<Vector2>();

            for (int i = 0; i < path.Count; i++)
            {
                newPath.Add(path[i]);
                for (int j = path.Count - 1; j > i; j--)
                {
                    if (!Physics2D.Linecast(path[i], path[j], obstacles))
                    {
                        i = j;
                        break;
                    }
                }
                newPath.Add(path[i]);
            }
            newPath.Add(path[path.Count - 1]);
            return newPath;
        }
    }
}