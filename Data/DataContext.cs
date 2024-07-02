global using Microsoft.EntityFrameworkCore;
using System;

namespace CatsAPI.Data
{
	public class DataContext : DbContext
	{

        public DataContext()
        {

        }

        // Construtor that accepts DbContextOptions as a parameter
        // Plus, calls constructor in base class and passes options
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=cats_schema;Uid=root;Pwd=********";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(connectionString, serverVersion);

            
        }

        public DbSet<CatModel> Cats { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        
    }
}
