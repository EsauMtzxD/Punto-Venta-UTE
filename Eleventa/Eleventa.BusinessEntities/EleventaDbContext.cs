using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.BusinessEntities
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class EleventaDbContext : DbContext
    {
        public EleventaDbContext() : base("EleventaDbContext")
        {

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<EleventaDbContext, BusinessEntities.Migrations.Configuration>());

        }

        public DbSet <Cut> Cuts { get; set; }
        public DbSet <Department> Departments { get; set; }
        public DbSet <Product> Products { get; set; }
        public DbSet <Sale> Sales { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
