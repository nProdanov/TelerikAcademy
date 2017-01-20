namespace Cosmetics.Contracts
{
    public interface IInputOutputProvider
    {
        string ReadLine();

        void WriteLine(string output);
    }
}
