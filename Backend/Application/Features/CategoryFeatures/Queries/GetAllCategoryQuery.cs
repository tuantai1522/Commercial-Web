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
    public class GetAllCategoryQuery : IRequest<object>
    {
        public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, object>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCategoryQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<object> Handle(GetAllCategoryQuery query, CancellationToken cancellationToken)
            {
                try
                {

                    var productList = await _context.Categories.ToListAsync();
                    if (productList == null)
                    {
                        return new
                        {
                            message = "Can not find any categories",
                            status = 0,
                            DT = (object)null
                        };
                    }

                    return new
                    {
                        message = "Fetching categories successfully",
                        status = 1,
                        DT = productList.AsReadOnly()
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
