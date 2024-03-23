using Application.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeleteProductByIdCommand : IRequest<object>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, object>
        {
            private readonly IApplicationDbContext _context;
            public DeleteProductByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<object> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var product = await _context.Products.Where(a => a.Id == command.Id).FirstOrDefaultAsync();

                    if (product == null) 
                        return new
                        {
                            message = "Can not find product to delete",
                            status = 0,
                            DT = (object)null
                        };

                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();

                    return new
                    {
                        message = "Delete product successfully",
                        status = 1,
                        DT = (object)null
                    };
                }
                catch (Exception ex)
                {
                    return new
                    {
                        message = "Something went wrong",
                        status = -1,
                        DT = (object)null
                    };

                    throw new NotImplementedException();

                }

            }
        }
    }
}
