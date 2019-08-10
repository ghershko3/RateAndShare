namespace RateAndShare.Models
{
    public class Rate
    {
        public int ID { get; set; }
        public int NumOfStars { get; set; }

        public virtual Song Song { get; set; }
    }
}