namespace AnimalChess.Logic
{
    public class Cell
    {
        public Position Position;
        private CellType cellType;
        public Board board;

        public Cell(Board board, Position position, CellType cellType = CellType.Walkable)
        {
            this.board = board;
            this.Position = position;
            this.cellType = cellType;
        }
        
        public CellType Type { get; private set; }

        public Animal Animal { get; set; }
        public bool HasAnimal { get { return Animal != null; } }
    }
}