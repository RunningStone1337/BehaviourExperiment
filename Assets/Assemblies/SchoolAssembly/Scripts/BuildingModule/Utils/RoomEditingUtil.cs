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
        /// <param name="direction">�����������, �� �������� ���������� ���������.</param>
        private void SeparateRoomFromDirection(Entrance entr, Direction direction, Room oldRoom, Room newRoom, List<Entrance> checkedEntrances)
        {
            var directions = GetAdditionalDirections(direction);
            entr.CurrentRoom = newRoom;
            foreach (var d in directions)
            {
                var n = entr.GetNeighbourFromDirection(d);
                if (n != null && !checkedEntrances.Contains(n))
                {
                    checkedEntrances.Add(n);
                    if (n.CurrentRoom == oldRoom && !entr.HasWallBetween(n))
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
            ///������� �������, ���� �� ��� - ������ ����� �������
            if (entrance.Neighbours.Count == 0)
            {
                var room = EntranceRoot.Root.RoomsPlace.gameObject.AddComponent<Room>();
                room.Initiate();
                return room;
            }
            ///�������� ��� �������, ����� �������� ���� �����.
            var nonSeparatedRooms = new HashSet<Room>();
            var separatedRooms = new HashSet<Room>();
            //�������� �����. ������� �� ������� ����� ������������ ��� �������������
            foreach (var n in entrance.Neighbours)
            {
                if (!n.HasWallBetween(entrance) && !entrance.HasWallBetween(n))
                    nonSeparatedRooms.Add(n.CurrentRoom);
                else
                    separatedRooms.Add(n.CurrentRoom);
            }
            ///������� � ����� �������� ��� �����������.
            if (nonSeparatedRooms.Count > 0)
                return nonSeparatedRooms.OrderBy(x => x.ThisRoomEntrancesCount).Last();
            else
                return separatedRooms.OrderBy(x => x.ThisRoomEntrancesCount).Last();
            ///����� ���������� �������� ���������� � ������������� � ����.
            ///�������������� �����������?
        }

        public bool TrySeparateRoom()
        {
            //�������� �����������, ������������ ������
            if (entrance.CanBeSeparated(out Direction direction))
            {
                var newRoom = EntranceRoot.Root.RoomsPlace.gameObject.AddComponent<Room>();
                newRoom.Initiate();
                SeparateRoomFromDirection(entrance, direction, entrance.CurrentRoom, newRoom, new List<Entrance>());
                return true;
            }
            return default;
        }
    }
}