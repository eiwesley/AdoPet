using AdoPet.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace AdoPet.Data;

public class TutorContext : DbContext
{
    public TutorContext(DbContextOptions<TutorContext> opts) : base(opts)
    {

    }

    public DbSet<Tutores> Tutores { get; set; }
}

