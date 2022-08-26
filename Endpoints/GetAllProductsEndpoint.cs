//namespace API.Endpoints;
//public class GetAllProductsEndpoint : EndpointWithoutRequest<List<GetProductResponse>>
//{
//    private readonly AmazonDbContext _context;

//    public GetAllProductsEndpoint(AmazonDbContext context)
//    {
//        _context = context;
//    }

//    public override void Configure()
//    {
//        Verbs(Http.GET);
//        Routes("/api/products");
//        AllowAnonymous();
//    }

//    public override async Task HandleAsync(CancellationToken ct)
//    {
//        var temp = new List<GetProductResponse>();
//        var products = await _context.Products.ToListAsync(cancellationToken: ct);
//        var productsResponse = 

//        await SendOkAsync(products);
//    }
//}
