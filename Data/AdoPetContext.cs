using AdoPet.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace AdoPet.Data;

/// <summary>
/// Contexto para conexão com o banco de dados.
/// </summary>
public class AdoPetContext : DbContext
{
    /// <summary>
    /// Metodo construtor
    /// </summary>
    /// <param name="opts">Recebe a opção</param>
    public AdoPetContext(DbContextOptions<AdoPetContext> opts) : base(opts)
    {

    }

    /// <summary>
    /// Conecta ao banco de dados Tutores
    /// </summary>
    public DbSet<Tutores> Tutores { get; set; }

    /// <summary>
    /// Função override
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

