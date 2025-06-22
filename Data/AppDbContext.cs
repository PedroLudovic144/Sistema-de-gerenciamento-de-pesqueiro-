using Microsoft.EntityFrameworkCore;
using MeuPesqueiroAPI.Models;

namespace MeuPesqueiroAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Pesqueiro> Pesqueiros { get; set; }
}

