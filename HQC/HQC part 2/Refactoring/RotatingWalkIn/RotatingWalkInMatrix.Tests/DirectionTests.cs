using NUnit.Framework;

using RotatingWalk;

namespace RotatingWalkInMatrixTests
{
    [TestFixture]
    public class DirectionTests
    {
        [Test]
        public void StartDirectionShouldReturnNewInstanceOfDirection()
        {
            var startDir = Direction.StartDirection;

            Assert.IsInstanceOf<Direction>(startDir);
        }

        [Test]
        public void StartDirectionShouldReturnDirectionWithProperlySetRowProperty()
        {
            var startDir = Direction.StartDirection;

            Assert.AreEqual(1, startDir.X);
        }

        [Test]
        public void StartDirectionShouldReturnDirectionWithProperlySetColProperty()
        {
            var startDir = Direction.StartDirection;

            Assert.AreEqual(1, startDir.Y);
        }

        [TestCase(1, 1, 0)]
        [TestCase(2, 1, -1)]
        [TestCase(3, 0, -1)]
        [TestCase(4, -1, -1)]
        [TestCase(5, -1, 0)]
        [TestCase(6, -1, 1)]
        [TestCase(7, 0, 1)]
        [TestCase(8, 1, 1)]
        [Test]
        public void GetNextDirectionShouldChangeToNextDirectionInOrder(int nextDirCount, int deltaX, int deltaY)
        {
            var startDir = Direction.StartDirection;

            for (int i = 0; i < nextDirCount; i++)
            {
                startDir.GetNextDirection();
            }

            Assert.AreEqual(deltaX, startDir.X);
            Assert.AreEqual(deltaY, startDir.Y);
        }
    }
}
