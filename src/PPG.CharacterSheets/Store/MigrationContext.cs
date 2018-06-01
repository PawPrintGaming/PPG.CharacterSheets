using Microsoft.EntityFrameworkCore;
using PPG.CharacterSheets.Characters.Entities;
using PPG.CharacterSheets.RuleSets.Entities;

namespace PPG.CharacterSheets.Store
{
    public class MigrationContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<RuleSetInfo> RuleSetInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Store/_malifauxttb.db");
        }
    }
}
