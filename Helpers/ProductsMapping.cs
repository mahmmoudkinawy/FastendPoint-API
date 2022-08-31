namespace API.Helpers;
public class ProductsMapping : Profile
{
	public ProductsMapping()
	{
		CreateMap<ProductEntity, ProductResponse>();
		CreateMap<CreateProductRequest, ProductEntity>()
			.ForMember(opt => opt.Created, opt => opt.MapFrom(val => DateTime.UtcNow));
	}
}
