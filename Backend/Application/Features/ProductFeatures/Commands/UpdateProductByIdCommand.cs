using Application.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class UpdateProductByIdCommand : IRequest<object>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int QuantityInStock { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }


        public class UpdateProductByIdCommandHandler : IRequestHandler<UpdateProductByIdCommand, object>
        {
            private readonly IApplicationDbContext _context;
            public UpdateProductByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            //1: find product successfully to update
            //0: error
            //-1: can not find product to update
            public async Task<object> Handle(UpdateProductByIdCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var product = _context.Products.Where(a => a.Id == command.Id).FirstOrDefault();

                    if (product == null)
                        return new
                        {
                            message = "Can not find product to update",
                            status = 0,
                            DT = (object)null
                        };

                    product.Name = command.Name;
                    product.Description = command.Description;
                    product.Price = command.Price;
                    product.QuantityInStock = command.QuantityInStock;
                    product.ImageUrl = command.ImageUrl;
                    product.CategoryId = command.CategoryId;

                    await _context.SaveChangesAsync();

                    return new
                    {
                        message = "Update product successfully",
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
