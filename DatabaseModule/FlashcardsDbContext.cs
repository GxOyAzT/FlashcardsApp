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
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FlashcardsApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        public DbSet<FlashcardDbModel> FlashcardsDbModels { get; set; }
        public DbSet<GroupDbModel> GroupDbModels { get; set; }

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
        }
    }
}
