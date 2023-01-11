using BuildingModule;
using System.Linq;
using UnityEngine;
using Extensions;
using System.Collections.Generic;
using Common;

namespace Core
{
    public class ExperimentValidator : MonoBehaviour
    {
        [SerializeField] SelectedAgentsHandler selectedAgentsHandler;
        [SerializeField] ScheduleHandler scheduleHandler;

        /// <summary>
        /// �������� ���������� � ������ ����������.
        /// ���� ��� ������� �������������, ����������� ����������.
        /// ����� ������������ ������������ � ������������ � ����������.
        /// </summary>
        public void Validate()
        {
            string userNotification = default;
            ///1)���������� ���������:
            ///-������� �����
            var classes = EntranceRoot.Root.Rooms.Count(x => x.Role is ClassRole) != 0;
            if (classes)
            {
                ///-�����
                var exit = EntranceRoot.Root.Rooms.Count(x => x.Role is ExitRole) != 0;
                if (exit)
                {
                    ///-������� - �����������
                    ///2)��� ������� ����� ����������
                    var outerWalls = OuterWallsExisted();
                    if (outerWalls)
                    {
                        ///3)�� ����� 1 ������� � �������������
                        var puilsCount = selectedAgentsHandler.AgentsCount();
                        var pupilsCountValid = puilsCount >= 1;
                        if (pupilsCountValid)
                        {
                            ///4)������� � �������������
                            var teacher = selectedAgentsHandler.Teacher != null;
                            if (teacher)
                            {
                                ///5)��������� ���� �� ����� ��� �������� � �������������
                                var freePlaces = InterierHandler.Handler.Chairs.Count >= puilsCount;
                                if (freePlaces)
                                {
                                    ///5.1)��������� ������ �� ����� ��� �������� � ������/2
                                    var freeTables = InterierHandler.Handler.Tables.Count * 2 >= puilsCount;
                                    if (freeTables)
                                    {
                                        ///6)���� ��� ������� 1 ������� ����� � ������
                                        var desks = InterierHandler.Handler.Boards.Count > 0;
                                        if (desks)
                                        {
                                            ///7)���� ��� ������� 1 ������� ���� ������
                                            var workDays = scheduleHandler.WorkDays.Count >0;
                                            if (workDays)
                                            {
                                                ///8)���� ��� ������� �� 1 ������� �� ������ ������� ����
                                                var leastOneClassPerDay = AtLeastOneClassAtDay();
                                                if (leastOneClassPerDay)
                                                {
                                                    ///9)???
                                                    StartExpretiment();
                                                    return;
                                                }
                                                else
                                                    userNotification = "���������� ������� ��� ������� 1 ������� �� ������ ������� ���� ������.";
                                            }
                                            else
                                                userNotification = "���������� ������� ��� ������� 1 ������� ���� ������.";
                                        }
                                        else
                                            userNotification = "���������� �������� ��� ������� 1 ����� � �����.";
                                    }
                                    else
                                        userNotification = "��������� ������ ������������. �������� ������ ������ ��� ������� ����� ��������.";
                                }
                                else
                                    userNotification = "��������� ������� ���� ������, ��� ��������. �������� ������ ���� ��� ������� ����� ��������.";
                            }
                            else
                                userNotification = "��� ���������� ������������ ��������� �������. �������� ��� ����� ������������.";
                        }
                        else
                            userNotification = "��������� ��� ������� 1 ������ ��� ������ ������������. �������� �������� ����� ������������.";
                    }
                    else
                        userNotification = "���������� ������������� ��������� ����� ���������. �������� ����������� �����.";
                }
                else
                    userNotification = "�� ������� �� ������ ��������� � ����� ������. ���������� ��� ������� 1 ���������.";
            }
            else
                userNotification = "�� ������� �� ������ ��������� � ����� ������. ���������� ��� ������� 1 ���������.";
            NotificationSystem.NotifyMaster.SendNotification(userNotification);
        }

        private bool AtLeastOneClassAtDay()
        {
            foreach (var day in scheduleHandler.WorkDays)
            {
                if (day.EnabledOptions.Count == 0)
                    return false;
            }
            return true;
        }

        private void StartExpretiment()
        {
            throw new System.NotImplementedException();
        }

        

        private bool OuterWallsExisted()
        {
            var entr = EntranceRoot.Root.Entrances;
            foreach (var e in entr)
            {
                var entWallPairs = new List<(Entrance e, Wall w)>() 
                {
                    (e.RightNeighbour, e.RightWall),                
                    (e.DownNeighbour, e.DownWall),                
                    (e.LeftNeighbour, e.LeftWall),                
                    (e.UpNeighbour, e.UpWall),                
                };
                foreach (var pair in entWallPairs)
                {
                    if (pair.e == null)
                        if (!(pair.w.CurrentState is ActiveState))
                            return false;
                }               
            }
            return true;
        }
    }
}