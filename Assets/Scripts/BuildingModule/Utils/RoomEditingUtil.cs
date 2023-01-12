using System.Collections.Generic;
using System.Linq;
using static BuildingModule.DirectionUtils;

namespace BuildingModule
{
    public class RoomEditingUtil
    {
        #region Public Constructors

        public RoomEditingUtil(Entrance entrance)
        {
            this.entrance = entrance;
        }

        #endregion Public Constructors

        #region Public Methods

        public Room FindRoomOrCreateNew()
        {
            ///������� �������, ���� �� ��� - ������ ����� �������
            if (entrance.Neighbours.Count == 0)
                return EntranceRoot.Root.RoomsPlace.gameObject.AddComponent<Room>();
            ///�������� ��� �������, ����� �������� ���� �����.
            var potentialRooms = new List<Room>();
            foreach (var n in entrance.Neighbours)
            {
                if (!n.HasWallBetween(entrance) && !entrance.HasWallBetween(n))
                {
                    if (!potentialRooms.Contains(n.ThisRoom))
                        potentialRooms.Add(n.ThisRoom);
                }
            }
            ///������� � ����� �������� ��� �����������.
            if (potentialRooms.Count > 1)
                return potentialRooms.OrderBy(x => x.ThisRoomEntrances.Count).Last();
            else
                return potentialRooms[0];
            ///����� ���������� �������� ���������� � ������������� � ����.
            ///�������������� �����������?
        }

        public bool TrySeparateRoom()
        {
            //�������� �����������, ������������ ������
            if (entrance.IsOnBoard(out Direction direction))
            {
                var newRoom = EntranceRoot.Root.RoomsPlace.gameObject.AddComponent<Room>();
                SeparateRoomFromDirection(entrance, direction, entrance.ThisRoom, newRoom, new List<Entrance>());
                return true;
            }
            return default;
        }

        #endregion Public Methods

        #region Private Fields

        private Entrance entrance;

        #endregion Private Fields

        #region Private Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="direction">�����������, �� �������� ���������� ���������.</param>
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

        #endregion Private Methods
    }
}