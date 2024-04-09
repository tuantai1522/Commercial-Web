using Application.Features.CategoryFeatures.Queries;
using Application.Interface;
using Domain.DTO;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CartItemFeatures.Queries
{
    public class GetCartItemsQuery : IRequest<object>
    {
        public string CustomerName {  get; set; }
        public class GetCartItemsQueryHandler : IRequestHandler<GetCartItemsQuery, object>
        {
            private readonly IApplicationDbContext _context;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetCartItemsQueryHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
            {
                _context = context;
                _httpContextAccessor = httpContextAccessor;
            }
            public async Task<object> Handle(GetCartItemsQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    // Add into cookies
                    var context = _httpContextAccessor.HttpContext;

                    var cart = await _context.Carts.Where(c => c.CustomerName.Equals(query.CustomerName)).FirstOrDefaultAsync();

                    if (cart == null)
                        return new
                        {
                            message = "Can not find cart of this customer",
                            status = 0,
                            DT = (object)null,
                        };

                    var cartItems = await _context.CartItems
                                    .Where(c => c.CartId == cart.Id)
                                    .Include(c => c.Product) 
                                    .ThenInclude(p => p.Category) 
                                    .ToListAsync();

                    List<CartItemDTO> cartItemDTOs = new List<CartItemDTO>();

                    foreach (CartItem cartItem in cartItems)
                    {
                        CartItemDTO cartItemDTO = Util.BuildCartItemDTO(cartItem);
                        cartItemDTOs.Add(cartItemDTO);
                    }
                    return new
                    {
                        message = "Fetching cart items successfully",
                        status = 1,
                        DT = cartItemDTOs,
                        CustomerName = query.CustomerName
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
