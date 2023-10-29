using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegimeRepo.WebApi.Businnes.Abstract;
using RegimeRepo.WebApi.Entites.Concrete;
using RegimeRepo.WebApi.Models;
using RegimeRepo.WebApi.Models.DTO;
using System.Net;

namespace RegimeRepo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegimeController : ControllerBase
    {
        private readonly IRegimeService _regimeService;
        public RegimeController(IRegimeService regimeService)
        {
            _regimeService = regimeService;
        }

        [HttpGet("getallregimes")]
        [ProducesResponseType(typeof(ReturnModel<RegimeEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ReturnModel<RegimeEntity>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _regimeService.GetAll();
            return Ok(result);
        }
        [HttpPost("addorupdateregime")]
        [ProducesResponseType(typeof(ReturnModel<RegimeEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ReturnModel<RegimeEntity>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateOrUpdateRegime([FromBody] AddOrUpdateRegimeDto dto)
        {
            if (dto.Id == null)
            {
                var resullt = await _regimeService.Add(dto);
                return Ok(resullt);
            }
            var result = await _regimeService.Update(dto);
            return Ok(result);
        }
        [HttpPost("getregimeswithuserid")]
        [ProducesResponseType(typeof(ReturnModel<RegimeEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ReturnModel<RegimeEntity>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetRegimesWithUserId([FromBody] GetUserWithUserIdRequestModel dto)
        {
            var result = await _regimeService.GetByUserIdAll(dto.UserId);

            return Ok(result);
        }
        [HttpPost("getregimewithid")]
        [ProducesResponseType(typeof(ReturnModel<RegimeEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ReturnModel<RegimeEntity>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetRegimesWithUserId([FromBody] GetRegimeWithIdRequestModel dto)
        {
            var result = await _regimeService.GetById(dto.RegimeId);

            return Ok(result);
        }
        [HttpGet("healthcheck")]
        public OkObjectResult Get()
        {
            return Ok(new ReturnModel<string> { Data = "Service is active", IsSuccess = true });
        }
    }
}
