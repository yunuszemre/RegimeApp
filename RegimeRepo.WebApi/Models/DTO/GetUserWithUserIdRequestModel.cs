using System.ComponentModel.DataAnnotations;

namespace RegimeRepo.WebApi.Models.DTO
{
    public class GetUserWithUserIdRequestModel
    {
        [Required(ErrorMessage = "UserId is required")]
        public Guid UserId { get; set; }
    }
}
