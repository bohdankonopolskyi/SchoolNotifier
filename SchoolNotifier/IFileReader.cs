namespace SchoolNotifier;

public interface IFileReader
{
    public string[] ReadFile(string filepath);
    public List<TimeOnly> GetTimes();
}