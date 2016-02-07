namespace AnimalChess.Logic
{
    public class Cell
    {
        public Cell(CellType type)
        {
            Type = type;
        }

        public CellType Type { get; private set; }
    }
}