using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data;

/// <summary>
/// Contexte Entity Framework Core de l'application.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Initialise une nouvelle instance du contexte de donnees.
    /// </summary>
    /// <param name="options">Options de configuration Entity Framework Core.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Collection des taches persistees en base de donnees.
    /// </summary>
    public DbSet<TodoItem> Todos => Set<TodoItem>();

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(x => x.Description)
                .HasMaxLength(1000);

            entity.Property(x => x.CreatedAt)
                .IsRequired();
        });
    }
}
