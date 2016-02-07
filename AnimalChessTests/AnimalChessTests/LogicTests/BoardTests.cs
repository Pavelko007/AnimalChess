using AnimalChess.Logic;
using NUnit.Framework;

namespace AnimalChessTests.LogicTests
{
    [TestFixture]
    class BoardTests
    {
        private Board board;

        [SetUp]
        public void SetUpFixture()
        {
            board = new Board();
        }

        [Test]
        public void BoardConstructionTest()
        {
            Assert.AreEqual(CellType.Walkable, board.GetCell(1, 1).Type);
        }
    }
}
