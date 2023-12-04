namespace TestQaAssessment;
using QaAssessment;
public class LoggerAssessmentTests
{
    SessionInfo loggedUser;
    Guid guid;
    LogLevel logLevel;
    string directory;
    LoggerAssessment_DAO logger;
    string dateTime;
    string date;
    List<string> lines;
    [SetUp]
    public void Setup()
    {
        loggedUser = new SessionInfo("clandrade", "00001");
        guid = Guid.NewGuid();
        directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
        logger = new LoggerAssessment_DAO(directory);
        dateTime = DateTime.Now.ToLongTimeString();
        date = DateTime.Now.ToLongDateString();
        lines = new List<string>();
    }

    [Test]
    public void TestLoggerLevel_INFO()
    {
        logLevel = LogLevel.INFO;
        logger.Log(guid, "user accessed the system session info", logLevel, loggedUser.Name, dateTime, date);
        
        lines = File.ReadAllLines(directory + "/" + "Log.txt").ToList();
        
        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].StartsWith("Log Entry") && lines[i].Contains(guid.ToString()))
            {
                Assert.True(lines[i + 1].Contains("INFO"));
            }
        }
    }

    [Test]
    public void TestLoggerLevel_CRITICAL()
    {
        logLevel = LogLevel.CRITICAL;
        logger.Log(guid, "user accessed the system session info", logLevel, loggedUser.Name, dateTime, date);
        
        lines = File.ReadAllLines(directory + "/" + "Log.txt").ToList();
        
        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].StartsWith("Log Entry") && lines[i].Contains(guid.ToString()))
            {
                Assert.True(lines[i + 1].Contains("CRITICAL"));
            }
        }
    }
}