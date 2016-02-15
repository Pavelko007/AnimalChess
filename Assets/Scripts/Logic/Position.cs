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
            return new Position(1,1);
        }
    }
}