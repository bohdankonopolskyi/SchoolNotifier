using SchoolNotifier;
using NotifierData.Models;
using NotifierData.JSON;

namespace NotifierService.EventTrigger;

public class DailyTriggerService
{
    
    private List<DailyTrigger> _triggers;
    private IJSONRepository<List<Notification>> _notificationRepository;
    public DailyTriggerService(IJSONRepository<List<Notification>> notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<List<Notification>> GetNotificationsAsync()
    {
        return await _notificationRepository.DeserializeAsync();
    }

    public List<Notification> GetNotifications()
    {
        return _notificationRepository.Data;
    }

    public async Task AddNotificationAsync(Notification notification)
    {
        _notificationRepository.Data.Add(notification);
       await _notificationRepository.SerializeAsync();
    }

    public async Task RemoveNotificationAsync(Guid id)
    {
        var notification = _notificationRepository.Data.FirstOrDefault(x => x.Id == id);
        if (notification != null)
            _notificationRepository.Data.Remove(notification);
        
        await _notificationRepository.SerializeAsync();
    }
    public void SubscribeTriggers(Guid id, Action action)
    {
        _triggers = new List<DailyTrigger>();

        List<DateTime>? dates = _notificationRepository.Data?.FirstOrDefault(x => x.Id == id).Schedule;

        if(dates != null)
        foreach (var date in dates)
        {
            TimeOnly time = TimeOnly.FromDateTime(date);

            var trigger = new DailyTrigger(time.Hour, time.Minute, time.Second);
                trigger.NotificationId = id;
            trigger.OnTimeTriggered += () =>
            {
                action();

                Console.WriteLine(
                    $"Event triggered at time: {time.Hour.ToString()}:{time.Minute.ToString()}:{time.Second.ToString()}");
            };
            _triggers.Add(trigger);
        }
    }

    public void UnsubscribeTriggers(Guid id)
    {
        var notification = _notificationRepository.Data?.FirstOrDefault(x => x.Id == id);
        if(notification != null && _triggers != null) 
            foreach (var trigger in _triggers)
            {
                    if (trigger.NotificationId == id)
                    {
                        trigger.OnTimeTriggered -= () =>
                        {
                            Console.WriteLine("Trigger is unsubscribed");
                        };
                        _triggers.Remove(trigger);
                    }
            }

        
    }
}
