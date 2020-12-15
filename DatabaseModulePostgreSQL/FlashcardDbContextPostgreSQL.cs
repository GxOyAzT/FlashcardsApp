using Microsoft.EntityFrameworkCore;
using Models;

namespace DatabaseModulePostgreSQL
{
    public class FlashcardDbContextPostgreSQL : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql(DbConnectionString.GetTestConn());
        }

        public DbSet<FlashcardDbModel> FlashcardsDbModels { get; set; }
        public DbSet<GroupDbModel> GroupDbModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupDbModel>(entity =>
            {
                entity.ToTable("groupmodeltbl", "fc");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.UserId).HasColumnName("userid");
            });

            modelBuilder.Entity<FlashcardDbModel>(entity =>
            {
                entity.ToTable("flashcardmodeltbl", "fc");

                entity.HasKey(e => new { e.Id, e.PracticeDirection });

                entity.HasOne(e => e.GroupDbModel)
                    .WithMany(d => d.FlashcardDbModels)
                    .HasForeignKey(x => x.GroupDbModelId);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.GroupDbModelId).HasColumnName("groupdbmodelid");
                entity.Property(e => e.NativeLanguage).HasColumnName("nativelanguage");
                entity.Property(e => e.ForeignLanguage).HasColumnName("foreignlanguage");
                entity.Property(e => e.NextPracticeDate).HasColumnName("nextpracticedate");
                entity.Property(e => e.PracticeDirection).HasColumnName("practicedirection");
                entity.Property(e => e.CorreactAnsInRow).HasColumnName("correactansinrow");

            });
        }
    }
}
