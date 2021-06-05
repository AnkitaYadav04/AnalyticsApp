using AngaloAmericanAnalytics.API.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngaloAmericanAnalytics.API.Data
{
    public class AngaloAmericanAnalyticsDbContext: DbContext
    { 

        private readonly IConfiguration _configuration;
        public const string DefaultSchema = "dbo";
        public AngaloAmericanAnalyticsDbContext(DbContextOptions dbContextOptions, IConfiguration configuration):base(dbContextOptions)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public DbSet<Model> Models { get; set; } = null!;
        public DbSet<ModelContract> ModelContracts { get; set; } = null!;
        public DbSet<ModelDetail> ModelDetails { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder = dbContextOptionsBuilder ?? throw new ArgumentNullException(nameof(dbContextOptionsBuilder));
            if (dbContextOptionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetSection("ConnectionStrings:Database");
                dbContextOptionsBuilder.UseSqlServer(connectionString.Value);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
