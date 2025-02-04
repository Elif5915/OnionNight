using OnionNight.Application.Features.CQRS.Commands;
using OnionNight.Persistence.Context;

namespace OnionNight.Application.Features.CQRS.Handlers;
public class CreateCategoryCommandHandler
{
    private readonly OnionContext _context;

    public CreateCategoryCommandHandler(OnionContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateCategoryCommand command)
    {
        _context.Categories.Add(new Domain.Entities.Category()
        {
            CategoryName = command.CategoryName
        });
        await _context.SaveChangesAsync();
    }
}

