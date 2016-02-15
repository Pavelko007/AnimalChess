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
            var nextPos = Cell.Position.NextPos(direction);
            var nextCell = Cell.Board.GetCell(nextPos);
            return !nextCell.HasAnimal;
        }
    }
}