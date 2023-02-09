using BehaviourModel;
using BuildingModule;
using Common;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class MoveToTargetAbility : Agent
{
    [SerializeField] private EnvironmentController environmentController;
    private RayCastsInfo lastCastInfo;
    [SerializeField] [Range(0.01f, 50f)] private float moveSpeed;
    [SerializeField] [Range(0.1f, 360f)] private float rotationSpeed;
    [SerializeField] private float startDistanceToTarget;
    [SerializeField] private GameObject target;
    [SerializeField] private Vector2 targetStartPosition;
    [SerializeField] private string targetTag;
    [SerializeField] private SchoolAgentBase thisAgent;
    [SerializeField] private Vector2 thisStartPosition;

    private static List<float> GetAnglesForRays()
    {
        List<float> angles = new List<float>() { 0 };
        for (int angle = 1; angle <= 45; angle += 2)
        {
            angles.Add(angle);
            angles.Add(-angle);
        }
        for (int angle = 50; angle <= 90; angle += 5)
        {
            angles.Add(angle);
            angles.Add(-angle);
        }
        for (int angle = 105; angle < 180; angle += 15)
        {
            angles.Add(angle);
            angles.Add(-angle);
        }
        angles.Add(180);
        return angles;
    }

    private void CreateRaycastToDirection(ref RayCastsInfo castsInfo, (Vector3 directionVector, float angleFormForward) direction, int dirIndex)
    {
        var filter = new ContactFilter2D() { useTriggers = true };
        Vector2 posV2 = transform.position;
        var hits = new RaycastHit2D[64];
        var hitsCount = Physics2D.Raycast(posV2, direction.directionVector, filter, hits);
        var hitTarget = HitTarget(hits, hitsCount, out int hitIndex);
        var currentCast = castsInfo.AllCasts[dirIndex] = new RayCastInfo()
        {
            rayIndex = dirIndex,
            SubrayHitIndex = hitIndex,
            HitTarget = hitTarget,
            rayAngle = direction.angleFormForward,
            RaycastHits = hits,
        };
        castsInfo.UpdateInfo(currentCast);
    }

    private void DrawRays()
    {
        var hitInfo = GetRaycastsInfo();
        Vector2 startPos = transform.position;
        foreach (var ray in hitInfo.AllCasts)
        {
            var currentInfo = ray.RaycastHits;
            for (int subRay = 0; subRay < currentInfo.Length; subRay++)
            {
                if (currentInfo[subRay].point == new Vector2(0, 0))
                    break;
                if (ray.HitTarget && subRay == ray.SubrayHitIndex)
                    Gizmos.color = Color.green;
                else
                    Gizmos.color = Color.red;
                var endPoint = currentInfo[subRay].point;
                Gizmos.DrawRay(startPos, endPoint - startPos);
                startPos = endPoint;
            }
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            RequestDecision();
        }
    }

    private float GetCurrentDistanceToTarget()
    {
        Vector2 globalPosV2 = transform.position;
        Vector2 targetGlobalPosV2 = target.transform.position;
        return Vector2.Distance(targetGlobalPosV2, globalPosV2);
    }

    private List<(Vector3 directionVector, float angleFormForward)> GetDirectionVectorsWithAnglesFromForward(List<float> angles)
    {
        List<(Vector3 directionVector, float angleFormForward)> directions = new List<(Vector3, float)>();
        foreach (var a in angles)
        {
            var vectorRotation = RotateFrom(transform.up, a);
            directions.Add((vectorRotation, a));
        }

        return directions;
    }

    private RayCastsInfo GetRaycastsInfo()
    {
        List<float> angles = GetAnglesForRays();
        List<(Vector3 directionVector, float angleFormForward)> directions = GetDirectionVectorsWithAnglesFromForward(angles);
        RayCastInfo[] allHits = new RayCastInfo[directions.Count];
        RayCastsInfo result = new RayCastsInfo() { AllCasts = allHits, RaysCount = allHits.Length };
        for (int dirCount = 0; dirCount < directions.Count; dirCount++)
            CreateRaycastToDirection(ref result, directions[dirCount], dirCount);
        return result;
    }

    /// <summary>
    /// Попал ли луч в цель
    /// </summary>
    /// <param name="hits"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    private bool HitTarget(RaycastHit2D[] hits, int count, out int hitIndex)
    {
        hitIndex = -1;
        if (count != 0)
        {
            for (int ray = 0; ray < count; ray++)
            {
                var temp = hits[ray];
                if (temp.collider != null && temp.collider != thisAgent.AgentCollider)//не в себя
                {
                    if (temp.collider.gameObject.CompareTag(targetTag) && target.GetInstanceID() == temp.collider.gameObject.GetInstanceID())
                    {
                        hitIndex = ray;
                        return true;
                    }
                }
            }
        }
        return default;
    }

    private bool IsRoomMatch()
    {
        var currentRoom = thisAgent.CurrentRoom;
        bool matchRooms = false;
        var isRoomHandler = target.TryGetComponent(out ICurrentRoomHandler h);
        if (isRoomHandler && currentRoom != null)
        {
            if (h.CurrentRoom.GetInstanceID() == currentRoom.GetInstanceID())
                matchRooms = true;
        }

        return matchRooms;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (target != null)
        {
            if (collision.transform == target.transform)
            {
                AddReward(10000f);
                EndEpisode();
            }
            else if (collision.collider.TryGetComponent(out Wall wall))
            {
                AddReward(-0.05f);
                //EndEpisode();
            }
            else if (collision.collider.TryGetComponent(out InterierBase inter))
            {
                AddReward(-0.02f);
                //EndEpisode();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (target != null)
        {
            if (collision.collider.TryGetComponent(out Wall wall))
            {
                AddReward(-0.5f);
                //EndEpisode();
            }
            else if (collision.collider.TryGetComponent(out InterierBase inter))
            {
                AddReward(-0.2f);
                //EndEpisode();
            }
        }
    }

    private void OnDrawGizmos()
    {
        //DrawRays();
    }

    private void OnDrawGizmosSelected()
    {
        DrawRays();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Entrance ent))
        {
            thisAgent.CurrentRoom = ent.CurrentRoom;
        }
    }

    private struct RayCastInfo
    {
        internal int SubrayHitIndex;
        public bool HitTarget;
        public float rayAngle;
        public RaycastHit2D[] RaycastHits;
        public int rayIndex;
    }

    private struct RayCastsInfo
    {
        public RayCastInfo[] AllCasts;
        public RayCastInfo? bestHitInfo;
        public int DirectHitsCount;
        public bool IsHitDirectly;
        public bool IsHitFront;
        public bool IsHitPerifery;
        public bool IsHitTarget;
        public int PeriferyHitsCount;
        public int RaysCount;
        public float TotalHitsCount;

        public void UpdateInfo(RayCastInfo currentCast)
        {
            if (bestHitInfo == null)
                bestHitInfo = currentCast;
            if (!IsHitTarget)
                IsHitTarget = currentCast.HitTarget;
            if (currentCast.HitTarget)
                TotalHitsCount++;
            var angle = currentCast.rayAngle;
            var absAngle = Mathf.Abs(angle);
            if (!IsHitDirectly)
                IsHitDirectly = absAngle <= 15;
            DirectHitsCount += absAngle <= 15 ? 1 : 0;
            if (!IsHitPerifery)
                IsHitPerifery = absAngle > 15 && absAngle <= 45;
            PeriferyHitsCount += absAngle > 15 && absAngle <= 45 ? 1 : 0;
            if (!IsHitFront)
                IsHitFront = absAngle <= 90;
        }
    }

    public static Vector2 RotateFrom(Vector2 v, float a, bool bUseRadians = false)
    {
        if (!bUseRadians) a *= Mathf.Deg2Rad;
        var ca = Mathf.Cos(a);
        var sa = Mathf.Sin(a);
        var rx = v.x * ca - v.y * sa;

        return new Vector2((float)rx, (float)(v.x * sa + v.y * ca));
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        Vector2 localPosV2 = transform.localPosition;
        Vector2 targetLocalPosV2 = target.transform.localPosition;
        Vector2 globalPosV2 = transform.position;
        Vector2 targetGlobalPosV2 = target.transform.position;
        var currentDistToTarget = Vector2.Distance(targetGlobalPosV2, globalPosV2);
        //сотношение расстояний до сейчас и в начале
        var currentDistanceRelation = currentDistToTarget / startDistanceToTarget;
        sensor.AddObservation(currentDistanceRelation);

        var currentStartPositionRelation = (globalPosV2 - thisStartPosition).normalized;
        var targetCrrentStartPositionRelation = (targetGlobalPosV2 - targetStartPosition).normalized;
        sensor.AddObservation(currentStartPositionRelation);
        sensor.AddObservation(targetCrrentStartPositionRelation);
        //5 параметра

        //Ориентация в простанстве и знание о видимости цели
        lastCastInfo = GetRaycastsInfo();
        //Debug.Log("Hit count" + lastCastInfo.AllCasts.Count(x => x.HitTarget));
        //sensor.AddObservation(info.rayIndex);
        sensor.AddObservation(lastCastInfo.IsHitTarget);
        sensor.AddObservation(lastCastInfo.IsHitDirectly);
        sensor.AddObservation(lastCastInfo.IsHitPerifery);
        sensor.AddObservation(lastCastInfo.IsHitFront);
        //знание о совпадении комнат или нет
        bool matchRooms = IsRoomMatch();
        sensor.AddObservation(matchRooms);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var a = actionsOut.DiscreteActions;
        a[0] = (int)Input.GetAxisRaw("Vertical") == 1 ? 1 : 0;
        var input = (int)Input.GetAxisRaw("Horizontal");
        //Debug.Log(" Input" + input);
        if (input == -1)
            a[1] = 1;
        else if (input == 1)
            a[1] = 2;
        else
            a[1] = 0;
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        var a = actions.DiscreteActions;
        var move = a[0];
        var turnSide = a[1];
        var maxAngle = 360f;
        var posBeforeMove = transform.position;
        var DistToTargetBeforeMove = Vector2.Distance(posBeforeMove, target.transform.position);
        if (move == 1)
            thisAgent.AgentRigidbody.MovePosition(thisAgent.AgentRigidbody.position + moveSpeed * Time.fixedDeltaTime * new Vector2(transform.up.x, transform.up.y));
        if (turnSide == 1)
            thisAgent.AgentRigidbody.SetRotation((thisAgent.AgentRigidbody.rotation + rotationSpeed * Time.fixedDeltaTime) % maxAngle);
        else if (turnSide == 2)
            thisAgent.AgentRigidbody.SetRotation((thisAgent.AgentRigidbody.rotation - rotationSpeed * Time.fixedDeltaTime) % maxAngle);
        else
            thisAgent.AgentRigidbody.SetRotation((thisAgent.AgentRigidbody.rotation) % maxAngle);

        var info = GetRaycastsInfo();
        //сценарии:
        //попал в наблюдение
        if (info.IsHitTarget && !lastCastInfo.IsHitTarget)
        {
            if (info.IsHitDirectly)
                AddReward(5f * info.DirectHitsCount);
            else if (info.IsHitPerifery)
                AddReward(2.5f * info.PeriferyHitsCount);
            else if (info.IsHitFront)
                AddReward(1f);
        }
        //продолжается наблюдение
        else if (info.IsHitTarget && lastCastInfo.IsHitTarget)
        {
            var currentPos = transform.position;
            var DistToTargetAfterMove = Vector2.Distance(currentPos, target.transform.position);
            //если стал ближе - награда
            if (DistToTargetAfterMove < DistToTargetBeforeMove)
            {
                if (info.IsHitDirectly)
                    AddReward(5f * info.DirectHitsCount);
                else if (info.IsHitPerifery)
                    AddReward(2.5f * info.PeriferyHitsCount);
                else if (info.IsHitFront)
                    AddReward(1f);
            }
            //иначе штраф
            else
            {
                if (info.IsHitDirectly)
                    AddReward(-5f * info.DirectHitsCount);
                else if (info.IsHitPerifery)
                    AddReward(-2.5f * info.PeriferyHitsCount);
                else if (info.IsHitFront)
                    AddReward(-1f);
            }
        }
        //исчез из наблюдения
        else if (!info.IsHitTarget && lastCastInfo.IsHitTarget)
        {
            AddReward(-10f * info.DirectHitsCount);
        }
    }

    public override void OnEpisodeBegin()
    {
        environmentController.ResetEnvironment();
        targetStartPosition = target.transform.position;
        thisStartPosition = transform.position;
        startDistanceToTarget = Vector2.Distance(thisStartPosition, targetStartPosition);
    }
}