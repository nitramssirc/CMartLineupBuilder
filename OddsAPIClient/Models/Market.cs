namespace OddsAPIClient.Models
{
    public class Market
    {
        public MarketType key {  get; set; }

        public DateTime last_update { get; set; }

        public Outcome[] outcomes { get; set; }
    }
}