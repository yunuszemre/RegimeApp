using RegimeRepo.WebApi.Entites.Abstract;

namespace RegimeRepo.WebApi.Entites.Concrete
{
    public class UserEntity :BaseEntity<Guid>
    {
        public string Name { get; set; }       
        public List<RegimeEntity>? Regimes { get; set; }
    }
}
