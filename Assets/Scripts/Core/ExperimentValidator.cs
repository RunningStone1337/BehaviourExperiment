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
        /// проверка готовности к началу проведения.
        /// Если все условия удовлетворены, эксперимент начинается.
        /// Иначе пользователь уведомляется о неготовности к проведению.
        /// </summary>
        public void Validate()
        {
            string userNotification = default;
            ///1)существуют помещения:
            ///-учебный класс
            var classes = EntranceRoot.Root.Rooms.Count(x => x.Role is ClassRole) != 0;
            if (classes)
            {
                ///-выход
                var exit = EntranceRoot.Root.Rooms.Count(x => x.Role is ExitRole) != 0;
                if (exit)
                {
                    ///-коридор - опционально
                    ///2)все внешние стены существуют
                    var outerWalls = OuterWallsExisted();
                    if (outerWalls)
                    {
                        ///3)не менее 1 ученика в конфигураторе
                        var puilsCount = selectedAgentsHandler.AgentsCount();
                        var pupilsCountValid = puilsCount >= 1;
                        if (pupilsCountValid)
                        {
                            ///4)учитель в конфигураторе
                            var teacher = selectedAgentsHandler.Teacher != null;
                            if (teacher)
                            {
                                ///5)свободных мест не менее чем учеников в конфигураторе
                                var freePlaces = InterierHandler.Handler.Chairs.Count >= puilsCount;
                                if (freePlaces)
                                {
                                    ///5.1)свободных столов не менее чем учеников в классе/2
                                    var freeTables = InterierHandler.Handler.Tables.Count * 2 >= puilsCount;
                                    if (freeTables)
                                    {
                                        ///6)есть как минимум 1 учебная доска в классе
                                        var desks = InterierHandler.Handler.Boards.Count > 0;
                                        if (desks)
                                        {
                                            ///7)есть как минимум 1 рабочий день недели
                                            var workDays = scheduleHandler.WorkDays.Count >0;
                                            if (workDays)
                                            {
                                                ///8)есть как минимум по 1 занятию на каждый учебный день
                                                var leastOneClassPerDay = AtLeastOneClassAtDay();
                                                if (leastOneClassPerDay)
                                                {
                                                    ///9)???
                                                    StartExpretiment();
                                                    return;
                                                }
                                                else
                                                    userNotification = "Необходимо выбрать как минимум 1 занятие на кажыдй рабочий день недели.";
                                            }
                                            else
                                                userNotification = "Необходимо выбрать как минимум 1 рабочий день недели.";
                                        }
                                        else
                                            userNotification = "Необходимо добавить как минимум 1 доску в класс.";
                                    }
                                    else
                                        userNotification = "Свободных столов недостаточно. Добавьте больше столов или удалите часть учеников.";
                                }
                                else
                                    userNotification = "Свободных сидячих мест меньше, чем учеников. Добавьте больше мест или удалите часть учеников.";
                            }
                            else
                                userNotification = "Для проведения эксперимента необходим учитель. Добавьте его через конфигуратор.";
                        }
                        else
                            userNotification = "Необходим как минимум 1 ученик для начала эксперимента. Добавьте учеников через конфигуратор.";
                    }
                    else
                        userNotification = "Обнаружены отсутствующие граничные стены помещений. Добавьте недостающие стены.";
                }
                else
                    userNotification = "Не найдено ни одного помещения с ролью выхода. Необходимо как минимум 1 помещение.";
            }
            else
                userNotification = "Не найдено ни одного помещения с ролью класса. Необходимо как минимум 1 помещение.";
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