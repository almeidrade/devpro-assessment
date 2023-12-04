namespace QaAssessment;

public class LoggerAssessment
{
    public LoggerAssessment(string FileDirectory, string FileName)
    {
        this.FileDirectory = FileDirectory;
        this.FileName = FileName;
    }
    public String FileDirectory
    {
        get;
        set;
    }

    public String FileName
    {
        get;
        set;
    }

    public String FilePath
    {
        get;
        set;
    }

}
