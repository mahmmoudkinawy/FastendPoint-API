namespace API.Endpoints;

[HttpGet("/api/products"), AllowAnonymous]
public class GetAllProductsEndpoint : EndpointWithoutRequest<IReadOnlyList<GetProductResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductsEndpoint(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var products = await _productRepository.GetAllProductsAsync();

        await SendOkAsync(_mapper.Map<IReadOnlyList<GetProductResponse>>(products), ct);
    }
}
