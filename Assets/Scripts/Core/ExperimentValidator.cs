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
               "Не найдено ни одного помещения с ролью класса. Необходимо как минимум 1 помещение.");
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
                "Необходимо добавить как минимум 1 доску в класс.");
        }

        private string ExitCondition()
        {
            return ConditionCheck(() => EntranceRoot.Root.Rooms.Count(x => x.Role is ExitRole) != 0,
                "Не найдено ни одного помещения с ролью выхода. Необходимо как минимум 1 помещение.");
        }

        private string FreePlacesCondition()
        {
            return ConditionCheck(() => InterierHandler.Handler.Chairs.Count >= selectedAgentsHandler.AgentsCount(),
                "Свободных сидячих мест меньше, чем учеников. Добавьте больше мест или удалите часть учеников.");
        }

        private string FreeTablesConditon()
        {
            return ConditionCheck(() => InterierHandler.Handler.Tables.Count * 2 >= selectedAgentsHandler.AgentsCount(),
               "Свободных столов недостаточно. Добавьте больше столов или удалите часть учеников.");
        }

        private string LeastOneClassPerDayCondition()
        {
            return ConditionCheck(AtLeastOneClassAtDay,
                  "Необходимо выбрать как минимум 1 занятие на каждый рабочий день недели.");
        }

        private string MoreThen0PupilCondition()
        {
            return ConditionCheck(() =>
            {
                var puilsCount = selectedAgentsHandler.AgentsCount();
                return puilsCount >= 1;
            }, "Необходим как минимум 1 ученик для начала эксперимента. Добавьте учеников через конфигуратор.");
        }

        private string OuterWallsCondition()
        {
            return ConditionCheck(OuterWallsExisted,
                "Обнаружены отсутствующие граничные стены помещений. Добавьте недостающие стены.");
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
                "Для проведения эксперимента необходим учитель. Добавьте его через конфигуратор.");
        }

        private string WorkDaysCondition()
        {
            return ConditionCheck(() => scheduleHandler.WorkDays.Count > 0,
                "Необходимо выбрать как минимум 1 рабочий день недели.");
        }

        /// <summary>
        /// проверка готовности к началу проведения.
        /// Если все условия удовлетворены, эксперимент начинается.
        /// Иначе пользователь уведомляется о неготовности к проведению.
        /// </summary>
        public void Validate()
        {
            ForceCoreModulesUpdate();
            var conditions = new List<Func<string>>() {
                ///1)существуют помещения:
                ///-учебный класс
                ClassCondition,
                ///-выход
                ///-коридор - опционально
                ExitCondition,
                ///2)все внешние стены существуют
                OuterWallsCondition,
                ///3)не менее 1 ученика в конфигураторе
                MoreThen0PupilCondition,
                ///4)учитель в конфигураторе
                TeacherCondition,
                ///5)свободных мест не менее чем учеников в конфигураторе
                FreePlacesCondition,
                ///5.1)свободных столов не менее чем учеников в классе/2
                FreeTablesConditon,
                ///6)есть как минимум 1 учебная доска в классе
                DesksCondition,
                ///7)есть как минимум 1 рабочий день недели
                WorkDaysCondition,
                ///8)есть как минимум по 1 занятию на каждый учебный день
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