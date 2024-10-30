using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Context
{
	public class OrderContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server = localhost,1440; database = MultishopOrderDb; " +
				"TrustServerCertificate=True ; User=sa; Password=Elmaelma4321*");
		}

		public DbSet<Address> Addresses { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }
		public DbSet<Ordering> Ordering { get; set; }	

	}
}
