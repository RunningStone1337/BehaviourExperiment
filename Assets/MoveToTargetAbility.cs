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
    [SerializeField] private float lastDistanceToTarget;
    [SerializeField] [Range(0.01f, 50f)] private float moveSpeed;
    [SerializeField] [Range(0.1f, 360f)] private float rotationSpeed;
    [SerializeField] private GameObject target;
    [SerializeField] private Vector2 targetStartPosition;
    [SerializeField] private string targetTag;
    [SerializeField] private AgentBase thisAgent;
    [SerializeField] private Vector2 thisStartPosition;

    /// <summary>
    /// 1 параметр
    /// </summary>
    /// <param name="sensor"></param>
    /// <param name="distance"></param>
    private void HandleCurrentRoomKnowledge(VectorSensor sensor, float distance)
    {
        bool matchRooms = IsRoomMatch();
        if (matchRooms)
            AddReward(3f / distance);
        sensor.AddObservation(matchRooms);
    }

    /// <summary>
    /// 27 параметров
    /// </summary>
    /// <param name="sensor"></param>
    /// <param name="posV2"></param>
    private void HandleRaycasts(VectorSensor sensor, Vector2 posV2)
    {
        var filter = new ContactFilter2D() { useTriggers = true };
        List<float> angles = new List<float>() {
            /*0.3f*/0,15,-15,30,-30,45,-45,60,-60,/*0.15f*/75,-75,90,-90,/*-0.15f*/105,-105,120,-120,/*-0.3f*/135,-135,150,-150,165,-165,180//24 угла
        };
        List<Vector3> directions = new List<Vector3>();
        foreach (var a in angles)
        {
            var vectorRotation = RotateFrom(transform.up, a);
            directions.Add(vectorRotation);
        }
        bool hitTarget = false;
        bool hitDirectly = false;
        int rayIndex = 0;
        for (int d = 0; d < directions.Count; d++)
        {
            var hits = new RaycastHit2D[10];
            var c = Physics2D.Raycast(posV2, directions[d], filter, hits);
            hitTarget = HitTarget(hits, c);
            if (hitTarget)
            {
                var roomMatch = IsRoomMatch();
                //Debug.Log($"Hit! Ray index {d}");
                rayIndex = d + 1;
                if (d >= 0 && d <= 8)
                {
                    if (d == 0)
                        AddReward(5f);
                    else if (d > 0 && d <= 4)
                    {
                        hitDirectly = true;
                        if (roomMatch)
                            AddReward(2f);
                    }
                    else if (roomMatch)
                        AddReward(0.5f);
                }
                else if (d >= 9 && d <= 12 && roomMatch)
                    AddReward(0.1f);
                else if (d >= 13 && d <= 16 && roomMatch)
                    AddReward(-1f);
                else if (roomMatch)
                    AddReward(-5f);
                if (d == 0)
                    break;
            }
        }
        sensor.AddOneHotObservation(rayIndex, directions.Count + 1);
        sensor.AddObservation(hitTarget);
        sensor.AddObservation(hitDirectly);
    }

    /// <summary>
    /// Попал ли луч в цель
    /// </summary>
    /// <param name="hits"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    private bool HitTarget(RaycastHit2D[] hits, int count)
    {
        if (count != 0)
        {
            for (int ray = 0; ray < count; ray++)
            {
                var temp = hits[ray];
                if (temp.collider != null && temp.collider != thisAgent.AgentCollider)//не в себя
                {
                    if (temp.collider.gameObject.CompareTag(targetTag) && target.GetInstanceID() == temp.collider.transform.GetInstanceID())
                        return true;
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
                AddReward(1000f);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Entrance ent))
        {
            thisAgent.CurrentRoom = ent.CurrentRoom;
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
        sensor.AddObservation(targetGlobalPosV2- globalPosV2);
        //sensor.AddObservation(globalPosV2);
        var currentDistToTarget = Vector2.Distance(targetGlobalPosV2, globalPosV2);
        //сотношение расстояний до цели в прошлое наблюдение и в это
        sensor.AddObservation(currentDistToTarget / lastDistanceToTarget);
        lastDistanceToTarget = currentDistToTarget;
        //3 параметра

        //Ориентация в простанстве и знание о видимости цели
        HandleRaycasts(sensor, globalPosV2);
        //знание о совпадении комнат или нет
        HandleCurrentRoomKnowledge(sensor, currentDistToTarget);
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
        if (move == 1)
            thisAgent.AgentRigidbody.MovePosition(thisAgent.AgentRigidbody.position + moveSpeed * Time.fixedDeltaTime * new Vector2(transform.up.x, transform.up.y));
        if (turnSide == 1)
            thisAgent.AgentRigidbody.SetRotation((thisAgent.AgentRigidbody.rotation + rotationSpeed * Time.fixedDeltaTime) % maxAngle);
        else if (turnSide == 2)
            thisAgent.AgentRigidbody.SetRotation((thisAgent.AgentRigidbody.rotation - rotationSpeed * Time.fixedDeltaTime) % maxAngle);
        else
            thisAgent.AgentRigidbody.SetRotation((thisAgent.AgentRigidbody.rotation) % maxAngle);
    }

    public override void OnEpisodeBegin()
    {
        environmentController.ResetEnvironment();
        targetStartPosition = target.transform.position;
        thisStartPosition = transform.position;
        lastDistanceToTarget = Vector2.Distance(thisStartPosition, targetStartPosition);
    }
}