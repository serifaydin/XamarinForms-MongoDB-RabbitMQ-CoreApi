using Microsoft.EntityFrameworkCore;
using MLTP.Infrastructure.DataModels.Models;

namespace MLTP.Infrastructure.DataLibrary
{
    public class MLTPDataContext : DbContext
    {
        public DbSet<MltpMenu> MltpMenu { get; set; }
        public DbSet<MltpRole> MltpRole { get; set; }
        public DbSet<MltpRoleMenu> MltpRoleMenu { get; set; }
        public DbSet<MltpUser> MltpUser { get; set; }
        public DbSet<MltpUserRole> MltpUserRole { get; set; }
        public DbSet<MltpUserDevice> MltpUserDevice { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.; database=MLTP; trusted_connection=true;");
            }
        }
    }
}