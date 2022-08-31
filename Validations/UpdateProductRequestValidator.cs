namespace API.Validations;
public class UpdateProductRequestValidator : Validator<UpdateProductRequest>
{
	public UpdateProductRequestValidator()
	{
        RuleFor(p => p.Price).GreaterThan(0).NotEmpty();
        RuleFor(p => p.CountInStock).GreaterThanOrEqualTo(0).NotEmpty();
        RuleFor(p => p.Name).MinimumLength(3).NotEmpty();
    }
}
