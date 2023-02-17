using System;

namespace BuildingModule
{
    public class DirectionUtils
    {
        public static Direction[] GetAdditionalDirections(Direction mainDirection)
        {
            return mainDirection switch
            {
                Direction.Up => new Direction[] { Direction.Down, Direction.Right, Direction.Left },
                Direction.Down => new Direction[] { Direction.Up, Direction.Right, Direction.Left },
                Direction.Right => new Direction[] { Direction.Up, Direction.Down, Direction.Left },
                Direction.Left => new Direction[] { Direction.Up, Direction.Down, Direction.Right },
                _ => throw new Exception($"Неизвестное направление {mainDirection}"),
            };
        }

        public static Direction OppositeDirection(Direction d)
        {
            return d switch
            {
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                Direction.Right => Direction.Left,
                Direction.Left => Direction.Right,
                _ => throw new Exception($"Неизвестное направление {d}"),
            };
        }
    }
}