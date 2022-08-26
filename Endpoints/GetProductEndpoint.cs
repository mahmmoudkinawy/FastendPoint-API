using Microsoft.AspNetCore.Authorization;

namespace API.Endpoints;

[HttpGet("/api/customer/{id}"), AllowAnonymous]
public class GetProductEndpoint : Endpoint<GetProductRequest, GetProductResponse>
{
    private readonly AmazonDbContext _context;

    public GetProductEndpoint(AmazonDbContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(GetProductRequest req, CancellationToken ct)
    {
        var product = await _context.Products.FindAsync(req.Id);

        if (product == null)
        {
            await SendNotFoundAsync();
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

        await SendOkAsync(thingRoReturn);
    }
}
