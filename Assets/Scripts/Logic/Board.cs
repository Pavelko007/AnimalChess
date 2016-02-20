using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

namespace AnimalChess.Logic
{
    public interface IBoard
    {
        ICell GetCell(IPosition position);
        ICell GetCell(int row, int col);
    }

    public class Board : IBoard
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
        
        public ICell GetCell(IPosition position)
        {
            return GetCell(position.Row, position.Col);
        }

        public ICell GetCell(int row, int col)
        {
            return boardGrid[row, col];
        }

        public void CreateAnimals()
        {
            GetCell(1, 1).Animal = new Animal(AnimalType.Cat);
            GetCell(1, 5).Animal = new Animal(AnimalType.Dog);
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return boardGrid.Cast<Cell>().Where(cell => cell.HasAnimal).Select(cell => cell.Animal).ToList();
        }
    }
}
