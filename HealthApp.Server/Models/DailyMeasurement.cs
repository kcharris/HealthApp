namespace HealthApp.Server.Models
{
    public class DailyMeasurement
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateOnly Date { get; set; }
        public decimal WeightKg { get; set; }
        public int CaloriesTaken { get; set; }
        public string? ActivityLevel { get; set; }
    }
}
