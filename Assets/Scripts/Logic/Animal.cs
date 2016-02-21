using System;

namespace AnimalChess.Logic
{
    public class Animal
    {
        private PlayerType playerType;
        public ICell Cell { get; set; }

        public Animal(ICell cell)
        {
            Cell = cell;
        }

        public Animal(AnimalType animalType, PlayerType playerType)
        {
            AnimalType = animalType;
            this.playerType = playerType;
        }

        public AnimalType AnimalType { get; set; }

        public bool Move(Direction direction)
        {
            IPosition nextPos = Cell.Position.GetNextTowards(direction);
            return Move(nextPos);
        }

        public bool Move(IPosition dest)
        {
            if (!IsValidDestination(dest)) return false;

            ICell nextCell = Cell.Board.GetCell(dest);
            if (null == nextCell) return false;
            if (!nextCell.HasAnimal)
            {
                nextCell.Animal = this;
                Cell.Animal = null;
                return true;
            }

            if ((int)nextCell.Animal.AnimalType > (int)AnimalType) return false;

            nextCell.Animal = this;
            Cell.Animal = null;
            return true;
        }

        private bool IsValidDestination(IPosition dest)
        {
            return dest.IsAdjacent(Cell.Position);
        }
    }
}