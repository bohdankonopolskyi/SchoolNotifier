using SchoolNotifier;
using SchoolNotifier.FileReader.JSON;
using SchoolNotifier.EventNotifications;

Console.WriteLine("Yello, World!");

//List<Notification> notifications = new List<Notification>()
//{
//    new Notification(){Name = "Alarm", AudioFilePath = Environment.CurrentDirectory,
//        Schedule = new List<TimeOnly>{
//    new TimeOnly(15, 30, 0),
//        new TimeOnly(15, 35, 0),
//        new TimeOnly(15, 39, 0)} },

//    new Notification(){Name = "Gimn", AudioFilePath = Environment.CurrentDirectory,
//        Schedule = new List<TimeOnly>{
//    new TimeOnly(17, 30, 0),
//        new TimeOnly(17, 35, 0),
//        new TimeOnly(17, 39, 0)} }
//}
//    ;

//var notification = new Notification()
//{
//    Name = "Gimn",
//    AudioFilePath = Environment.CurrentDirectory,
//    Schedule = new List<TimeOnly>{
//    new TimeOnly(17, 30, 0),
//        new TimeOnly(17, 35, 0),
//        new TimeOnly(17, 39, 0)}
//};
ScheduleFileReader reader = new ScheduleFileReader();

reader.ReadFile(@"C:\Users\kadde\source\repos\SchoolNotifier\ConsoleClient\times.txt");
var times = reader.GetTimes();
var notification = new Notification("Gimn", Environment.CurrentDirectory, times);

List<Notification> notifications = new List<Notification>()
{
    new Notification("Gimn", Environment.CurrentDirectory, times),
    new Notification("Gimn", Environment.CurrentDirectory, times),
    new Notification("Gimn", Environment.CurrentDirectory, times),
    new Notification("Gimn", Environment.CurrentDirectory, times),
    new Notification("Gimn", Environment.CurrentDirectory, times)
};

var time = new TimeOnly(17, 30, 0);
JSONSerializer<List<Notification>> jSONSerializer = new JSONSerializer<List<Notification>>(notifications);


jSONSerializer.Serialize("notifications.json");


var notif = await jSONSerializer.Deserialize("notifications.json");

foreach (var Note in notif)
{ Console.WriteLine(Note.ToString()); }



