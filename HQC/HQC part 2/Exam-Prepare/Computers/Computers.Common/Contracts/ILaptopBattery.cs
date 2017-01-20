namespace Computers.Common.Contracts
{
    public interface ILaptopBattery
    {
        int Percentage { get; set; }

        void Charge(int deltaPercentage);
    }
}