using System;

namespace AnimalChess.Logic
{
    public class Animal
    {
        public ICell Cell { get; private set; }

        public Animal(ICell cell)
        {
            Cell = cell;
        }
        
        public bool Move(Direction direction)
        {
            IPosition nextPos = Cell.Position.GetNextTowards(direction);
            return Move(nextPos);
        }

        public bool Move(IPosition position)
        {
            ICell nextCell = Cell.Board.GetCell(position);
            if (null == nextCell) return false;
            return !nextCell.HasAnimal;
        }
    }
}