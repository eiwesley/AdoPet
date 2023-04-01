using AdoPet.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace AdoPet.Data;

public class AdoPetContext : DbContext
{
    public AdoPetContext(DbContextOptions<AdoPetContext> opts) : base(opts)
    {

    }

    public DbSet<Tutores> Tutores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

