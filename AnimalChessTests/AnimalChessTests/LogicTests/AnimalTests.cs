using AnimalChess.Logic;
using Moq;
using NUnit.Framework;

namespace AnimalChessTests.LogicTests
{
    [TestFixture]
    class AnimalTests
    {
        [Test]
        public void MoveAnimalToEmptyCellReturnsTrue()
        {
            //Arrange
            var boardMock = new Mock<IBoard>();

            var animalPos = new Position(0, 0);
            var curCell = new Cell(null, animalPos);

            Animal animal = new Animal(curCell);
            curCell.Animal = animal;
            boardMock.Setup(foo => foo.GetCell(animalPos)).Returns(curCell);
            curCell.Board = boardMock.Object;

            var nextCellMock = new Mock<ICell>();
            var nextCellPos = new Position(0, 1);
            nextCellMock.Setup(foo => foo.HasAnimal).Returns(false);

            boardMock.Setup(foo => foo.GetCell(nextCellPos)).Returns(nextCellMock.Object);

            //Act
            bool animalMoved = animal.Move(Direction.Right);

            //Assert
            Assert.True(animalMoved);
        }
    }
}