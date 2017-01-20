using MathOperations.MathOperations.Base;
using MathOperations.MathOperations.FloatingPointNumbers;
using MathOperations.MathOperations.IntegerNumbers;
using MathOperations.Types;

namespace MathOperations
{
    public class OperationFactory
    {
        public Operation CreateOperation(OperationType operation, NumberType typeOfNumber)
        {
            switch (typeOfNumber)
            {
                case NumberType.Decimal: return new DecimalOperation(operation);
                case NumberType.Double: return new DoubleOperation(operation);
                case NumberType.Float: return new FloatingOperation(operation);
                case NumberType.Integer: return new IntegerOperation(operation);
                default: return new LongOperation(operation);
            }
        }
    }
}
