namespace AnimalChess.Logic
{
    public class Board
    {
        private Cell[,] boardGrid = new Cell[9,7];

        public Board()
        {
            Init();
        }

        private void Init()
        {
            for (int rowIdx = 0; rowIdx < boardGrid.GetLength(0); rowIdx++)
            {
                for (int colIdx = 0; colIdx < boardGrid.GetLength(1); colIdx++)
                {
                    var pos = new Postion(rowIdx, colIdx);
                    boardGrid[rowIdx, colIdx] = new Cell(pos, CellType.Walkable);
                }
            }
        }

        public Cell GetCell(int row, int col)
        {
            return boardGrid[row - 1, col - 1];
        }
    }
}
