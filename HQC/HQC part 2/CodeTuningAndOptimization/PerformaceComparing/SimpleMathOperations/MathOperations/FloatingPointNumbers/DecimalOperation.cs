using MathOperations.MathOperations.FloatingPointNumbers.Base;
using MathOperations.Types;

namespace MathOperations.MathOperations.FloatingPointNumbers
{
    public class DecimalOperation : FloatPointOperation
    {
        private const decimal StartNum = 1.0005m;
        private const decimal ResultNum = 1;

        public DecimalOperation(OperationType operation)
            : base(operation)
        {
            this.advancedStartNum = (double)DecimalOperation.StartNum;
        }

        protected override void Addition()
        {
            decimal result = DecimalOperation.ResultNum;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result += DecimalOperation.StartNum;
            }
        }

        protected override void Substraction()
        {
            decimal result = decimal.MaxValue;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result -= DecimalOperation.StartNum;
            }
        }

        protected override void Multiplication()
        {
            decimal result = DecimalOperation.ResultNum;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result *= DecimalOperation.StartNum;
            }
        }

        protected override void Devision()
        {
            decimal result = decimal.MaxValue;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result /= DecimalOperation.StartNum;
            }
        }
    }
}
