namespace API.Endpoints;

[HttpDelete("api/products/{id}"), AllowAnonymous]
public class DeleteProductEndpoint : Endpoint<DeleteProductRequest>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductEndpoint(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public override async Task HandleAsync(DeleteProductRequest req, CancellationToken ct)
    {
        var product = await _productRepository.GetProductByIdAsync(req.Id);

        if (product == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await _productRepository.RemoveProduct(product);

        await SendNoContentAsync(ct);
    }
}
