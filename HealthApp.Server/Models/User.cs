namespace HealthApp.Server.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public decimal HeightCm { get; set; }
    }
}
