using System.Data.Entity;
using DemoWebApi.Models;

namespace DemoWebApi.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(" name = LOCALDB ") { }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Teste> Testes { get; set; }
    }
}