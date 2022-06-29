using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CqrsMediatR.Core.Models;
using CqrsMediatR.Infrastructure.Interfaces;
using MediatR;

namespace CqrsMediatR.Infrastructure.Features.ProductFeatures.Queries
{
	public class GetProductByIdQuery : IRequest<Product>
	{
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {

            private readonly IApplicationDbContext _context;

            public GetProductByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(query.Id);
                if (product == null) return null;
                return product;
            }
        }
    }
}

