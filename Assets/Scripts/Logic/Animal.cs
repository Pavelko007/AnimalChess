namespace AnimalChess.Logic
{
    public class Animal
    {
        public Cell Cell { get; private set; }

        public Animal(Cell cell)
        {
            Cell = cell;
        }
        
        public bool Move(Direction direction)
        {
            var nextPos = Cell.Position.NextPos(direction);
            return Cell.board.GetCell(nextPos).HasAnimal;
        }
    }
}