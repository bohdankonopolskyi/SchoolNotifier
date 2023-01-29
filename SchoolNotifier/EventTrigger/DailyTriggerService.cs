using SchoolNotifier;
using NotifierData.Models;

namespace NotifierService.EventTrigger;

public class DailyTriggerService
{
    private List<DateTime> _dates;
    private List<DailyTrigger> _triggers;

    public DailyTriggerService(Notification notification)
    {
        _dates = notification.Schedule;
    }

    public void SubscribeTriggers(Action action)
    {
        _triggers = new List<DailyTrigger>();

        foreach (var date in _dates)
        {
            TimeOnly time = TimeOnly.FromDateTime(date);

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
        if (_triggers != null)
            foreach (var trigger in _triggers)
            {
                trigger.OnTimeTriggered -= () =>
                {
                    Console.WriteLine("Trigger is unsubscribed");
                };
                _triggers.Remove(trigger);
            }
    }
}