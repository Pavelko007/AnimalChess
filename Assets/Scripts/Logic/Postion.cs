namespace AnimalChess.Logic
{
    public class Postion
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Postion(int row, int col)
        {
            Col = col;
            Row = row;
        }
    }
}