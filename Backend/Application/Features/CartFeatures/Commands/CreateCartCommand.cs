using Application.Features.CategoryFeatures.Commands;
using Application.Interface;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CartFeatures.Commands
{
    public class CreateCartCommand : IRequest<object>
    {
        public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, object>
        {
            private readonly IApplicationDbContext _context;

            private readonly IHttpContextAccessor _httpContextAccessor;


            public CreateCartCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
            {
                _context = context;
                _httpContextAccessor = httpContextAccessor;
            }


            //1: success
            //-1: fail
            public async Task<object> Handle(CreateCartCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var cart = new Cart();

                    //to create random customerId
                    string CustomerName = Guid.NewGuid().ToString();
                    cart.CustomerName = CustomerName;

                    // Add into cookies
                    var context = _httpContextAccessor.HttpContext;
                    var cookieOptions = new CookieOptions
                    {
                        IsEssential = true,
                        Expires = DateTime.Now.AddDays(30),
                    };
                    context.Response.Cookies.Append("CustomerName", CustomerName, cookieOptions);


                    _context.Carts.Add(cart);
                    await _context.SaveChangesAsync();

                    return new
                    {
                        message = "Create cart successfully",
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
