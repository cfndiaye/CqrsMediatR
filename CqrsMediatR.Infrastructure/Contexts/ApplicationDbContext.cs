using System;
using System.Threading.Tasks;
using CqrsMediatR.Core.Models;
using CqrsMediatR.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatR.Infrastructure.Contexts
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
		{
		}

        public DbSet<Product> Products { get; set; }

		public async Task<int> SaveChangesAsync()
        {
			return await base.SaveChangesAsync();
        }

    }
}

