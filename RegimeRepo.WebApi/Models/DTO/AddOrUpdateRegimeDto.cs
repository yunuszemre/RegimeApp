using System.ComponentModel.DataAnnotations;

namespace RegimeRepo.WebApi.Models.DTO
{
    public class AddOrUpdateRegimeDto
    {
        public Guid? Id { get; set; }      
        public DateTime? UpdatedDate { get; set; }
        
        public Guid? CreatedUserId { get; set; }
        public Guid? UpdatedUserId { get; set; }        
        public bool Coffee { get; set; }
        public string LaunchSport { get; set; }
        public DateTime PlannedDate { get; set; }
        public string BreakFastTime { get; set; }
        public string DinnerTime { get; set; }
        public string Fruits { get; set; }
        public string EveningSport { get; set; }
        public bool DrinkWater { get; set; }
        public int StepCount { get; set; }
        public decimal WeightDifference { get; set; }
        public string? Fails { get; set; }
        public Guid UserId { get; set; }
    }
}
