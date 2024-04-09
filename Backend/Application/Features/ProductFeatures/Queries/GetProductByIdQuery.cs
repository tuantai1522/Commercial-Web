using Application.Interface;
using Domain.DTO;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<object>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, object>
        {
            private readonly IApplicationDbContext _context;
            public GetProductByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<object> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var product = await _context.Products.Where(a => a.Id == query.Id).Include("Category").FirstOrDefaultAsync();
                    if (product == null)
                        return new
                        {
                            message = "Can not find product",
                            status = 0,
                            DT = (object)null
                        };

                    ProductDTO productDTO = Util.BuildProductDTO(product);

                    return new
                    {
                        message = "Fetching product successfully",
                        status = 1,
                        DT = productDTO
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
