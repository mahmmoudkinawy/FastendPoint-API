namespace API.Endpoints;
public class CreateProductEndpoint:Endpoint<CreateProductRequest>
{
    public override void Configure()
    {

    }

    public override Task HandleAsync(CreateProductRequest req, CancellationToken ct)
    {
        return base.HandleAsync(req, ct);
    }
}
