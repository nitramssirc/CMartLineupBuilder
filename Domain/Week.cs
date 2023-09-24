namespace Domain
{
    public class Week
    {
        public int ID { get; set; }

        public int WeekNumber { get; set; }

        public DateTime Date { get; set; }

        public Week(int weekNumber, DateTime date)
        {
            WeekNumber = weekNumber;
            Date = date;
        }
    }
}