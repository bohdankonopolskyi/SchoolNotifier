namespace SchoolNotifier;

public class ScheduleFileReader : IFileReader
{
    private string[] _lines;
    private List<TimeOnly> _times;

    public string[] Schedule
    {
        get => _lines;
    }

    public List<TimeOnly> Times
    {
        get => _times;
    }

    public string[] ReadFile(string filepath)
    {
        _lines = File.ReadAllLines(filepath);
        return _lines;
    }

    public List<TimeOnly> GetTimes()
    {
        _times = new List<TimeOnly>();

        foreach (var line in _lines)
        {
            var splitted = line.Split(':');
            var time = this.ParseTimeOnly(splitted);
            _times.Add(time);
        }

        return _times;
    }

    public TimeOnly ParseTimeOnly(string[] splited)
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
            return new TimeOnly(hours, minutes, seconds);
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
}