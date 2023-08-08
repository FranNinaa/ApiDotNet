using Microsoft.EntityFrameworkCore;
using ApiCatalogo.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiCatalogo.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
