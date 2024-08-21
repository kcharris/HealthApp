namespace HealthApp.Server
{
    public class BodyMeasurement
    {
        private static readonly Dictionary<string, decimal> ActivityLevels = new()
        {
            { "sedentary", (decimal)1.2 },
            { "light", (decimal)1.375 },
            { "moderate", (decimal)1.55 },
            { "active", (decimal)1.725 },
            { "very", (decimal)1.9 },
        };

        public DateOnly Date { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public decimal HeightCm { get; set; }
        public decimal WeightKg { get; set; }
        public string? ActivityLevel { get; set; }
        
        /// <summary>
        /// Calculates the Resting Metabolic Rate (RMR) using the Mifflin-St Jeor equation.
        /// If gender is not set it will default to the male calculation.
        /// </summary>
        /// <returns>int</returns>
        public decimal RMR()
        {
            decimal res;
            if (this.Gender == null || this.Gender == "male"){
                res = 10 * this.WeightKg + (decimal)6.25 * this.HeightCm - 5 * this.Age + 5;
            }
            else
            {
                res = 10 * this.WeightKg + (decimal)6.25 * this.HeightCm - 5 * this.Age - 161;
            }
            return res;
        }
        /// <summary>
        /// Calculates the Basal metabolic rate based on the Harris-Benedict equation. It uses the RMR and multiplies this value by and number that corresponds to activity level.
        /// The resulting number is the daily Kilocalorie intake required to maintain current body rate.
        /// </summary>
        /// <returns>decimal</returns>
        public decimal BMR()
        {
            decimal multiplier = ActivityLevels.GetValueOrDefault(this.ActivityLevel);
            decimal RMR = this.RMR();
            return RMR * multiplier;
        }
    }
}
