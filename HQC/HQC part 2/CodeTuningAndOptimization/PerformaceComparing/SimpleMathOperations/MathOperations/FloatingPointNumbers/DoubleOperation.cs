using MathOperations.MathOperations.FloatingPointNumbers.Base;
using MathOperations.Types;

namespace MathOperations.MathOperations.FloatingPointNumbers
{
    public class DoubleOperation : FloatPointOperation
    {
        private const double StartNum = 2;
        private const double ResultNum = 1;

        public DoubleOperation(OperationType operation)
            : base(operation)
        {
            this.advancedStartNum = DoubleOperation.StartNum;
        }

        protected override void Addition()
        {
            double result = DoubleOperation.ResultNum;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result += DoubleOperation.StartNum;
            }
        }

        protected override void Substraction()
        {
            double result = double.MaxValue;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result -= DoubleOperation.StartNum;
            }
        }

        protected override void Multiplication()
        {
            double result = DoubleOperation.ResultNum;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result *= DoubleOperation.StartNum;
            }
        }

        protected override void Devision()
        {
            double result = double.MaxValue;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result /= DoubleOperation.StartNum;
            }
        }
    }
}
