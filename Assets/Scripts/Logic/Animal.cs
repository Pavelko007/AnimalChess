using System;

namespace AnimalChess.Logic
{
    public class Animal
    {
        public ICell Cell { get; set; }

        public Animal(ICell cell)
        {
            Cell = cell;
        }

        public Animal(AnimalType animalType)
        {
            AnimalType = animalType;
        }

        public AnimalType AnimalType { get; set; }

        public bool Move(Direction direction)
        {
            IPosition nextPos = Cell.Position.GetNextTowards(direction);
            return Move(nextPos);
        }

        public bool Move(IPosition position)
        {
            ICell nextCell = Cell.Board.GetCell(position);
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
    }
}