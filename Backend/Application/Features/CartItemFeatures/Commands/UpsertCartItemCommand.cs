using Application.Features.CategoryFeatures.Commands;
using Application.Interface;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CartItemFeatures.Commands
{
    public class UpsertCartItemCommand : IRequest<object>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { get; set; }
        public int? isAdding { get; set; } = 1;
        public class UpsertCartItemCommandHandler : IRequestHandler<UpsertCartItemCommand, object>
        {
            private readonly IApplicationDbContext _context;
            private readonly IHttpContextAccessor _httpContextAccessor;
            public UpsertCartItemCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
            {
                _context = context;
                _httpContextAccessor = httpContextAccessor;
            }

            private async Task<Cart> CreateCart()
            {

                //to create random customerId
                string CustomerName = Guid.NewGuid().ToString();

                // Add into cookies
                var context = _httpContextAccessor.HttpContext;
                var cookieOptions = new CookieOptions
                {
                    IsEssential = true,
                    Expires = DateTime.Now.AddDays(30),
                };

                context.Response.Cookies.Append("CustomerName", CustomerName, cookieOptions);

                var cart = new Cart { CustomerName = CustomerName };

                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();

                return cart;
            }
            //1: success
            //-1: fail
            public async Task<object> Handle(UpsertCartItemCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var context = _httpContextAccessor.HttpContext;

                    //Check whether cart is create or not
                    var cart = _context.Carts.FirstOrDefault(c => c.CustomerName.Equals(command.CustomerName));

                    if (cart == null)
                    {
                        cart = await CreateCart();
                    }
                    //Check whether this product is in cart item or not
                    var cartItems = await _context.CartItems
                        .FirstOrDefaultAsync(c => c.CartId == cart.Id && c.ProductId == command.ProductId);

                    if (cartItems == null)
                    {
                        var cartItem = new CartItem
                        {
                            Quantity = command.Quantity,
                            ProductId = command.ProductId,
                            CartId = cart.Id,
                        };

                        _context.CartItems.Add(cartItem);

                        await _context.SaveChangesAsync();

                        return new
                        {
                            message = "Create cart item successfully",
                            status = 1,
                            DT = (object)null,
                            CustomerName = cart.CustomerName,
                        };


                    }
                    else
                    {
                        // Nếu sản phẩm đã tồn tại trong giỏ hàng, cập nhật số lượng của sản phẩm

                        //add to cart
                        if(command.isAdding == 1)
                            cartItems.Quantity += command.Quantity;
                        else
                            cartItems.Quantity = command.Quantity;


                        //Nếu số lượng bằng không thì xóa sản phẩm
                        if (cartItems.Quantity <= 0)
                            _context.CartItems.Remove(cartItems);
                        else
                            _context.CartItems.Update(cartItems);

                        await _context.SaveChangesAsync();

                        return new
                        {
                            message = "Update cart item successfully",
                            status = 1,
                            DT = (object)null,
                        };
                    }
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
