using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Virtualize_bug;

internal class Context : DbContext
{
    public DbSet<Models.Article> Article => Set<Models.Article>();
    public DbSet<Models.Details> Details => Set<Models.Details>();

    public Context() { }
    public Context(DbContextOptions<Context> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            var name = modelBuilder.Entity(entity.Name).Metadata.ClrType.Name;
            modelBuilder.Entity(entity.Name).ToTable($"Articles.{name}", "Stand");
        };

        base.OnModelCreating(modelBuilder);
    }
    public static void Initialize(Context _context)
    {
        if (_context.Database.GetPendingMigrations().Any() == false)
            return;

        _context.Database.Migrate();


        for(var i = 0; i < 300; i++)
        {
            var article = new Models.Article()
            {
                Details = new Models.Details()
                {
                    Title = $"test {i}",
                    Content = "test",
                    Description = "test",
                }
            };
            
            _context.Article.Add(article);
            _context.SaveChanges();
        }
    }
}