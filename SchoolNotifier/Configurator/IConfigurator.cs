namespace SchoolNotifier;

public interface IConfigurator
{
    public string FilePath { get; set; }
    public string ReadConfiguration();
    public Task SetConfiguration(string path);
}