namespace API.Endpoints;

[HttpGet("/api/products/{id}"), AllowAnonymous]
public class GetProductEndpoint : Endpoint<GetProductRequest, ProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductEndpoint(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public override async Task HandleAsync(GetProductRequest req, CancellationToken ct)
    {
        var product = await _productRepository.GetProductByIdAsync(req.Id);

        if (product == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(_mapper.Map<ProductResponse>(product), ct);
    }
}
