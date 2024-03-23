using Application.Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<object>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int QuantityInStock { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, object>
        {
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }


            //1: success
            //-1: fail
            public async Task<object> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var product = new Product();
                    product.Name = command.Name;
                    product.Description = command.Description;
                    product.Price = command.Price;
                    product.QuantityInStock = command.QuantityInStock;
                    product.ImageUrl = command.ImageUrl;
                    product.CategoryId = command.CategoryId;

                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();


                    return new
                    {
                        message = "Create product successfully",
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
