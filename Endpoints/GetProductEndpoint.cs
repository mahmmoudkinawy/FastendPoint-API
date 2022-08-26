namespace API.Endpoints;

[HttpGet("/api/products/{id}"), AllowAnonymous]
public class GetProductEndpoint : Endpoint<GetProductRequest, GetProductResponse>
{
    private readonly IProductRepository _productRepository;

    public GetProductEndpoint(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public override async Task HandleAsync(GetProductRequest req, CancellationToken ct)
    {
        var product = await _productRepository.GetProductByIdAsync(req.Id);

        if (product == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var thingRoReturn = new GetProductResponse
        {
            Id = product.Id,
            CountInStock = product.CountInStock,
            Created = product.Created,
            Name = product.Name,
            Price = product.Price
        };

        await SendOkAsync(thingRoReturn, ct);
    }
}
