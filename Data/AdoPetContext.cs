using Models.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using AdoPet.Models;

namespace Models.Data;

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
    public DbSet<User> User { get; set; }

    /// <summary>
    /// Função override
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Conecta ao banco de dados Pets
    /// </summary>
    public DbSet<Pet> Pet { get; set; }

    /// <summary>
    /// Conecta ao banco de dados Abrigo
    /// </summary>
    public DbSet<Abrigo> Abrigo { get; set; }

    /// <summary>
    /// Conecta ao banco de dados Adocao
    /// </summary>
    public DbSet<Adocao> Adocao { get; set; }

}

