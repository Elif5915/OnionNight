using MediatR;

namespace OnionNight.Application.Features.Mediator.Commands;
public class CreateProductCommand : IRequest
{
    public string ProductName { get; set; }
    public int ProductStock { get; set; }
    public decimal ProductPrice { get; set; }
}

