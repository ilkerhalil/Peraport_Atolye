namespace Common.Logging
{
    public interface ILoggerFactory
    {
        LoggerWriter CreateLogWriter();
    }
}