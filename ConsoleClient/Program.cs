
using SchoolNotifier;

List<TimeOnly> times = null;

Console.WriteLine("Read file");
IFileReader reader = new ScheduleFileReader();
var lines = reader.ReadFile(@"/Users/bohdankonopolskyi/RiderProjects/SchoolNotifier/ConsoleClient/times.txt");
try
{
    times = reader.GetTimes();
}
catch (ArgumentException e)
{
    Console.WriteLine(e);
   
}
catch (FormatException e)
{
    Console.WriteLine(e);
   
}

if (times is not null)
{
    DailyTriggerClient client = new DailyTriggerClient(times);
    client.SetUpTriggers();
}

Console.ReadKey();
