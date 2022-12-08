using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BuildingModule
{
    /// <summary>
    /// ��������, ������������ ������������ Entrance ��� ������ ��������� �� ����� �����������.
    /// </summary>
    public class Room : MonoBehaviour
    {
        [SerializeField] EntranceRoleBase role;
        [SerializeField] List<Entrance> thisRoomEntrances;
        public EntranceRoleBase Role { get=>role; set=>role = value; }
        public List<Entrance> ThisRoomEntrances { get => thisRoomEntrances; }
        private void Awake()
        {
            thisRoomEntrances = new List<Entrance>();
            EntranceRoot.Root.Rooms.Add(this);
            Role = (EntranceRoleBase)CanvasController.Controller.RolesScreen.ClassRoleView.CorrespondingObjectPrefab;
        }
        private void OnDestroy()
        {
            EntranceRoot.Root.Rooms.Remove(this);
        }

        internal void StartEntrancesRoutine()
        {
            foreach (var entrance in ThisRoomEntrances)
            {
                entrance.StartRoutine();
            }
        }

        public void HandleRoomSeparation(Entrance senarationEntrance)
        {
            ///���������� ������� ����������.
            //if (senarationEntrance.VerticalConnection())
            //{
            //    var entrances = senarationEntrance.UpNeighbour.GetCurrentRoomEntrancesExcept(senarationEntrance);
            //}
            //else
            //{

            //}
            ///����� ������� �� ���� �� ������(����� ����������)
            ///������� ����� �������
            ///������� � � �������� ����� ��� ���� ������� ������ � ��������� �������
            
        }
    }
}