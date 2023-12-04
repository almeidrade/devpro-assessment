namespace QaAssessment;

public class LoggerAssessment_DAO : LoggerAssessment, ILoggerBase
{
    public LoggerAssessment_DAO(string directory) : base(directory, "Log.txt")
    {
        FilePath = FileDirectory + "/" + FileName;
    }
    public void Log(Guid guid, string Message, LogLevel logLevel, string loggedUser, string dateTime, string date)
    {
        StreamWriter wr;
        using (wr = File.AppendText(FilePath))
            try
            {
                {
                    wr.Write($"\rLog Entry: {guid}");
                    wr.WriteLine($"\n[{logLevel}] user {loggedUser} logged in {dateTime} {date}");
                    wr.WriteLine($"Message: {Message}" + ".");
                    wr.WriteLine("--------------------------------------------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                wr.Close();
            }
    }
}
