using MathOperations.MathOperations.FloatingPointNumbers.Base;
using MathOperations.Types;

namespace MathOperations.MathOperations.FloatingPointNumbers
{
    public class FloatingOperation : FloatPointOperation
    {
        private const float StartNum = 2;
        private const float ResultNum = 1;

        public FloatingOperation(OperationType operation)
            : base(operation)
        {
            this.advancedStartNum = (double)FloatingOperation.StartNum;
        }

        protected override void Addition()
        {
            float result = FloatingOperation.ResultNum;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result += FloatingOperation.StartNum;
            }
        }

        protected override void Substraction()
        {
            float result = float.MaxValue;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result -= FloatingOperation.StartNum;
            }
        }

        protected override void Multiplication()
        {
            float result = FloatingOperation.ResultNum;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result *= FloatingOperation.StartNum;
            }
        }

        protected override void Devision()
        {
            float result = float.MaxValue;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result /= FloatingOperation.StartNum;
            }
        }
    }
}
