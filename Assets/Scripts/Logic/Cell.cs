namespace AnimalChess.Logic
{
    public interface ICell
    {
        CellType Type { get; }
        Animal Animal { get; set; }
        bool HasAnimal { get; }
        IPosition Position { get; set; }
        IBoard Board { get; set; }
    }

    public class Cell : ICell
    {
        public IPosition Position { get; set; }
        private CellType cellType;
        public IBoard Board { get; set; }

        public Cell(Board board, Position position, CellType cellType = CellType.Walkable)
        {
            Board = board;
            Position = position;
            this.cellType = cellType;
        }

        public CellType Type { get; private set; }

        public Animal Animal { get; set; }

        public bool HasAnimal { get { return Animal != null; } }
    }
}