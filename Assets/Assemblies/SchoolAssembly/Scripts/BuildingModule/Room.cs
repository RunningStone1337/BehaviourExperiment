using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BuildingModule
{
    /// <summary>
    /// —ущность, определ€юща€ совокупность Entrance как единое помещение со своим назначением.
    /// </summary>
    public class Room : MonoBehaviour
    {
        [SerializeField] private EntranceRoleBase role;
        [SerializeField] private List<Entrance> thisRoomEntrances;

        private List<Entrance> ThisRoomEntrances { get => thisRoomEntrances; }

        private void OnDestroy()
        {
            EntranceRoot.Root.Rooms.Remove(this);
        }

        public EntranceRoleBase Role { get => role; set => role = value; }

        public int ThisRoomEntrancesCount => ThisRoomEntrances.Count;

        public void AddEntrance(Entrance entrance)
        {
            ThisRoomEntrances.Add(entrance);
        }

        public Entrance RandomEntrance() => ThisRoomEntrances.GetRandom();

        public void RemoveEntrance(Entrance entrance)
        {
            ThisRoomEntrances.Remove(entrance);
            if (ThisRoomEntrances.Count == 0)
                Destroy(this);
        }

        public void StartEntrancesRoutine()
        {
            foreach (var entrance in ThisRoomEntrances)
            {
                entrance.StartRoutine();
            }
        }

        public void Initiate()
        {
            thisRoomEntrances = new List<Entrance>();
            EntranceRoot.Root.Rooms.Add(this);
            Role = (EntranceRoleBase)CanvasController.Controller.RolesScreen.ClassRoleView.CorrespondingObjectPrefab;
        }
    }
}