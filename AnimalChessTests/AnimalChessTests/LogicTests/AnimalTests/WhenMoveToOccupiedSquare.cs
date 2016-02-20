using AnimalChess.Logic;
using Moq;
using NUnit.Framework;

namespace AnimalChessTests.LogicTests.AnimalTests
{
    [TestFixture]
    class WhenMoveToOccupiedSquare: WhenMovingToValidSquareBase
    {
        private Mock<ICell> attackingAnimalCellMock;
        private Mock<ICell> otherAnimalCellMock;
        private Animal attackingAnimal;
        private Animal otherAnimal;

        [SetUp]
        public override void Init()
        {
            base.Init();
            attackingAnimalCellMock = new Mock<ICell>();
            otherAnimalCellMock = new Mock<ICell>();
        }

        [TearDown]
        public void Dispose()
        {
            attackingAnimalCellMock = null;
            attackingAnimal = null;
            otherAnimalCellMock = null;
            otherAnimal = null;
        }

        [TestCase(AnimalType.Dog, AnimalType.Cat)]
        [TestCase(AnimalType.Dog, AnimalType.Dog)]
        public void AnimalWithHigherOrEqualRankCanEatAnother(AnimalType attackingAnimalType, AnimalType otherAnimalType)
        {
            //Arrange
            ArrangeForTwoAnimals(attackingAnimalType, otherAnimalType);

            //Act
            bool hasMoved = attackingAnimal.Move(destMock.Object);

            //Assert
            Assert.True(hasMoved);
            Assert.That(otherAnimalCellMock.Object.Animal, Is.EqualTo(attackingAnimal));
            Assert.IsNull(attackingAnimalCellMock.Object.Animal);
        }

        [TestCase(AnimalType.Cat, AnimalType.Dog)]
        public void AnimalWithLowerRankCanNotEatAnother(AnimalType attackingAnimalType, AnimalType otherAnimalType)
        {
            //Arrange
            ArrangeForTwoAnimals(attackingAnimalType, otherAnimalType);

            //Act
            bool hasMoved = attackingAnimal.Move(destMock.Object);

            //Assert
            Assert.False(hasMoved);
            Assert.That(otherAnimalCellMock.Object.Animal, Is.EqualTo(otherAnimal));
            Assert.That(attackingAnimalCellMock.Object.Animal, Is.EqualTo(attackingAnimal));
        }

        private void ArrangeForTwoAnimals(AnimalType attackingAnimalType, AnimalType otherAnimalType)
        {
            attackingAnimal = new Animal(attackingAnimalType);
            otherAnimal = new Animal(otherAnimalType) {Cell = otherAnimalCellMock.Object};

            otherAnimalCellMock.SetupProperty(x => x.Animal, otherAnimal);
            attackingAnimal.Cell = attackingAnimalCellMock.Object;

            attackingAnimalCellMock.SetupProperty(x => x.Animal, attackingAnimal);
            attackingAnimalCellMock.Setup(x => x.Board.GetCell(It.IsAny<IPosition>())).Returns(otherAnimalCellMock.Object);
            otherAnimalCellMock.Setup(x => x.HasAnimal).Returns(true);
        }
    }
}
