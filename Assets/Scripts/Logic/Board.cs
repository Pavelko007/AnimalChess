using System;

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
                    var pos = new Position(rowIdx, colIdx);
                    boardGrid[rowIdx, colIdx] = new Cell(this, pos);
                }
            }
        }

        public Cell GetCell(Position position)
        {
            return GetCell(position.Row, position.Col);
        }

        public Cell GetCell(int row, int col)
        {
            return boardGrid[row, col];
        }
    }
}
