using Microsoft.EntityFrameworkCore;
using Models;

namespace DatabaseModule
{
    public class FlashcardsDbContext : DbContext
    {
        public FlashcardsDbContext()
        {
        }

        public FlashcardsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("workstation id=FlashcardsDb.mssql.somee.com;packet size=4096;user id=PortfolioDB;pwd=Truskawka1;data source=FlashcardsDb.mssql.somee.com;persist security info=False;initial catalog=FlashcardsDb");
            }
        }

        public DbSet<FlashcardDbModel> FlashcardsDbModels { get; set; }
        public DbSet<GroupDbModel> GroupDbModels { get; set; }
        public DbSet<UserDbModel> UserDbModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupDbModel>(entity =>
            {
                entity.ToTable("GroupModelTbl", "fc");

                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<FlashcardDbModel>(entity =>
            {
                entity.ToTable("FlashcardModelTbl", "fc");

                entity.HasKey(e => new { e.Id, e.PracticeDirection });

                entity.HasOne(e => e.GroupDbModel)
                    .WithMany(d => d.FlashcardDbModels)
                    .HasForeignKey(x => x.GroupDbModelId);
            });

            modelBuilder.Entity<UserDbModel>(entity =>
            {
                entity.ToTable("UserModelTbl", "fc");

                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.GroupDbModels)
                    .WithOne(d => d.UserDbModel)
                    .HasForeignKey(x => x.UserDbModelId);
            });
        }
    }
}
