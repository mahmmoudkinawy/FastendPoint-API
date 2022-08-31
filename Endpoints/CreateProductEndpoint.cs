namespace API.Endpoints;

[HttpPost("api/products"), AllowAnonymous]
public class CreateProductEndpoint : Endpoint<CreateProductRequest, ProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateProductEndpoint(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public override async Task HandleAsync(CreateProductRequest req, CancellationToken ct)
    {
        var product = _mapper.Map<ProductEntity>(req);

        await _productRepository.AddProduct(product);

        await SendNoContentAsync(ct);
    }
}
