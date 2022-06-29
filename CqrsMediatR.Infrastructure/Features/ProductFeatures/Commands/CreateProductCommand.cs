using CqrsMediatR.Core.Models;
using CqrsMediatR.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsMediatR.Infrastructure.Features.ProductFeatures.Commands
{
	public class CreateProductCommand : IRequest<int>
	{
        public Product Product { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async  Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = command.Product;

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return product.Id;
            }
        }
    }
}

