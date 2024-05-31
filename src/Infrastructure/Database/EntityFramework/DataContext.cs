using CSharpCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSharpCleanArch.Infrastructure.Database.EntityFramework;
public class DataContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
    : base(options) { }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}