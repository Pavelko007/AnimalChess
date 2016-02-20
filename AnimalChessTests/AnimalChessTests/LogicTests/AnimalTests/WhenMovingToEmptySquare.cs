using AnimalChess.Logic;
using Moq;
using NUnit.Framework;

namespace AnimalChessTests.LogicTests.AnimalTests
{
    public abstract class WhenMovingToValidSquareBase
    {
        protected Mock<IPosition> destMock;

        [SetUp]
        public virtual void Init()
        {
            destMock = new Mock<IPosition>();
            destMock.Setup(x => x.IsAdjacent(It.IsAny<IPosition>())).Returns(true);
        }
    }

    [TestFixture]
    class WhenMovingToEmptySquare : WhenMovingToValidSquareBase
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
            animal.Move(destMock.Object);

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
            curCellMock.Setup(x => x.Board.GetCell(It.IsAny<IPosition>())).Returns(nextCellMock.Object);
            nextCellMock.Setup(x => x.HasAnimal).Returns(false);

            Animal animal = new Animal(curCellMock.Object);

            //Act
            bool animalMoved = animal.Move(destMock.Object);

            //Assert
            Assert.True(animalMoved);
        }
    }
}