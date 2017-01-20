namespace Computers.Common.Contracts
{
    public interface IRam
    {
        int LoadValue();

        void SaveValue(int newValue);
    }
}