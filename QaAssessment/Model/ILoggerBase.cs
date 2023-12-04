namespace QaAssessment;
interface ILoggerBase
{
    void Log(Guid guid, string Message, LogLevel logLevel, string loggedUser, string dateTime, string date);
}
