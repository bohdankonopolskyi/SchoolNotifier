namespace SchoolNotifier;

public class ScheduleFileManager : IFileManager
{
    private string[] _lines;
    private List<DateTime> _times;

    public string[] ReadFile(string filepath)
    {
        _lines = File.ReadAllLines(filepath);
        return _lines;
    }

    public List<DateTime> GetTimes()
    {
        _times = new List<DateTime>();

        foreach (var line in _lines)
        {
            var splitted = line.Split(':');
            var time = this.ParseTimeOnly(splitted);
            _times.Add(time);
        }

        return _times;
    }

    public DateTime ParseTimeOnly(string[] splited)
    {
        int hours = 0, minutes = 0, seconds = 0;
        try
        {
            hours = Int32.Parse(splited[0]);
            // if (hours < 0 || hours > 23)
            //     throw new ArgumentException("Hours must be in range 0..23");
            
            minutes = Int32.Parse(splited[1]);
            // if (minutes < 0 || minutes > 59)
            //     throw new ArgumentException("Minutes must be in range 0..59");

            if (splited.Skip(2).FirstOrDefault() != null)
            {
                seconds = Int32.Parse(splited[2]);
            }

            // if (seconds < 0 || seconds > 59)
            //     throw new ArgumentException("Seconds must be in range 0..59");

            Console.WriteLine($"Time: {hours}:{minutes}:{seconds}");
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, minutes, seconds);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            throw new FormatException(e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            throw new ArgumentException(e.Message);
        }
    }

    public void CopyFile(string source, string destination, string defaultFileName)
    {
        if (string.IsNullOrEmpty(source))
            return;
        
        var destinationFile = string.IsNullOrEmpty(Path.GetFileName(destination)) ? Path.GetFileName(destination) : defaultFileName;
        destination = Path.Combine(Environment.CurrentDirectory, destinationFile);

        File.Copy(source, destination, overwrite: true);
    }

    
}