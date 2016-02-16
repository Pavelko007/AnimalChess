using AnimalChess.Logic;
using Moq;
using NUnit.Framework;

namespace AnimalChessTests.LogicTests.AnimalTests
{
    [TestFixture]
    class WhenMoveToOccupiedSquare
    {
        [Test]
        public void AnimalCapturesAnother()
        {
            //Arrange
            var movingAnimalCellMock = new Mock<ICell>();
            var attackingAnimal = new Animal(movingAnimalCellMock.Object);
            var eatenAnimalCellMock = new Mock<ICell>();
            var eatenAnimal = new Animal(eatenAnimalCellMock.Object);
            eatenAnimalCellMock.SetupProperty(x => x.Animal, eatenAnimal);
            movingAnimalCellMock.SetupProperty(x => x.Animal, attackingAnimal);
            movingAnimalCellMock.Setup(x => x.Board.GetCell(It.IsAny<IPosition>())).Returns(eatenAnimalCellMock.Object);
            eatenAnimalCellMock.Setup(x => x.HasAnimal).Returns(true);

            //Act
            var hasMoved = attackingAnimal.Move(new Mock<IPosition>().Object);

            //Assert
            Assert.True(hasMoved);
            Assert.That(eatenAnimalCellMock.Object.Animal, Is.Not.EqualTo(eatenAnimal));
            Assert.IsNull(movingAnimalCellMock.Object.Animal);
        }
    }
}
