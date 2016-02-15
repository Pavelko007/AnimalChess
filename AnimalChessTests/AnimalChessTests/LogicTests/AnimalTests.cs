using AnimalChess.Logic;
using NUnit.Framework;

namespace AnimalChessTests.LogicTests
{
    [TestFixture]
    class AnimalTests
    {

        [Test]
        public void MoveAnimalToEmptyCellReturnsTrue()
        {
            var board = new Board();
            var cell = board.GetCell(1, 1);
            cell.Animal = new Animal(cell);

            Assert.True(cell.Animal.Move(Direction.Right));
        }
    }
}