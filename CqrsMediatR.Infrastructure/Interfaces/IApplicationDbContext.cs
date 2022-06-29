using System;
using System.Threading.Tasks;
using CqrsMediatR.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatR.Infrastructure.Interfaces
{
	public interface IApplicationDbContext
	{
        public DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync();
    }
}

