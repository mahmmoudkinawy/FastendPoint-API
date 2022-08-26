namespace API.Helpers;
public class ProductsMapping : Profile
{
	public ProductsMapping()
	{
		CreateMap<ProductEntity, GetProductResponse>();
	}
}
