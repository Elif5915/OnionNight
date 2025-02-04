using Microsoft.AspNetCore.Mvc;
using OnionNight.Application.Features.CQRS.Commands;
using OnionNight.Application.Features.CQRS.Handlers;

namespace OnionNight.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
    private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
    private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
    private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
    private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

    public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
    {
        _getCategoryQueryHandler = getCategoryQueryHandler;
        _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        _createCategoryCommandHandler = createCategoryCommandHandler;
        _updateCategoryCommandHandler = updateCategoryCommandHandler;
        _removeCategoryCommandHandler = removeCategoryCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        return Ok(await _getCategoryQueryHandler.Handle());
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
        await _createCategoryCommandHandler.Handle(command);
        return Ok("İşlem Yapıldı");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
        return Ok("Silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
    {
        await _updateCategoryCommandHandler.Handle(command);
        return Ok("İşlem yapıldı");
    }
}
