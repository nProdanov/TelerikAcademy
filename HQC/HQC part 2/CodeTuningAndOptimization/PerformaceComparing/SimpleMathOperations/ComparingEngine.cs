using System.Diagnostics;
using System.Text;

using MathOperations.MathOperations.Base;
using MathOperations.Types;

namespace MathOperations
{
    public class ComparingEngine
    {
        private const string Separator = "***************************************";
        private OperationFactory operationsFactory;
        private Stopwatch stopwatch;

        public ComparingEngine(OperationFactory factory)
        {
            this.operationsFactory = factory;
            this.stopwatch = new Stopwatch();
        }

        public string CompareReport()
        {
            var report = new StringBuilder();
            report.Append(this.SimpleOperationReport(OperationType.Addition));
            report.Append(this.SimpleOperationReport(OperationType.Subtraction));
            report.Append(this.SimpleOperationReport(OperationType.Multiplication));
            report.Append(this.SimpleOperationReport(OperationType.Division));
            report.AppendLine(Separator);
            report.Append(this.AdvancedOperationReport(OperationType.SquareRoot));
            report.Append(this.AdvancedOperationReport(OperationType.NaturalLogarithm));
            report.Append(this.AdvancedOperationReport(OperationType.Sinus));
            return report.ToString();
        }

        private string SimpleOperationReport(OperationType operation)
        {
            var integerOperation = this.operationsFactory.CreateOperation(operation, NumberType.Integer);
            var longOperation = this.operationsFactory.CreateOperation(operation, NumberType.Long);
            var floatOperation = this.operationsFactory.CreateOperation(operation, NumberType.Float);
            var doubleOperation = this.operationsFactory.CreateOperation(operation, NumberType.Double);
            var decimalOperation = this.operationsFactory.CreateOperation(operation, NumberType.Decimal);

            var result = new StringBuilder();
            result.AppendLine(string.Format("{0}: ", operation.ToString()));
            result.AppendFormat("{0,-10}->{1}", NumberType.Integer.ToString(), this.SingleOperationReport(integerOperation)).AppendLine();
            result.AppendFormat("{0,-10}->{1}", NumberType.Long.ToString(), this.SingleOperationReport(longOperation)).AppendLine();
            result.AppendFormat("{0,-10}->{1}", NumberType.Float.ToString(), this.SingleOperationReport(floatOperation)).AppendLine();
            result.AppendFormat("{0,-10}->{1}", NumberType.Double.ToString(), this.SingleOperationReport(doubleOperation)).AppendLine();
            result.AppendFormat("{0,-10}->{1}", NumberType.Decimal.ToString(), this.SingleOperationReport(decimalOperation)).AppendLine();
            result.AppendLine(Separator);

            return result.ToString();
        }

        private string AdvancedOperationReport(OperationType operation)
        {
            var floatOperation = this.operationsFactory.CreateOperation(operation, NumberType.Float);
            var doubleOperation = this.operationsFactory.CreateOperation(operation, NumberType.Double);
            var decimalOperation = this.operationsFactory.CreateOperation(operation, NumberType.Decimal);

            var result = new StringBuilder();
            result.AppendLine(string.Format("{0}: ", operation.ToString()));
            result.AppendFormat("{0,-10}->{1}", NumberType.Float.ToString(), this.SingleOperationReport(floatOperation)).AppendLine();
            result.AppendFormat("{0,-10}->{1}", NumberType.Double.ToString(), this.SingleOperationReport(doubleOperation)).AppendLine();
            result.AppendFormat("{0,-10}->{1}", NumberType.Decimal.ToString(), this.SingleOperationReport(decimalOperation)).AppendLine();
            result.AppendLine(Separator);

            return result.ToString();
        }

        private string SingleOperationReport(Operation operation)
        {
            this.stopwatch.Start();
            operation.Produce();
            this.stopwatch.Stop();

            string stopwatchResult = this.stopwatch.Elapsed.TotalSeconds.ToString();
            this.stopwatch.Reset();

            return stopwatchResult;
        }
    }
}
