using MathOperations.Types;

namespace MathOperations.MathOperations.Base
{
    public class Operation
    {
        protected OperationType operation;
        protected int executionCounts;

        private const int ExecutionCounts = 100000;

        public Operation(OperationType operation)
        {
            this.operation = operation;
            this.executionCounts = Operation.ExecutionCounts;
        }

        public virtual void Produce()
        {
            switch (this.operation)
            {
                case OperationType.Addition: this.Addition();
                    break;
                case OperationType.Subtraction: this.Substraction();
                    break;
                case OperationType.Multiplication: this.Multiplication();
                    break;
                case OperationType.Division: this.Devision();
                    break;
            }
        }

        protected virtual void Addition()
        {
        }

        protected virtual void Substraction()
        {
        }

        protected virtual void Multiplication()
        {
        }

        protected virtual void Devision()
        {
        }
    }
}
