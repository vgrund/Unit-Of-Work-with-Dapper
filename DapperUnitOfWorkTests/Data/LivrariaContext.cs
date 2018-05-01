using DapperUnitOfWork.Entities;
using System.Data.Entity;

namespace Uow.Package.Data
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext()
            :base("LivrariaContext")
        {

        }

        public DbSet<Estante> Estantes { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}
