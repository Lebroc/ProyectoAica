using ProyectoAica.Db;

namespace ProyectoAica.Endpoints;

public static class DeleteEndpoint
{
    public static void MapDeleteEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("/Files")
            .WithOpenApi()
            .WithTags(["Files"]);

        group.MapDelete("/delete/{id}", async (int id, MyDbContext db) =>
            {
                if (await db.Files.FindAsync(id) is Models.File file)
                {
                    db.Files.Remove(file);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }
                return Results.NotFound();
            }
        );
        
    }
}