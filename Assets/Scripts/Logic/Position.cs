using System;

namespace AnimalChess.Logic
{
    public class Position
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Position(int row, int col)
        {
            Col = col;
            Row = row;
        }

        public Position NextPos(Direction direction)
        {
            return new Position(0, 1);
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