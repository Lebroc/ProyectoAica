using Microsoft.EntityFrameworkCore;
using File = ProyectoAica.Models.File;

namespace ProyectoAica.Db;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext>options)
        : base(options){}

    public DbSet<File> Files => Set<File>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<File>()
            .HasOne(p => p.Parent)
            .WithMany(b => b.Children)
            .HasForeignKey(p => p.ParentId)
            .OnDelete(DeleteBehavior.Cascade); // Configura la eliminación en cascada
    }
}