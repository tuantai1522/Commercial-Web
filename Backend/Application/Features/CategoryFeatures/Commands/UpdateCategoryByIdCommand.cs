using Application.Features.ProductFeatures.Commands;
using Application.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.ProductFeatures.Commands.UpdateProductByIdCommand;

namespace Application.Features.CategoryFeatures.Commands
{
    public class UpdateCategoryByIdCommand : IRequest<object>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateCategoryByIdCommandHandler : IRequestHandler<UpdateCategoryByIdCommand, object>

        {


            private readonly IApplicationDbContext _context;
            public UpdateCategoryByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            //1: find product successfully to update
            //0: error
            //-1: can not find product to update
            public async Task<object> Handle(UpdateCategoryByIdCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var category = _context.Categories.Where(a => a.Id == command.Id).FirstOrDefault();

                    if (category == null)
                        return new
                        {
                            message = "Can not find category to update",
                            status = 0,
                            DT = (object)null
                        };

                    category.Name = command.Name;
                    
                    await _context.SaveChangesAsync();

                    return new
                    {
                        message = "Update category successfully",
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
