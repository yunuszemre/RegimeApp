using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RegimeRepo.WebApi.Models.DTO
{
    public class GetRegimeWithIdRequestModel
    {
        [Required(ErrorMessage ="RegimeId is required")]
        public Guid RegimeId { get; set; }
    }
}
