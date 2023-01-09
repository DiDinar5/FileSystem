using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directory = DataLayer.Entities.Directory;

namespace DataLayer
{
    public class EFDBContext:DbContext
    {
        public DbSet<Directory> Directory { get; set; }
        public DbSet<Material> Material { get; set; }
        
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }
        /// <summary>
        /// for Migrations
        /// </summary>
        public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
        {
            public EFDBContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FileSystem;Trusted_Connection=True;MultipleActiveResultSets=true",b=>b.MigrationsAssembly("DataLayer"));
                return new EFDBContext(optionsBuilder.Options);
            }
        }
    }
}
