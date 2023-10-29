using RegimeRepo.WebApi.Entites.Concrete;
using System.Linq.Expressions;

namespace RegimeRepo.WebApi.Businnes.Abstract
{
    public interface IUserService
    {
        Task<UserEntity> GetById(Guid id);
        Task Add(UserEntity entity);
        Task Update(UserEntity entity);
        Task Delete(Guid Id);
    }
}
