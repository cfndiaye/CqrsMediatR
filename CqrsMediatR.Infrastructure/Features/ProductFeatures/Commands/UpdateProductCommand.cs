using CqrsMediatR.Core.Models;
using CqrsMediatR.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsMediatR.Infrastructure.Features.ProductFeatures.Commands
{
	public class UpdateProductCommand : IRequest<int>
	{
        public Product Product { get; set; }
        public int Id { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(command.Id);
                if (product == null) return default;

                product = command.Product;
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}

