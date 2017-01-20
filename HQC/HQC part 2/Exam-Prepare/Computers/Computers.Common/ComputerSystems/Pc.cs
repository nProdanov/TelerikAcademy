using Computers.Common.Contracts;

namespace Computers.Common.ComputerSystems
{
    public class Pc : ComputerSystem
    {
        private const int MinGameNumber = 1;
        private const int MaxGameNumber = 10;

        private const string WinGameMessage = "You win!";
        private const string NotWinGameFormatMessage = "You didn't guess the number {0}.";

        public Pc(ICpu cpu, IRam ram, IVideoCard videoCard, IStorage storage)
            : base(cpu, ram, videoCard, storage)
        {
        }

        public void Play(int guessNumber)
        {
            int minNumber = MinGameNumber;
            int maxNumber = MaxGameNumber;
            this.motherboard.GetRandomNumber(minNumber, maxNumber);

            var number = this.motherboard.LoadRamValue();
            if (number != guessNumber)
            {
                this.motherboard.DrawOnVideoCard(string.Format(NotWinGameFormatMessage, number));
            }
            else
            {
                this.motherboard.DrawOnVideoCard(WinGameMessage);
            }
        }
    }
}
