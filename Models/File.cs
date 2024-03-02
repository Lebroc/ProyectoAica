namespace ProyectoAica.Models;

public class File
{
    
    public File(string name, int id, int? parentId, Extension extension)
    {
        Name = name;
        Id = id;
        ParentId = parentId;
        Extension = extension;
    }

    public required string? Name { get; set; }
    public int Id { get; set; }
    public required int? ParentId { get; set; }
    public required Extension Extension { get; set; }
    public File? Parent { get; set; }
    public List<File> Children { get; set; } = new List<File>();
}