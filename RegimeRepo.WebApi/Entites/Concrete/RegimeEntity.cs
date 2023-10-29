using RegimeRepo.WebApi.Entites.Abstract;

namespace RegimeRepo.WebApi.Entites.Concrete
{
    public class RegimeEntity : BaseEntity<Guid>
    {
        public bool Coffee { get; set; }
        public string LaunchSport { get; set; }
        public DateTime? PlannedDate { get; set; }
        public string? BreakFastTime { get; set; }
        public string? DinnerTime { get; set; }
        public string Fruits { get; set; }
        public string EveningSport { get; set; }
        public bool DrinkWater { get; set; }
        public int StepCount { get; set; }
        public decimal WeightDifference { get; set; }
        public string? Fails { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
