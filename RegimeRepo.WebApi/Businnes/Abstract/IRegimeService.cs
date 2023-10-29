using RegimeRepo.WebApi.Entites.Concrete;
using RegimeRepo.WebApi.Models;
using RegimeRepo.WebApi.Models.DTO;
using System.Linq.Expressions;

namespace RegimeRepo.WebApi.Businnes.Abstract
{
    public interface IRegimeService
    {
        Task<ReturnModel<RegimeEntity>> GetById(Guid id);
        Task<ReturnModel<RegimeReturnModel>> Add(AddOrUpdateRegimeDto dto);
        Task<ReturnModel<RegimeReturnModel>> Update(AddOrUpdateRegimeDto dto);
        Task<ReturnModel<RegimeReturnModel>> Delete(Guid Id);
        Task<ReturnModel<List<RegimeEntity>>> GetAll();
        Task<ReturnModel<List<RegimeEntity>>> GetByUserIdAll(Guid Id);
    }
}
