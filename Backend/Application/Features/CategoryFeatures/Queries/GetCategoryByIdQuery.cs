using Application.Features.ProductFeatures.Queries;
using Application.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Queries
{
    public class GetCategoryByIdQuery : IRequest<object>
    {
        public int Id { get; set; }
        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, object>
        {
            private readonly IApplicationDbContext _context;
            public GetCategoryByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<object> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var product = await _context.Categories.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                    if (product == null)
                        return new
                        {
                            message = "Can not find category",
                            status = 0,
                            DT = (object)null
                        };
                    return new
                    {
                        message = "Fetching category successfully",
                        status = 1,
                        DT = product
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
