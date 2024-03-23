using Application.Features.ProductFeatures.Commands;
using Application.Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands
{
    public class CreateCategoryCommand : IRequest<object>
    {
        public string Name { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, object>
        {
            private readonly IApplicationDbContext _context;
            public CreateCategoryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }


            //1: success
            //-1: fail
            public async Task<object> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var category = new Category();
                    category.Name = command.Name;

                    _context.Categories.Add(category);
                    await _context.SaveChangesAsync();


                    return new
                    {
                        message = "Create category successfully",
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
