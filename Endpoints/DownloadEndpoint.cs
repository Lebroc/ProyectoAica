using Microsoft.EntityFrameworkCore;
using ProyectoAica.Db;
using File = ProyectoAica.Models.File;

namespace ProyectoAica.Endpoints;

public static class DownloadEndpoint
{
    public static void MapDownloadEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("/Files")
            .WithOpenApi()
            .WithTags(["Files"]);

        group.MapGet("/download/{id}", async (int id, MyDbContext db)=> 
                await db.Files.FindAsync(id)
                    is File file
                        ? Results.Ok(file)
                        : Results.NotFound()
        )
            .WithSummary("get file by id");
    }
}