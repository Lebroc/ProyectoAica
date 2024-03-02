using System.Collections;
using Microsoft.EntityFrameworkCore;
using ProyectoAica.Db;
using File = ProyectoAica.Models.File;

namespace ProyectoAica.Endpoints;

public static class OpenFolderEndpoint
{
    public static void MapOpenFolderEndpoint(this WebApplication app)
    {
       // List<File> list = new List<File>();
        var group = app.MapGroup("/Files")
            .WithOpenApi()
            .WithTags(["Files"]);

        group.MapGet("/openfolder/{id:int}/Children", async (int id,MyDbContext db) =>
                {
                var file = await db.Files.Include(f => f.Children)
                    .FirstOrDefaultAsync(f => f.Id == id);

                if (file == null)
                {
                    return Results.NotFound("File not Found");
                }
                return file.Children;
            }
        )
            .WithName("GetFileChildren")
            .WithOpenApi();

      /*  group.MapGet("/open", async context =>
        {
            var id = context.Request.RouteValues["id"].ToString();
            int fileId = int.Parse(id);

            // Usa el DbContext inyectado
            var db = context.RequestServices.GetService<MyDbContext>();
            var file = await db.Files.Include(f => f.Children)
                .FirstOrDefaultAsync(f => f.Id == fileId);

            if (file == null)
            {
                return;// Results.NotFound("File not Found");
            }

            return; // Results.Ok(file.Children);
        });*/
    }
}