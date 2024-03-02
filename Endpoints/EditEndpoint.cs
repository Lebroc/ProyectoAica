/*
using Microsoft.AspNetCore.Components.Forms;
using ProyectoAica.Db;
using File = ProyectoAica.Models.File;

namespace ProyectoAica.Endpoints;

public static class EditEndpoint
{
        public static void MapEditEndpoint(this WebApplication app)
        {

            var group = app.MapGroup("/EditFiles")
                .WithOpenApi()
                .WithTags(["Files"]);


            group.MapPut("/{id}", async (int id,File inputFile, MyDbContext db) =>
            {
                var file = await db.Files.FindAsync(id);
                if (file is null) return Results.NotFound();

                file.Name = inputFile.Name;
                file.ParentId = inputFile.ParentId;
                file.Parent = inputFile.Parent;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });
        }
}
*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoAica.Db;
using File = ProyectoAica.Models.File;

namespace TuProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class FilesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public FilesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Files/5/Children
        [HttpGet("{id}/Children")]
        public async Task<ActionResult<IEnumerable<File>>> GetChildren(int id)
        {
            var file = await _context.Files
                .Include(f => f.Children)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (file == null)
            {
                return NotFound();
            }

            return file.Children;
        }
    }
}
