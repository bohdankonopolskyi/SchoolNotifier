namespace SchoolNotifier;

public interface IFileManager
{
    public string[] ReadFile(string filepath);
    public List<DateTime> GetTimes();
    public void CopyFile(string source, string destination, string defaultFileName);
}