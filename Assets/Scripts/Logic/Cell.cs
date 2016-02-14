namespace AnimalChess.Logic
{
    public class Cell
    {
        private Postion postion;
        private CellType cellType;

        public Cell(Postion postion, CellType cellType)
        {
            this.postion = postion;
            this.cellType = cellType;
        }
        
        public CellType Type { get; private set; }
    }
}