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
    string lastRecordId;
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
        lines = new List<string>(logger.readsTheLogFile(directory, "Log.txt"));
        lastRecordId = lines.ElementAt(lines.Count-4);
    }

    [Test]
    public void TestLastRecordPresenceInLastPosition()
    {
        bool lastLogStillPresent = false;
        bool newLogRightPosition = false;
        bool newLogInTheLastPosition = false;

        logLevel = LogLevel.INFO;
        logger.Log(guid, "user accessed the system session - INFO", logLevel, loggedUser.Name, dateTime, date);
        string newRecordID = guid.ToString();

        lines = new List<string>(logger.readsTheLogFile(directory, "Log.txt"));

        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].StartsWith("Log Entry") && lines[i].Contains(lastRecordId))
            {
                lastLogStillPresent = true;
                
                //if the 5th position below the `lastRecordId` is equals the `newRecordID`, it means that the record is correspondingly in the right position of the
                //log file (right after the `lastRecordId`)
                if (lines[i+5].Replace("Log Entry: ","") == newRecordID)
                {
                    newLogRightPosition = true;

                    //if the 10th position below the `lastRecordId` line is null, it means that the record is correspondingly in the last position of the log file, once 
                    //the return of the try block is going to be an exception (due to be null), otherwise it`s going to return the `Log Entry` of the next record present
                    try 
                    {
                        if (lines[i + 10] != null) 
                        {
                           Assert.Fail("New log has been inserted right bellow the last record accordingly in the log file, but it was not the last one :()"); 
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        newLogInTheLastPosition = true; 
                    }
                }
                else
                {
                    Assert.Fail("New log was not inserted right after the last record or it's not present");
                }
            }
        }
        Assert.True(lastLogStillPresent);
        Assert.True(newLogRightPosition);
        Assert.True(newLogInTheLastPosition);
    }

    [Test]
    public void TestLoggerLevel_INFO()
    {
        logLevel = LogLevel.INFO;
        logger.Log(guid, "user accessed the system session - INFO", logLevel, loggedUser.Name, dateTime, date);
        
        lines = logger.readsTheLogFile(directory, "Log.txt");
        
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
        logger.Log(guid, "user accessed the system session - CRITICAL", logLevel, loggedUser.Name, dateTime, date);
        
        lines = logger.readsTheLogFile(directory, "Log.txt");
        
        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].StartsWith("Log Entry") && lines[i].Contains(guid.ToString()))
            {
                Assert.True(lines[i + 1].Contains("CRITICAL"));
            }
        }
    }

    [Test]
    public void TestLoggerLevel_DATE_INFO()
    {
        logLevel = LogLevel.TRACE;
        logger.Log(guid, "asserts that the infos related to the date is being stored to the log file - TRACE", logLevel, loggedUser.Name, dateTime, date);

        lines = logger.readsTheLogFile(directory, "Log.txt");

        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].StartsWith("Log Entry") && lines[i].Contains(guid.ToString()))
            {
                Assert.True(lines[i + 1].Contains(dateTime));
                Assert.True(lines[i + 1].Contains(date));
                Assert.True(lines[i + 1].Contains("TRACE"));
            }
        }
    }

    [Test]
    public void TestLoggerLevel_LogMessage()
    {
        logLevel = LogLevel.INFO;
        logger.Log(guid, "asserts that the log message is being stored to the log file", logLevel, loggedUser.Name, dateTime, date);

        lines = logger.readsTheLogFile(directory, "Log.txt");

        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].StartsWith("Log Entry") && lines[i].Contains(guid.ToString()))
            {
                Assert.True(lines[i + 2].Contains("Message") && lines[i + 2].Contains("."));
            }
        }
    }
}