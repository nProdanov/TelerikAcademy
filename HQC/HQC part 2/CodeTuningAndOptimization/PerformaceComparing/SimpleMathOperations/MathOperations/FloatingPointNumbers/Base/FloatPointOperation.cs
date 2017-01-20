using System;

using MathOperations.MathOperations.Base;
using MathOperations.Types;

namespace MathOperations.MathOperations.FloatingPointNumbers.Base
{
    public class FloatPointOperation : Operation
    {
        protected double advancedStartNum;

        public FloatPointOperation(OperationType operation)
            : base(operation)
        {
        }

        public override void Produce()
        {
            switch (this.operation)
            {
                case OperationType.SquareRoot: this.Sqrt();
                    break;
                case OperationType.NaturalLogarithm: this.Logarithm();
                    break;
                case OperationType.Sinus: this.Sin();
                    break;
                default: base.Produce();
                    break;
            }
        }

        protected void Sqrt()
        {
            double result = this.advancedStartNum;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result = Math.Sqrt(result);
            }
        }

        protected void Logarithm()
        {
            double result = this.advancedStartNum;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result = Math.Log(result);
            }
        }

        protected void Sin()
        {
            double result = this.advancedStartNum;
            for (int i = 0; i < this.executionCounts; i++)
            {
                result = Math.Sin(result);
            }
        }
    }
}
