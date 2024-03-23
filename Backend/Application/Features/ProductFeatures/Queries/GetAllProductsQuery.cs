using Application.Common;
using Application.Features.ProductFeatures.Extensions;
using Application.Interface;
using Domain.Entities;
using Domain.RequestHelpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<object>
    {
        public ProductParams productParams = new ProductParams();

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, object>
        {
            private readonly IApplicationDbContext _context;
            public GetAllProductsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<object> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    //Sort, Search, and Filter
                    var productList = _context.Products
                        .Sort(query.productParams.OrderBy)
                        .Search(query.productParams.KeyWord)
                        .Filter(query.productParams.CategoryType)
                        .Include("Category")
                        .AsQueryable();

                    //Pagination
                    var products = await PagedList<Product>.ToPagedList(productList, query.productParams.PageNumber, 
                                                    query.productParams.PageSize);


                    if (products == null)
                    {
                        return new
                        {
                            message = "Can not find any products",
                            status = 0,
                            DT = (object)null
                        };
                    }

                    return new
                    {
                        message = "Fetching products successfully",
                        status = 1,
                        DT = new
                        {
                            TotalCount = products.MetaData.TotalCount,
                            TotalPages = products.MetaData.TotalPage,
                            Products = products.ToList()
                        }
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
