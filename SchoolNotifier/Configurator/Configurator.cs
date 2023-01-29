using NotifierData.JSON;
using NotifierData.Models;
using NotifierService.EventTrigger;
using System.Media;

namespace SchoolNotifier;

public class Configurator : IConfigurator
{
    private DailyTriggerService _setuper;
  
    private IJSONRepository<List<Notification>> _jSONRepository;
    public Configurator(DailyTriggerService service,  IJSONRepository<List<Notification>> jSONRepository)
    {
        _setuper = service;
        
        _jSONRepository = jSONRepository;
    }


    public async Task SetConfiguration()
    {
       foreach(var notification in _jSONRepository.Data)
        {
            var player = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, notification.AudioFilePath));
            Action action = () => player.Play();

            _setuper.SubscribeTriggers(notification.Id, action);
        }
        
    }
}