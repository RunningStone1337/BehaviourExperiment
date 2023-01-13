using System.Collections.Generic;
using System.Linq;
using static BuildingModule.DirectionUtils;

namespace BuildingModule
{
    public class RoomEditingUtil
    {
        private Entrance entrance;

        /// <summary>
        ///
        /// </summary>
        /// <param name="direction">Направление, от которого происходит отделение.</param>
        private void SeparateRoomFromDirection(Entrance entr, Direction direction, Room oldRoom, Room newRoom, List<Entrance> checkedEntrances)
        {
            var directions = GetAdditionalDirections(direction);
            entr.ThisRoom = newRoom;
            foreach (var d in directions)
            {
                var n = entr.GetNeighbourFromDirection(d);
                if (n != null && !checkedEntrances.Contains(n))
                {
                    checkedEntrances.Add(n);
                    if (n.ThisRoom == oldRoom && !entr.HasWallBetween(n))
                    {
                        var inverse = OppositeDirection(d);
                        SeparateRoomFromDirection(n, inverse, oldRoom, newRoom, checkedEntrances);
                    }
                }
            }
        }

        public RoomEditingUtil(Entrance entrance)
        {
            this.entrance = entrance;
        }

        public Room FindRoomOrCreateNew()
        {
            ///смотрим соседей, если их нет - создаём новую комнату
            if (entrance.Neighbours.Count == 0)
                return EntranceRoot.Root.RoomsPlace.gameObject.AddComponent<Room>();
            ///отсекаем тех соседей, между которыми есть стены.
            var potentialRooms = new List<Room>();
            foreach (var n in entrance.Neighbours)
            {
                if (!n.HasWallBetween(entrance) && !entrance.HasWallBetween(n))
                {
                    if (!potentialRooms.Contains(n.ThisRoom))
                        potentialRooms.Add(n.ThisRoom);
                }
            }
            ///смотрим к каким комнатам они принадлежат.
            if (potentialRooms.Count > 1)
                return potentialRooms.OrderBy(x => x.ThisRoomEntrancesCount).Last();
            else
                return potentialRooms[0];
            ///между остальными выбираем наибольшее и присасываемся к нему.
            ///дополнительные ограничения?
        }

        public bool TrySeparateRoom()
        {
            //Работает некорректно, пересмотреть логику
            if (entrance.CanBeSeparated(out Direction direction))
            {
                var newRoom = EntranceRoot.Root.RoomsPlace.gameObject.AddComponent<Room>();
                SeparateRoomFromDirection(entrance, direction, entrance.ThisRoom, newRoom, new List<Entrance>());
                return true;
            }
            return default;
        }
    }
}