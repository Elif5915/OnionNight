using OnionNight.Application.Features.CQRS.Commands;
using OnionNight.Persistence.Context;

namespace OnionNight.Application.Features.CQRS.Handlers;
public class UpdateCategoryCommandHandler
{
    private readonly OnionContext _context;

    public UpdateCategoryCommandHandler(OnionContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCategoryCommand command)
    {
        var value = await _context.Categories.FindAsync(command.CategoryId);
        value.CategoryName = command.CategoryName;
        await _context.SaveChangesAsync();
    }
}

