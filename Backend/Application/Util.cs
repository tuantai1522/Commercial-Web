using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Domain.Entities;
using Domain.DTO;

namespace Application
{
    public static class Util
    {
        public static ProductDTO BuildProductDTO(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                QuantityInStock = product.QuantityInStock,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Category.Name,
            };
        }

        public static CartItemDTO BuildCartItemDTO(CartItem cartItem)
        {
            return new CartItemDTO
            {
                CartId = cartItem.CartId,
                Id = cartItem.Id,
                Quantity = cartItem.Quantity,
                ProductId = cartItem.ProductId,
                ProductName = cartItem.Product.Name,
                Description = cartItem.Product.Description,
                Price = cartItem.Product.Price,
                ImageUrl = cartItem.Product.ImageUrl,
                CategoryName = cartItem.Product.Category.Name
            };
        }
    }
}
