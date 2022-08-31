namespace API.Endpoints;

[HttpGet("/api/products"), AllowAnonymous]
public class GetAllProductsEndpoint : Endpoint<PaginationParams, PagerModel<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsEndpoint(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public override async Task HandleAsync([FromQuery] PaginationParams req, CancellationToken ct)
    {
        var products = await _productRepository.GetAllProductsAsync(req);

        HttpContext.Response.AddPaginationHeader(
            products.CurrentPage,
            products.PageSize,
            products.TotalPages,
            products.TotalCount);

        await SendOkAsync(products, ct);
    }
}
