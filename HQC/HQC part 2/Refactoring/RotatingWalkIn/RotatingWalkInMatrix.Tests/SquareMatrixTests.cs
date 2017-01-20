using NUnit.Framework;

using RotatingWalk;
using System;
using System.Text;

namespace RotatingWalkInMatrixTests
{
    [TestFixture]
    public class SquareMatrixTests
    {
        [TestCase(1)]
        [TestCase(50)]
        [TestCase(100)]
        [Test]
        public void SquareMatrixConstructorShouldNotThrowIfValidSizePassed(int validMatrixSize)
        {
            Assert.DoesNotThrow(() => new SquareMatrix(validMatrixSize));
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(101)]
        public void SquareMatrixConstructorShouldThrowIfNotValidSizePassed(int invalidMatrixSize)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SquareMatrix(invalidMatrixSize));
        }

        [Test]
        public void MatrixShouldReturnCopyOfSquareMatrix()
        {
            int validMatrixSize = 3;
            var matrix = new SquareMatrix(validMatrixSize);

            var clonedMatrix = matrix.Matrix;
            clonedMatrix[0, 0] = 10;

            Assert.AreNotEqual(clonedMatrix[0, 0], matrix.Matrix[0, 0]);
        }

        [TestCase(-1, 1)]
        [TestCase(4,4)]
        [TestCase(2,-1)]
        [TestCase(3, 1)]
        [Test]
        public void SetValueShouldThrowArgumentExceptionIfPassedPositionNotInRange(int rowPos, int colPos)
        {
            int validMatrixSize = 3;
            var testMatrix = new SquareMatrix(validMatrixSize);

            int validCellValue = 10;

            Assert.Throws<ArgumentException>(() => testMatrix.SetValue(rowPos, colPos, validCellValue));
        }

        [Test]
        public void SetValueShouldThrowArgumentExceptionIfPassedPositionIsNotEmpty()
        {
            int validMatrixSize = 3;
            var testMatrix = new SquareMatrix(validMatrixSize);

            int validCellValue = 10;
            int validRowPos = 1;
            int validColPos = 1;
            testMatrix.SetValue(validRowPos, validColPos, validCellValue);

            Assert.Throws<ArgumentException>(() => testMatrix.SetValue(validRowPos, validColPos, 1));
        }

        [Test]
        public void SetValueShoudSetProperlyValueOfPassedValidEmptyPosition()
        {
            int validMatrixSize = 3;
            var testMatrix = new SquareMatrix(validMatrixSize);

            int validCellValue = 10;
            int validRowPos = 1;
            int validColPos = 1;
            testMatrix.SetValue(validRowPos, validColPos, validCellValue);

            Assert.AreEqual(validCellValue, testMatrix.Matrix[validRowPos, validColPos]);
        }

        [Test]
        public void GetFirstEmptyPositionShouldReturnFirstEmptyCellInMatrix()
        {
            int validMatrixSize = 3;
            var testMatrix = new SquareMatrix(validMatrixSize);

            int validCellValue = 10;
            testMatrix.SetValue(0, 0, validCellValue);
            testMatrix.SetValue(0, 1, validCellValue);
            testMatrix.SetValue(0, 2, validCellValue);

            var expectedResult = new int[] { 1, 0 };

            Assert.AreEqual(expectedResult, testMatrix.GetFirstEmptyPosition());
        }

        [Test]
        public void GetFirstEmptyPositionShouldReturnNullIfMatrixIsFilled()
        {
            int validMatrixSize = 3;
            var testMatrix = new SquareMatrix(validMatrixSize);

            int validCellValue = 10;
            for (int row = 0; row < validMatrixSize; row++)
            {
                for (int col = 0; col < validMatrixSize; col++)
                {
                    testMatrix.SetValue(row, col, validCellValue);
                }
            }

            Assert.AreEqual(null, testMatrix.GetFirstEmptyPosition());
        }

        [Test]
        public void ToStrintShouldReturnProperStringRepresentingMatrixValues()
        {
            int validMatrixSize = 3;
            var testMatrix = new SquareMatrix(validMatrixSize);

            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("  0  0  0");
            expectedResult.AppendLine("  0  0  0");
            expectedResult.AppendLine("  0  0  0");

            Assert.AreEqual(expectedResult.ToString(), testMatrix.ToString());
        }
    }
}
