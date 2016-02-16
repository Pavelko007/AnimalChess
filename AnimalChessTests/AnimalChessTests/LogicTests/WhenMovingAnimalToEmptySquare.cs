using AnimalChess.Logic;
using Moq;
using NUnit.Framework;

namespace AnimalChessTests.LogicTests
{
    [TestFixture]
    class WhenMovingAnimalToEmptySquare
    {
        [Test]
        public void AnimalChangePos()
        {
            //Arrange
            var curCellMock = new Mock<ICell>();
            var nextCellMock = new Mock<ICell>();
            curCellMock.Setup(x => x.Board.GetCell(It.IsAny<IPosition>())).Returns(nextCellMock.Object);
            Animal animal = new Animal(curCellMock.Object);

            //Act
            animal.Move(new Mock<IPosition>().Object);

            //Assert
            curCellMock.VerifySet(x => x.Animal = null);
            nextCellMock.VerifySet(x => x.Animal = animal);
        }

        [Test]
        public void ReturnsTrue()
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

        [Test]
        public void IfSquareIsUnreachableReturnsFalse()
        {
            //Arrange
            var curCellMock = new Mock<ICell>();
            curCellMock.Setup(x => x.Board.GetCell(It.IsAny<IPosition>())).Returns((ICell)null);

            Animal animal = new Animal(curCellMock.Object);

            //Act
            bool animalMoved = animal.Move(new Position(0, 0));

            //Assert
            Assert.False(animalMoved);
        }
    }
}