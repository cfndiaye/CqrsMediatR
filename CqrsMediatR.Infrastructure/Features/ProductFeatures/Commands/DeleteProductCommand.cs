using CqrsMediatR.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsMediatR.Infrastructure.Features.ProductFeatures.Commands
{
	public class DeleteProductCommand : IRequest<int>
	{
		public int Id { get; set; }
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(command.Id);
                if (product == null) return default;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}

