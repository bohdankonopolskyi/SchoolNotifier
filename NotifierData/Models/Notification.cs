namespace NotifierData.Models
{
    public class Notification
    {
        public Notification(string name, string audioFilePath, List<DateTime> schedule)
        {
            Name = name;
            AudioFilePath = audioFilePath;
            Schedule = schedule;
        }

        public string Name { get; set; }
        public string AudioFilePath { get; set; }
        public List<DateTime> Schedule { get; set; }

        public override string ToString()
        {
            var dates = string.Empty;
            foreach (var date in Schedule)
            {
                dates += date.ToString() + " \n";
            }
            return $"{Name} {AudioFilePath} \n {dates}";
        }
    }
}
