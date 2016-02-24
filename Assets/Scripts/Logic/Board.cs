using System.Collections.Generic;
using System.Linq;

namespace AnimalChess.Logic
{
    public interface IBoard
    {
        ICell GetCell(IPosition position);
        ICell GetCell(int row, int col);
    }

    public class Board : IBoard
    {
        private Cell[,] boardGrid = new Cell[9, 7];


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
            AddAnimalAt(1, 1, new Animal(AnimalType.Cat, PlayerType.BottomPlayer));
            AddAnimalAt(1, 5, new Animal(AnimalType.Dog, PlayerType.BottomPlayer));
            AddAnimalAt(6, 0, new Animal(AnimalType.Rat, PlayerType.TopPlayer));
        }

        private void AddAnimalAt(int row, int col, Animal animal)
        {
            var cell = GetCell(row, col);
            cell.Animal = animal;
            animal.Cell = cell;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return boardGrid.Cast<Cell>().Where(cell => cell.HasAnimal).Select(cell => cell.Animal).ToList();
        }
    }
}
