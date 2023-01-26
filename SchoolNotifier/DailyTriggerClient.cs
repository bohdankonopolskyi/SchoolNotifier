namespace SchoolNotifier;

public class DailyTriggerClient
{
    private IEnumerable<TimeOnly> _times;
    private List<DailyTrigger> _triggers;

    public DailyTriggerClient(IEnumerable<TimeOnly> times)
    {
        _times = times;
    }

    public DailyTriggerClient(TimeOnly time)
    {
        _times = new[] { time };
    }

    public void SetUpTriggers()
    {
        _triggers = new List<DailyTrigger>();

        foreach (var time in _times)
        {
            var trigger = new DailyTrigger(time.Hour, time.Minute, time.Second);
            trigger.OnTimeTriggered += () =>
            {
                Console.WriteLine($"Event triggered at time: {time.Hour.ToString()}:{time.Minute.ToString()}:{time.Second.ToString()}");
            };
            _triggers.Add(trigger);
        }
    }
}