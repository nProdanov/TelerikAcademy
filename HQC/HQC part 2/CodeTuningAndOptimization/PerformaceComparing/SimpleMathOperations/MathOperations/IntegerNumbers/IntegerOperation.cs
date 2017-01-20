using MathOperations.MathOperations.Base;
using MathOperations.Types;

namespace MathOperations.MathOperations.IntegerNumbers
{
    public class IntegerOperation : Operation
    {
        private const int StartNum = 2;
        private const int ResultNum = 1;

        public IntegerOperation(OperationType operation)
            : base(operation)
        {
        }

        protected override void Addition()
        {
            int result = IntegerOperation.ResultNum;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result += IntegerOperation.StartNum;
            }
        }

        protected override void Substraction()
        {
            int result = int.MaxValue;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result -= IntegerOperation.StartNum;
            }
        }

        protected override void Multiplication()
        {
            int result = IntegerOperation.ResultNum;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result *= IntegerOperation.StartNum;
            }
        }

        protected override void Devision()
        {
            int result = int.MaxValue;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result /= IntegerOperation.StartNum;
            }
        }
    }
}
