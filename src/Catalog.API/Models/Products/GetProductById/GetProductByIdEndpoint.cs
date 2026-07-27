using Carter;

namespace Catalog.API.Models.Products.GetProductById
{
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id:guid}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                return Results.Ok(result.Product);
            })
                .WithName("GetProductById")
                .Produces<Product>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Obtener producto por ID")
                .WithDescription("Devuelve un producto por su identificador GUID.");
        }
    }
}
