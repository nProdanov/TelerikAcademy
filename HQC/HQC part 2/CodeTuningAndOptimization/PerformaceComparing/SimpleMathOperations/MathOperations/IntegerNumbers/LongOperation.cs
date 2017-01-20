using MathOperations.MathOperations.Base;
using MathOperations.Types;

namespace MathOperations.MathOperations.IntegerNumbers
{
    public class LongOperation : Operation
    {
        private const long StartNum = 2;
        private const long ResultNum = 1;

        public LongOperation(OperationType operation) 
            : base(operation)
        {
        }

        protected override void Addition()
        {
            long result = LongOperation.ResultNum;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result += LongOperation.StartNum;
            }
        }

        protected override void Substraction()
        {
            long result = long.MaxValue;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result -= LongOperation.StartNum;
            }
        }

        protected override void Multiplication()
        {
            long result = LongOperation.ResultNum;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result *= LongOperation.StartNum;
            }
        }

        protected override void Devision()
        {
            long result = long.MaxValue;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result /= LongOperation.StartNum;
            }
        }
    }
}
