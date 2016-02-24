using System;

namespace AnimalChess.Logic
{
    public class Animal
    {
        private PlayerType playerType;
        public ICell Cell { get; set; }

        public Animal(AnimalType animalType, PlayerType playerType)
        {
            AnimalType = animalType;
            this.playerType = playerType;
        }

        public AnimalType AnimalType { get; set; }

        public bool TryMove(Direction direction)
        {
            IPosition nextPos = Cell.Position.GetNextTowards(direction);
            return TryMove(nextPos);
        }

        public bool TryMove(IPosition dest)
        {
            if (!IsValidDestination(dest)) return false;

            ICell nextCell = Cell.Board.GetCell(dest);
            if (null == nextCell) return false;

            if (!nextCell.HasAnimal)
            {
                Move(nextCell);
                return true;
            }

            Animal nextCellAnimal = nextCell.Animal;

            if (IsAlly(nextCellAnimal) ||
                !CanEat(nextCellAnimal)) return false;

            Move(nextCell);
            return true;
        }

        private void Move(ICell nextCell)
        {
            nextCell.Animal = this;
            Cell.Animal = null;
            Cell = nextCell;
        }

        private bool CanEat(Animal nextCellAnimal)
        {
            return (int)nextCellAnimal.AnimalType <= (int)AnimalType;
        }

        private bool IsAlly(Animal nextCellAnimal)
        {
            return nextCellAnimal.playerType == playerType;
        }

        private bool IsValidDestination(IPosition dest)
        {
            return dest.IsAdjacent(Cell.Position);
        }
    }
}