using ProyectoAica.Db;

namespace ProyectoAica.Endpoints;

public static class MoveEndpoint
{
    public static void MapMoveEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("/Files")
            .WithOpenApi()
            .WithTags(["Files"]);

        group.MapPatch("/movefiles/{id}", async (MyDbContext db, int id, int nuevoParentId) =>
        {
                var carpet = await db.Files.FindAsync(id);
                
                carpet.ParentId = nuevoParentId;
                await db.SaveChangesAsync();

                return Results.Ok(carpet);
                return Results.NotFound();
        }
            );
    }
}   