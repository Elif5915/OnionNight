using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionNight.Application.Features.Mediator.Commands;
using OnionNight.Application.Features.Mediator.Queries;

namespace OnionNight.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ProductList()
    {
        return Ok(await _mediator.Send(new GetProductQuery()));
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        await _mediator.Send(command);
        return Ok("Ekleme Yapıldı");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _mediator.Send(new RemoveProductCommand(id));
        return Ok("Silme Yapıldı");
    }
    [HttpGet("GetProduct")]
    public async Task<IActionResult> GetByIdProduct(int id)
    {
        return Ok(await _mediator.Send(new GetProductByIdQuery(id)));
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
    {
        await _mediator.Send(command);
        return Ok("Güncelleme Başarılı");
    }
}
