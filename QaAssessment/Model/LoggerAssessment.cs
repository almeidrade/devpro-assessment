namespace QaAssessment;

public class LoggerAssessment
{
    public LoggerAssessment(string FileDirectory, string FileName)
    {
        this.FileDirectory = FileDirectory;
        this.FileName = FileName;
    }
    public string FileDirectory
    {
        get;
        set;
    }

    public string FileName
    {
        get;
        set;
    }

    public string FilePath
    {
        get;
        set;
    }

}
