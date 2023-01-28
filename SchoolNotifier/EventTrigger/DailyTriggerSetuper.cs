namespace SchoolNotifier;

public class DailyTriggerSetuper
{
    private IEnumerable<TimeOnly> _intervals;
    private List<DailyTrigger> _triggers;
    private IFileReader _reader;
    public DailyTriggerSetuper(IFileReader reader)
    {
        _reader = reader;
    }
    
    public void SubscribeTriggers(Action action)
    {
        _triggers = new List<DailyTrigger>();
        
        foreach (var time in _intervals)
        {
            var trigger = new DailyTrigger(time.Hour, time.Minute, time.Second);
            trigger.OnTimeTriggered += () =>
            {
                action();

                Console.WriteLine(
                    $"Event triggered at time: {time.Hour.ToString()}:{time.Minute.ToString()}:{time.Second.ToString()}");
            };
            _triggers.Add(trigger);
        }
    }

    public void UnsubscribeTriggers()
    {
        if(_triggers != null)
        foreach (var trigger in _triggers)
        {
            trigger.OnTimeTriggered -= () =>
            {
                Console.WriteLine("Trigger is unsubscribed");
            };
            _triggers.Remove(trigger);
        }
    }

    public void SetUpIntervals(string filePath)
    {
       _reader.ReadFile(filePath);
       _intervals = _reader.GetTimes();
    }
}