namespace DbFirst.DataImporter.Logger
{
    public interface ILogger
    {
        void LogLine(string output);

        void Log(string output);
    }
}
