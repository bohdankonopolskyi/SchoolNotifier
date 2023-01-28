using SchoolNotifier;
using SchoolNotifier.FileReader.JSON;
using SchoolNotifier.Notification;

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

var time = new TimeOnly(17, 30, 0);
JSONSerializer<Notification> jSONSerializer = new JSONSerializer<Notification>(notification);

jSONSerializer.Serialize("notifications.json");

var notif = await jSONSerializer.Deserialize("notifications.json");
Console.WriteLine(notif.ToString());



