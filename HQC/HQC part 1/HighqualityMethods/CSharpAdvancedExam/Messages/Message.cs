using Messages.Utils;

namespace Messages
{
    internal class Message
    {
        private string translatedMessage;

        internal Message(string[] parameters)
        {
            this.translatedMessage = this.TranslateMessage(parameters);
        }

        internal string TranslatedMessage
        {
            get
            {
                return this.translatedMessage;
            }
        }

        private string TranslateMessage(string[] parameters)
        {
            var firstNumber = Converter.ConvertGreatNumbertToNumber(parameters[0]);
            var secondNumber = Converter.ConvertGreatNumbertToNumber(parameters[2]);

            var resultNumber = Calculator.Calculate(firstNumber, secondNumber, parameters[1]);

            return Converter.ConvertNumberToGreatNumber(resultNumber);
        }
    }
}