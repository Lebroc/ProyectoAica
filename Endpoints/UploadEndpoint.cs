using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using ProyectoAica.Db;
using ProyectoAica.Models;
using File = ProyectoAica.Models.File;

namespace ProyectoAica.Endpoints;

public static class UploadEndpoint
{
    public static void MapUploadFile(this WebApplication app)
    {
        
        var group = app.MapGroup("/Files")
            .WithOpenApi()
            .WithTags(["Files"]);


        group.MapPost("/upload", async (string name, int id,int? parentId,Extension extension,MyDbContext db) =>
        {
            File file = new File(name,id,parentId,extension)
            {
                Name = name,
                Id = id,
                ParentId = parentId,
                Extension = extension,
                Parent = null,
            };
            db.Files.Add(file);
            await db.SaveChangesAsync();

            return Results.Created($"/upload/{file.Id}", file);
        });
    }
}