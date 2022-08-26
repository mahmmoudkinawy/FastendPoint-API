namespace API.Contracts.Responses;
public class GetAllProductsResponse 
{
    public IEnumerable<GetProductResponse> Products { get; init; } =
        Enumerable.Empty<GetProductResponse>();
}
