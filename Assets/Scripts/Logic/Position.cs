using System;

namespace AnimalChess.Logic
{
    public interface IPosition
    {
        int Row { get; }
        int Col { get; }
        IPosition GetNextTowards(Direction direction);
    }
    /// <summary>
    /// identifies cell positions on board
    /// leftmost bottom cell is at {row = 0, col = 0}
    /// </summary>
    public class Position : IPosition
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Position(int row, int col)
        {
            Col = col;
            Row = row;
        }

        public Position(Position position)
        {
            Row = position.Row;
            Col = position.Col;
        }

        public IPosition GetNextTowards(Direction direction)
        {
            var result = new Position(this);
            switch (direction)
            {
                case Direction.Left:
                    result.Row--;
                    break;
                case Direction.Right:
                    result.Row++;
                    break;
                case Direction.Up:
                    result.Col++;
                    break;
                case Direction.Down:
                    result.Col--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction", direction, null);
            }
            return result;
        }

        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            var pos = (Position)obj;
            return pos.Row == Row && pos.Col == Col;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Col;
            }
        }
    }
}