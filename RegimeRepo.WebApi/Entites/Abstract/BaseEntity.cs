using System.Data;

namespace RegimeRepo.WebApi.Entites.Abstract
{
    public class BaseEntity<T>
    {

        public T Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? UpdatedUserId { get; set; }
        public DataRowVersion RowVersion { get; set; } = DataRowVersion.Default;

    }
}
