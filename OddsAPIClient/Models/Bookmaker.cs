namespace OddsAPIClient.Models
{
    public class Bookmaker
    {
        public string key {  get; set; }

        public string title { get; set; }

        public DateTime last_update { get; set; }

        public Market[] markets { get; set; }
    }
}