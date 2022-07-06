using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ERP.Models.Context
{
    public class ERPDBContext : DbContext
    {
		private string _ConnectionString { get; set; }

		#region Constructor

		public ERPDBContext()
		{
		}

		public ERPDBContext(string connectionString)
		{
			_ConnectionString = connectionString;
		}

		public ERPDBContext(DbContextOptions<ERPDBContext> options) : base(options)
		{
		}

		#endregion Constructor

		#region DBSET Properties

		//public DbSet<UserMaster> UserMasters { get; set; }


		#endregion DBSET Properties

		#region Override Methods

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	IConfigurationRoot configuration = new ConfigurationBuilder()
		//	.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
		//	.AddJsonFile("appsettings.json")
		//	.Build();
		//	optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
		//}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<UserMaster>().ToTable<UserMaster>("UserMaster");
		}

		#endregion Override Methods
	}
}
