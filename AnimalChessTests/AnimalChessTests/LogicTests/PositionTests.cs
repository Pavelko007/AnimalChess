using AnimalChess.Logic;
using NUnit.Framework;

namespace AnimalChessTests.LogicTests
{
    [TestFixture]
    class PositionTests
    {
        private Position position = new Position(5, 5);

        [Test]
        public void GetNextLeftTest()
        {
            GetNextTowartTest(position, Direction.Left, new Position(4, 5));
        }

        [Test]
        public void GetNextRightTest()
        {
            GetNextTowartTest(position, Direction.Right, new Position(6, 5));
        }

        [Test]
        public void GetNextUpTest()
        {
            GetNextTowartTest(position, Direction.Up, new Position(5, 6));
        }

        [Test]
        public void GetNextDownTest()
        {
            GetNextTowartTest(position, Direction.Down, new Position(5, 4));
        }

        private static void GetNextTowartTest(Position position, Direction direction, Position result)
        {
            //Act
            var nextPos = position.GetNextTowards(direction);

            //Assert
            Assert.AreEqual(result, nextPos);
        }
    }
}
