namespace Computers.Common.Contracts
{
    public interface ICpu
    {
        int GetRandoNumber(int minNumber, int maxNumber);

        string SquareNumber(int number);
    }
}