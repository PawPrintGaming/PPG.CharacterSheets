using Microsoft.EntityFrameworkCore;
using PPG.CharacterSheets.Core;

namespace PPG.CharacterSheets.Store
{
    public class Context<TEntity> : DbContext where TEntity : class, IIdentifiable
    {
        public DbSet<TEntity> EntitySet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Store/_malifauxttb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TEntity>(entity =>
                entity.HasKey(e => e.Id)
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
