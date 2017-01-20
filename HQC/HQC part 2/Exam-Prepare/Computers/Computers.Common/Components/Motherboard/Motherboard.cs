using Computers.Common.Contracts;

namespace Computers.Common.Components.Motherboard
{
    public class Motherboard : IMotherboard
    {
        private IVideoCard videoCard;
        private IRam ram;
        private ICpu cpu;

        public Motherboard(ICpu cpu, IVideoCard videoCard, IRam ram)
        {
            this.cpu = cpu;
            this.videoCard = videoCard;
            this.ram = ram;
        }

        public void DrawOnVideoCard(string data)
        {
            this.videoCard.Draw(data);
        }

        public int LoadRamValue()
        {
            return this.ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.ram.SaveValue(value);
        }

        public void SquareNumber()
        {
            int number = this.LoadRamValue();

            var result = this.cpu.SquareNumber(number);

            this.DrawOnVideoCard(result);
        }

        public void GetRandomNumber(int minNumber, int maxNumber)
        {
            int randomNumber = this.cpu.GetRandoNumber(minNumber, maxNumber);

            this.SaveRamValue(randomNumber);
        }
    }
}
