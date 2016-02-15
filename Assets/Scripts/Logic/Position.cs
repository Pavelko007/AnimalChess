using System;

namespace AnimalChess.Logic
{
    public interface IPosition
    {
        int Row { get; }
        int Col { get; }
        IPosition NextPos(Direction direction);
    }

    public class Position : IPosition
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Position(int row, int col)
        {
            Col = col;
            Row = row;
        }

        public IPosition NextPos(Direction direction)
        {
            return null;
        }

        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            var pos = (Position)obj;
            return pos.Row == Row && pos.Col == Col;
        }
    }
}