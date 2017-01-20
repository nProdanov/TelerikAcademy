namespace Computers.Common.Contracts
{
    public interface IMotherboard
    {
        int LoadRamValue();

        void SaveRamValue(int value);

        void DrawOnVideoCard(string data);

        void SquareNumber();

        void GetRandomNumber(int minNumber, int maxNumber);
    }
}
