using Microsoft.EntityFrameworkCore;
using RegimeRepo.WebApi.Entites.Concrete;

namespace RegimeRepo.WebApi.ApplicationDbContext
{
    public class hakanhak_HakanHakyemezContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RegimeEntity> Regimes { get; set; }
        private readonly IConfiguration _configuration;
        public hakanhak_HakanHakyemezContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("hakyemezConStr"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasKey(x => x.Id);
           
            modelBuilder.Entity<UserEntity>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);

            modelBuilder.Entity<RegimeEntity>()
               .HasKey(x => x.Id);
            modelBuilder.Entity<RegimeEntity>()
                .Property(x => x.StepCount)
                .IsRequired()
                .HasDefaultValue(0);
            modelBuilder.Entity<RegimeEntity>()
                .Property(x => x.DinnerTime)
                .IsRequired();
            modelBuilder.Entity<RegimeEntity>()
               .Property(x => x.BreakFastTime)
               .IsRequired();
            modelBuilder.Entity<RegimeEntity>()
              .Property(x => x.CreatedUserId)
              .IsRequired();
            modelBuilder.Entity<RegimeEntity>()
                .HasOne(x => x.User)
                .WithMany(x => x.Regimes)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
            
          






            base.OnModelCreating(modelBuilder);
        }
    }
}
