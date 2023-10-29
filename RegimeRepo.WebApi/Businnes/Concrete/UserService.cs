using Microsoft.EntityFrameworkCore;
using RegimeRepo.WebApi.ApplicationDbContext;
using RegimeRepo.WebApi.Businnes.Abstract;
using RegimeRepo.WebApi.Entites.Concrete;

namespace RegimeRepo.WebApi.Businnes.Concrete
{
    public class UserService : IUserService
    {
        private readonly hakanhak_HakanHakyemezContext _contex;
        public UserService(hakanhak_HakanHakyemezContext context)
        {
            _contex = context;
        }
        public async Task Add(UserEntity entity)
        {

            var result = await _contex.Users.AddAsync(entity);
            if (result.Properties.Count() > 0)
                _contex.SaveChanges();
            else
                throw new Exception("An Error Accured while entity adding");

        }

        public async Task Delete(Guid Id)
        {
            var user = await _contex.Users.FirstOrDefaultAsync(x => x.Id == Id);
            if (user == null)
            {
                throw new Exception("Can't find an regime with given Id");
            }
            _contex.Users.Remove(user);
            _contex.SaveChanges();
        }

        public async Task<UserEntity> GetById(Guid id)
        {
            var user = await _contex.Users.Include(x => x.Regimes).FirstOrDefaultAsync(x => x.Id == id);
            return user != null ? user : throw new Exception("Can't find an user with given Id");
        }

        public async Task Update(UserEntity entity)
        {
            _contex.Users.Update(entity);
            _contex.SaveChanges();
        }
    }
}
