using Application.Features.ProductFeatures.Commands;
using Application.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CartItemFeatures.Commands
{
    public class DeleteCartItemByIdCommand : IRequest<object>
    {
        public int Id { get; set; }
        public class DeleteCartItemByIdHandler : IRequestHandler<DeleteCartItemByIdCommand, object>
        {
            private readonly IApplicationDbContext _context;
            public DeleteCartItemByIdHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<object> Handle(DeleteCartItemByIdCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    //Find cart item to delete of this customer
                    var cartItem = await _context.CartItems.Where(a => a.Id == command.Id).FirstOrDefaultAsync();

                    if (cartItem == null)
                        return new
                        {
                            message = "Can not find cart item to delete",
                            status = 0,
                            DT = (object)null
                        };

                    _context.CartItems.Remove(cartItem);
                    await _context.SaveChangesAsync();

                    return new
                    {
                        message = "Delete cart item successfully",
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
