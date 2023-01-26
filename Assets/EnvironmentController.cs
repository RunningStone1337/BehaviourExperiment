using BehaviourModel;
using BuildingModule;
using Common;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] private AgentBase agent;
    [SerializeField] private List<GameObject> interierObjects;
    [SerializeField] private List<Room> rooms;
    [SerializeField] private Vector2 startPositionsXagent;
    [SerializeField] private Vector2 startPositionsXtarget;
    [SerializeField] private Vector2 startPositionsYagent;
    [SerializeField] private Vector2 startPositionsYtarget;
    [SerializeField] private Transform targetTransform;

    private void RebuiltInterierInRoom(Room r)
    {
        throw new NotImplementedException();
    }

    private void ResetAgent()
    {
        var room = rooms[Random.Range(0, rooms.Count)];
        var pos = room.transform.localPosition;
        agent.transform.localPosition = new Vector3(
            pos.x + Random.Range(startPositionsXagent.x, startPositionsXagent.y),
            pos.y + Random.Range(startPositionsYagent.x, startPositionsYagent.y), 0);
        agent.AgentRigidbody.SetRotation(Random.Range(0f, 360f));
        agent.CurrentRoom = room;
    }

    private void ResetTarget()
    {
        var room = rooms[Random.Range(0, rooms.Count)];
        var pos = room.transform.localPosition;
        targetTransform.localPosition = new Vector3(
            pos.x + Random.Range(startPositionsXtarget.x, startPositionsXtarget.y),
            pos.y + Random.Range(startPositionsYtarget.x, startPositionsYtarget.y));
        if (targetTransform.TryGetComponent(out ICurrentRoomHandler h))
            h.CurrentRoom = room;
    }

    public void ResetEnvironment()
    {
        //перестроить объекты интерьера
        foreach (var r in rooms)
        {
            //RebuiltInterierInRoom(r);
        }
        //ResetAgent();
        ResetTarget();
    }
}