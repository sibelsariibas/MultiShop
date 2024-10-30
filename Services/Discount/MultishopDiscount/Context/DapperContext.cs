﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultishopDiscount.Entitites;
using System.Data;

namespace MultishopDiscount.Context
{
	public class DapperContext : DbContext
	{
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;

		public DapperContext(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("DefaultConnection");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server = SSARIBAS130721\\SSARIBAS; database = MultishopDiscountDb; integrated security= true; TrustServerCertificate=True");
		}
        public DbSet<Coupon> Coupons { get; set; }
		public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
