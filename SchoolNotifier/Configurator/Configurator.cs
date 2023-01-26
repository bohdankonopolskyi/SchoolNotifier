namespace SchoolNotifier;

public class Configurator: IConfigurator
{
    private string _filePath;

    public string FilePath
    {
        get => _filePath;
        set => _filePath = value;
    }

    public string ReadConfiguration()
    {
        return File.ReadAllText(_filePath);
    }

    public async Task SetConfiguration(string path)
    {

        await File.WriteAllTextAsync(_filePath, path);
    }
}