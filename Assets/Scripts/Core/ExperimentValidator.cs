using BuildingModule;
using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using Notify = Common.NotificationSystem;
using UIController = UI.CanvasController;

namespace Core
{
    public class ExperimentValidator : MonoBehaviour
    {
        [SerializeField] private ScheduleHandler scheduleHandler;
        [SerializeField] private SelectedAgentsHandler selectedAgentsHandler;
        [SerializeField] private ExperimentProcessHandler experimentProcess;

        private bool AtLeastOneClassAtDay()
        {
            foreach (var day in scheduleHandler.WorkDays)
            {
                if (day.EnabledOptions.Count == 0)
                    return false;
            }
            return true;
        }

        private string ClassCondition()
        {
            return ConditionCheck(() => EntranceRoot.Root.Rooms.Count(x => x.Role is ClassRole) != 0,
               "�� ������� �� ������ ��������� � ����� ������. ���������� ��� ������� 1 ���������.");
        }

        private string ConditionCheck(Func<bool> func, string message)
        {
            var res = func.Invoke();
            if (!res)
                return message;
            return default;
        }

        private string DesksCondition()
        {
            return ConditionCheck(() => InterierHandler.Handler.Boards.Count > 0,
                "���������� �������� ��� ������� 1 ����� � �����.");
        }

        private string ExitCondition()
        {
            return ConditionCheck(() => EntranceRoot.Root.Rooms.Count(x => x.Role is ExitRole) != 0,
                "�� ������� �� ������ ��������� � ����� ������. ���������� ��� ������� 1 ���������.");
        }

        private string FreePlacesCondition()
        {
            return ConditionCheck(() => InterierHandler.Handler.Chairs.Count >= selectedAgentsHandler.AgentsCount(),
                "��������� ������� ���� ������, ��� ��������. �������� ������ ���� ��� ������� ����� ��������.");
        }

        private string FreeTablesConditon()
        {
            return ConditionCheck(() => InterierHandler.Handler.Tables.Count * 2 >= selectedAgentsHandler.AgentsCount(),
               "��������� ������ ������������. �������� ������ ������ ��� ������� ����� ��������.");
        }

        private string LeastOneClassPerDayCondition()
        {
            return ConditionCheck(AtLeastOneClassAtDay,
                  "���������� ������� ��� ������� 1 ������� �� ������ ������� ���� ������.");
        }

        private string MoreThen0PupilCondition()
        {
            return ConditionCheck(() =>
            {
                var puilsCount = selectedAgentsHandler.AgentsCount();
                return puilsCount >= 1;
            }, "��������� ��� ������� 1 ������ ��� ������ ������������. �������� �������� ����� ������������.");
        }

        private string OuterWallsCondition()
        {
            return ConditionCheck(OuterWallsExisted,
                "���������� ������������� ��������� ����� ���������. �������� ����������� �����.");
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

        private string TeacherCondition()
        {
            return ConditionCheck(() => selectedAgentsHandler.Teacher != null,
                "��� ���������� ������������ ��������� �������. �������� ��� ����� ������������.");
        }

        private string WorkDaysCondition()
        {
            return ConditionCheck(() => scheduleHandler.WorkDays.Count > 0,
                "���������� ������� ��� ������� 1 ������� ���� ������.");
        }

        /// <summary>
        /// �������� ���������� � ������ ����������.
        /// ���� ��� ������� �������������, ����������� ����������.
        /// ����� ������������ ������������ � ������������ � ����������.
        /// </summary>
        public void Validate()
        {
            ForceCoreModulesUpdate();
            var conditions = new List<Func<string>>() {
                ///1)���������� ���������:
                ///-������� �����
                ClassCondition,
                ///-�����
                ///-������� - �����������
                ExitCondition,
                ///2)��� ������� ����� ����������
                OuterWallsCondition,
                ///3)�� ����� 1 ������� � �������������
                MoreThen0PupilCondition,
                ///4)������� � �������������
                TeacherCondition,
                ///5)��������� ���� �� ����� ��� �������� � �������������
                FreePlacesCondition,
                ///5.1)��������� ������ �� ����� ��� �������� � ������/2
                FreeTablesConditon,
                ///6)���� ��� ������� 1 ������� ����� � ������
                DesksCondition,
                ///7)���� ��� ������� 1 ������� ���� ������
                WorkDaysCondition,
                ///8)���� ��� ������� �� 1 ������� �� ������ ������� ����
                LeastOneClassPerDayCondition
                ///9)???
            };
            foreach (var c in conditions)
            {
                var message = c.Invoke();
                if (message != null)
                {
                    Notify.NotifyMaster.SendNotification(message);
                    return;
                }
            }
            experimentProcess.StartExperiment();
        }

        private void ForceCoreModulesUpdate()=>
            StartCoroutine(ForceCoreModulesUpdateRoutine());

        private IEnumerator ForceCoreModulesUpdateRoutine()
        {
            var bs = UIController.Controller.BuildingScreen;
            var es = UIController.Controller.EventsPlanningScreen;
            var acs = UIController.Controller.AgentsConfigureScreen;
            var screens = new List<UIScreenBase>();
            if (!bs.IsInitialized)
            {
                bs.InitiateState();
                screens.Add(bs);
            }
            if (!es.IsInitialized)
            {
                es.InitiateState();
                screens.Add(es);
            }
            if (!acs.IsInitialized)
            {
                acs.InitiateState();
                screens.Add(acs);
            }
            yield return null;
            foreach (var s in screens)
                s.BeforeChangeState();
        }
    }
}