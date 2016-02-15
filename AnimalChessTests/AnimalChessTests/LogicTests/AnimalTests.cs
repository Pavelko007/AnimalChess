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
            var curCellMock = new Mock<ICell>();
            var nextCellMock = new Mock<ICell>();
            curCellMock.Setup(x => x.Position.GetNextTowards(It.IsAny<Direction>()));
            curCellMock.Setup(x => x.Board.GetCell(It.IsAny<IPosition>())).Returns(nextCellMock.Object);
            nextCellMock.Setup(foo => foo.HasAnimal).Returns(false);

            Animal animal = new Animal(curCellMock.Object);

            //Act
            bool animalMoved = animal.Move(Direction.Right);

            //Assert
            Assert.True(animalMoved);
        }
    }
}