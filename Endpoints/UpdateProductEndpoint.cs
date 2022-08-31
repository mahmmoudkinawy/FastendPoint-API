namespace API.Endpoints;

[HttpPut("api/products/{id}"), AllowAnonymous]
public class UpdateProductEndpoint : Endpoint<UpdateProductRequest>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductEndpoint(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public override async Task HandleAsync(UpdateProductRequest req, CancellationToken ct)
    {
        var product = await _productRepository.GetProductByIdAsync(req.Id);

        if (product == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await _productRepository.UpdateProduct(_mapper.Map<ProductEntity>(req));

        await SendNoContentAsync(ct);
    }
}
